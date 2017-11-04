using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KoTSaver
{
    public partial class FormBases : Form
    {
        private Database NewDatabase;
        public FormBases()
        {
            InitializeComponent();
            CreateControls(OpenFormLayouts);
        }

        public FormBases(Database database)
        {
            InitializeComponent();
            NewDatabase = database;
            CreateControls(ChooseBase);
        }

        private void CreateControls(MouseEventHandler mouseEventHandler)
        {
            int x = 10;
            int y = 10;
            int height = 100;
            int width = 150;

            int countControls = 1;
            var files = Directory.GetFiles(PathHelper.MasksOfBasesDirectory).OrderBy(f => f.Length);
            foreach (var file in files)
            {
                string baseNum = Path.GetFileNameWithoutExtension(file);
                string path = PathHelper.BaseDirectoryPath(baseNum);

                PictureBox pictureBox = new PictureBox
                {
                    Name = "pictureBox_" + baseNum,
                    Location = new Point(x, y),
                    Size = new Size(width, height),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(file)
                };
                pictureBox.MouseDoubleClick += mouseEventHandler;
                
                int layoutCount = 0;
                if (Directory.Exists(path))
                {
                    layoutCount = Directory.GetFiles(path).Length;
                }
                Label label = new Label
                {
                    Name = "label_" + baseNum,
                    Font=new Font(FontFamily.GenericMonospace, 14,FontStyle.Bold),
                    Location = new Point(pictureBox.Location.X+60,pictureBox.Location.Y+height),
                    Text = layoutCount.ToString()
                };

                if (countControls++ % 5 == 0)
                {
                    x = 10;
                    y += height + 25;
                }
                else
                {
                    x += width + 10;
                }
                Controls.Add(pictureBox);
                Controls.Add(label);
            }
        }

        private void OpenFormLayouts(object sender, MouseEventArgs e)
        {
            string baseNum= ((PictureBox) sender).Name.Substring(11);
            string labelName = "label_" + baseNum;
            int layoutsCount = int.Parse(Controls.Find(labelName, false).First().Text);

            if (layoutsCount != 0)
            {
                new FormLayouts(baseNum).Show();
                Close();
            }
        }

        private void ChooseBase(object sender, MouseEventArgs e)
        {
            string baseNum = ((PictureBox)sender).Name.Substring(11);
            NewDatabase.BaseId = baseNum;
            string newFileName = PathHelper.FileImageLayout(baseNum, NewDatabase.Layout);

            CollectionDatabases cd = new CollectionDatabases();
            if (cd.GetDatabase(NewDatabase.BaseId, NewDatabase.Layout) == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Select layout image!",
                    Filter = "Image files (*.jpg)|*.jpg"
                };

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                if (!Directory.Exists(PathHelper.BaseDirectoryPath(baseNum)))
                {
                    Directory.CreateDirectory(PathHelper.BaseDirectoryPath(baseNum));
                }
                File.Copy(openFileDialog.FileName, newFileName, true);


                cd.AddItem(NewDatabase);
            }
            else
            {
                MessageBox.Show("Database already exists!\nEnter another name.");
                Close();
                return;
            }

            Data.EventHandlerChooseLayout(baseNum, NewDatabase.Layout);
            MessageBox.Show("Saved!");
            Close();
        }

        private void FormBases_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
