using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KoTSaver
{
    public partial class FormLayouts : Form
    {
        int x = 10;
        int y = 50;
        int height = 225;
        int width = 400;

        private readonly string BaseNum;

        public FormLayouts(string baseNum)
        {
            InitializeComponent();
            BaseNum = baseNum;
            CreateControls(baseNum);
        }

        private void CreateControls(string baseNum)
        {
            int countControls = 1;
            var files = Directory.GetFiles(PathHelper.BaseDirectoryPath(baseNum)).OrderBy(f => f.Length);
            foreach (var file in files)
            {
                string layoutName = Path.GetFileNameWithoutExtension(file);
                PictureBox pictureBox = new PictureBox
                {
                    Name = "pictureBox_" + layoutName,
                    Location = new Point(x, y),
                    Size = new Size(width, height),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(file)
                };
                pictureBox.MouseDoubleClick += pictureBoxMouseDoubleClick;

                Controls.Add(pictureBox);

                Label label = new Label
                {
                    Name = "label_" + layoutName,
                    Location = new Point(x + 180, y + pictureBox.Height),
                    Font = new Font(FontFamily.GenericMonospace, 14, FontStyle.Bold),
                    Text = layoutName
                };

                Controls.Add(label);

                if (countControls++%2==0)
                {
                    x = 10;
                    y += height + 25;
                }
                else
                {
                    x += width + 10;
                }
            }
        }

        private void pictureBoxMouseDoubleClick(object sender, MouseEventArgs e)
        {
            string layoutName=((PictureBox) sender).Name.Substring(11);
            Data.EventHandlerChooseLayout(BaseNum, layoutName);
            Close();
        }

        private void FormLayouts_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            new FormBases().Show();
            Close();
        }
    }
}
