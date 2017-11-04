using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KoTSaver
{
    public partial class FormMain : Form
    {
        //импортируем mouse_event(): 
        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        public delegate void TimerEventHandler(UInt32 id, UInt32 msg, ref UInt32 userCtx, UInt32 rsv1, UInt32 rsv2);

        [DllImport("winmm.dll", SetLastError = true, EntryPoint = "timeSetEvent")]
        static extern UInt32 timeSetEvent(UInt32 msDelay, UInt32 msResolution, TimerEventHandler handler, ref UInt32 userCtx, UInt32 eventType);

        [DllImport("winmm.dll", SetLastError = true)]
        static extern void timeKillEvent(UInt32 uTimerID);

        [Flags]
        enum MouseFlags
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            Absolute = 0x8000
        };

        private uint timer;
        private CollectionDatabases _databases;
        private Thread _thread;
        private bool _start;
        

        public FormMain()
        {
            InitializeComponent();
            _databases = new CollectionDatabases();
            //Crypt.Check();
            //int trialTime = Crypt.Trial();
            //Text+=String.Format(" (Trial time: {0} days left)",trialTime);
            //MySqlData ad = new MySqlData();
            //ad.DemoCallback(this);
            Data.EventHandlerChooseLayout = new Data.ChooseLayout(Func);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!_start)
            {
                int n = textBoxTimers.Lines.Length;
                int startSleepTime = trackBarStartSleepTime.Value;
                List<int> timersList = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    string value = textBoxTimers.Lines[i].Trim();
                    if (value != "")
                    {
                        timersList.Add(int.Parse(value));
                    }
                }
                _thread = new Thread(() => Tap(timersList, startSleepTime));
                _thread.Start();
            }
            else
            {
                _thread.Abort();
                timeKillEvent(timer);
                SetEnabledProperty(true);
                buttonStart.Text = @"Start";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            checkBoxSlowdown.Checked = false;

            string baseNum = labelBaseNum.Text;
            string layoutName = labelLayoutName.Text;

            Database temp = _databases.GetDatabase(baseNum, layoutName);
            temp.Timers = CreateTimerString();
            _databases.EditItem(temp);
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            checkBoxSlowdown.Checked = false;

            if (textBoxLayout.Text.Trim().Length == 0)
            {
                MessageBox.Show("Enter name of layout!");
                return;
            }
            string baseNum = labelBaseNum.Text;
            string layoutName = textBoxLayout.Text;
            
            Database temp = new Database(_databases.GenerateNewId(), baseNum, layoutName, CreateTimerString());
            new FormBases(temp).Show();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new FormBases().ShowDialog();
        }

        private void SelectedImage(string baseNum, string layoutName)
        {
            checkBoxSlowdown.Checked = false;
            _databases  = new CollectionDatabases();
            textBoxTimers.Clear();

            pictureBox1.Image = Image.FromFile(PathHelper.FileImageLayout(baseNum,layoutName));

            Database d = _databases.GetDatabase(baseNum,layoutName);
            List<int> timers = d.GetTimersList();
            foreach (var timer in timers)
            {
                textBoxTimers.AppendText(timer + Environment.NewLine);
            }
            if (!buttonSave.Enabled)
            {
                buttonSave.Enabled = true;
                buttonDelete.Enabled = true;
            }

            checkBoxSlowdown.Checked = false;
        }

        void Func(string baseNum, string layoutName)
        {
            labelBaseNum.Text = baseNum;
            labelLayoutName.Text = layoutName;
            SelectedImage(baseNum,layoutName);
        }

        void Tap(List<int> timers, int startSleepTime)
        {
            SetEnabledProperty(false);
            buttonStart.Invoke(new Action(() => buttonStart.Text = @"Stop"));
            int n = timers.Count;
            int startIndex = 0;
            int x = MousePosition.X;
            int y = MousePosition.Y;
            Thread.Sleep(startSleepTime*1000);
            //AccurateSleep(startSleepTime * 1000);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x, y, 0, UIntPtr.Zero);
            for (int i = 0; i < n; i++)
            {
                textBoxTimers.Invoke(new Action(() =>
                {
                    textBoxTimers.SelectionStart = startIndex;
                    textBoxTimers.SelectionLength = textBoxTimers.Lines[i].Length;
                    textBoxTimers.SelectionColor = Color.Red;
                    textBoxTimers.Refresh();
                }));
                //Thread.Sleep(timers[i]);
                AccurateSleep(timers[i]);
                mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);
                mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x, y, 0, UIntPtr.Zero);
                startIndex += timers[i].ToString().Length;
                startIndex++;
                
                textBoxTimers.Invoke(new Action(() =>
                {
                    textBoxTimers.SelectionColor = Color.Black;
                    textBoxTimers.Refresh();
                }));
                
            }
            buttonStart.Invoke(new Action(() => buttonStart.Text = @"Start"));
            SetEnabledProperty(true);
        }

        private string CreateTimerString()
        {
            int n = textBoxTimers.Lines.Length;
            StringBuilder timers = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string value = textBoxTimers.Lines[i].Trim();
                if (value != "")
                {
                    timers.Append(value);
                    timers.Append(";");
                }
            }
            timers.Remove(timers.Length - 1, 1);
            
            return timers.ToString();
        }

        private void textBoxTimers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(13))
            {
                e.Handled = true;
            }
        }

        private void SetEnabledProperty(bool value)
        {
            _start = !value;
            pictureBox1.Invoke(new Action(() => pictureBox1.Enabled = value));
            textBoxTimers.Invoke(new Action(() =>
            {
                textBoxTimers.Enabled = value;
                textBoxTimers.SelectionColor = Color.Black;
                textBoxTimers.Refresh();
            }));
            checkBoxSlowdown.Invoke(new Action(() => checkBoxSlowdown.Enabled = value));
            buttonSave.Invoke(new Action(() => buttonSave.Enabled = value));
            buttonSaveAs.Invoke(new Action(() => buttonSaveAs.Enabled = value));
            trackBarStartSleepTime.Invoke(new Action(() => trackBarStartSleepTime.Enabled = value));
        }

        private void checkBoxSlowdown_CheckedChanged(object sender, EventArgs e)
        {
            int n = textBoxTimers.Lines.Length;
            string[] lines = textBoxTimers.Lines;
            var multiply = checkBoxSlowdown.Checked ? 2.0 : 0.5;
            checkBoxSlowdown.BackgroundImage = checkBoxSlowdown.Checked
                ? Properties.Resources.SlowdownChecked
                : Properties.Resources.SlowdownUnchecked;

            for (int i = 0; i < n; i++)
            {
                string value = lines[i].Trim();
                if (value != "")
                {
                    lines[i] = (int.Parse(value)*multiply).ToString();
                }
            }
            textBoxTimers.Lines = lines;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string baseNum = labelBaseNum.Text;
            string layoutName = labelLayoutName.Text;
            string text = String.Format("Are you sure you want to delete?\n Base {0} Layout {1}", baseNum, layoutName);
            string caption = "Warning!!!";
            DialogResult dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Database temp = _databases.GetDatabase(baseNum, layoutName);
                _databases.DeleteItem(temp);
                pictureBox1.Image = null;
                pictureBox1.Refresh();

                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(PathHelper.FileImageLayout(baseNum,layoutName));

                buttonDelete.Enabled = false;
                buttonSave.Enabled = false;
                labelBaseNum.Text = "???";
                labelLayoutName.Text = "???";
            }
        }

        private void trackBarStartSleepTime_Scroll(object sender, EventArgs e)
        {
            labelStartTime.Text = "Start sleep: "+ trackBarStartSleepTime.Value+"sec";
        }

        void AccurateSleep(int n)
        {
            ManualResetEvent reset = new ManualResetEvent(false);
            uint callBackData = 0;
            timer = timeSetEvent((uint)n, 1, delegate (UInt32 id, UInt32 msg, ref UInt32 userCtx, UInt32 rsv1, UInt32 rsv2)
            {
                reset.Set();
            }, ref callBackData, 0);
            reset.WaitOne();
            timeKillEvent(timer);
            reset.Reset();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _thread?.Abort();
            timeKillEvent(timer);
        }
    }
}
