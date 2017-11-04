namespace KoTSaver
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.labelBase = new System.Windows.Forms.Label();
            this.labelLayout = new System.Windows.Forms.Label();
            this.textBoxLayout = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelBaseNum = new System.Windows.Forms.Label();
            this.labelLayoutName = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxSlowdown = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.trackBarStartSleepTime = new System.Windows.Forms.TrackBar();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.textBoxTimers = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStartSleepTime)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonStart.FlatAppearance.BorderSize = 2;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(392, 341);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(132, 47);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveAs.Location = new System.Drawing.Point(115, 24);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(103, 34);
            this.buttonSaveAs.TabIndex = 7;
            this.buttonSaveAs.Text = "Save as";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // labelBase
            // 
            this.labelBase.AutoSize = true;
            this.labelBase.BackColor = System.Drawing.Color.Transparent;
            this.labelBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBase.Location = new System.Drawing.Point(12, 279);
            this.labelBase.Name = "labelBase";
            this.labelBase.Size = new System.Drawing.Size(60, 24);
            this.labelBase.TabIndex = 8;
            this.labelBase.Text = "BASE";
            // 
            // labelLayout
            // 
            this.labelLayout.AutoSize = true;
            this.labelLayout.BackColor = System.Drawing.Color.Transparent;
            this.labelLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLayout.Location = new System.Drawing.Point(132, 279);
            this.labelLayout.Name = "labelLayout";
            this.labelLayout.Size = new System.Drawing.Size(85, 24);
            this.labelLayout.TabIndex = 9;
            this.labelLayout.Text = "LAYOUT";
            // 
            // textBoxLayout
            // 
            this.textBoxLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLayout.Location = new System.Drawing.Point(6, 25);
            this.textBoxLayout.Name = "textBoxLayout";
            this.textBoxLayout.Size = new System.Drawing.Size(103, 31);
            this.textBoxLayout.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.textBoxLayout);
            this.groupBox1.Controls.Add(this.buttonSaveAs);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 65);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save layout :";
            // 
            // labelBaseNum
            // 
            this.labelBaseNum.AutoSize = true;
            this.labelBaseNum.BackColor = System.Drawing.Color.Transparent;
            this.labelBaseNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBaseNum.Location = new System.Drawing.Point(78, 279);
            this.labelBaseNum.Name = "labelBaseNum";
            this.labelBaseNum.Size = new System.Drawing.Size(40, 24);
            this.labelBaseNum.TabIndex = 16;
            this.labelBaseNum.Text = "???";
            // 
            // labelLayoutName
            // 
            this.labelLayoutName.AutoSize = true;
            this.labelLayoutName.BackColor = System.Drawing.Color.Transparent;
            this.labelLayoutName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLayoutName.Location = new System.Drawing.Point(223, 279);
            this.labelLayoutName.Name = "labelLayoutName";
            this.labelLayoutName.Size = new System.Drawing.Size(40, 24);
            this.labelLayoutName.TabIndex = 17;
            this.labelLayoutName.Text = "???";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(536, 24);
            this.mainMenu.TabIndex = 18;
            this.mainMenu.Text = "menuStrip1";
            this.mainMenu.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.enterKeyToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // enterKeyToolStripMenuItem
            // 
            this.enterKeyToolStripMenuItem.Name = "enterKeyToolStripMenuItem";
            this.enterKeyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.enterKeyToolStripMenuItem.Text = "Enter key";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(336, 280);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 34);
            this.buttonSave.TabIndex = 19;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxSlowdown
            // 
            this.checkBoxSlowdown.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSlowdown.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxSlowdown.BackgroundImage = global::KoTSaver.Properties.Resources.SlowdownUnchecked;
            this.checkBoxSlowdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxSlowdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSlowdown.Location = new System.Drawing.Point(440, 280);
            this.checkBoxSlowdown.Name = "checkBoxSlowdown";
            this.checkBoxSlowdown.Size = new System.Drawing.Size(84, 34);
            this.checkBoxSlowdown.TabIndex = 23;
            this.checkBoxSlowdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxSlowdown.UseVisualStyleBackColor = false;
            this.checkBoxSlowdown.CheckedChanged += new System.EventHandler(this.checkBoxSlowdown_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox1.BackgroundImage = global::KoTSaver.Properties.Resources.Background;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(422, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackgroundImage = global::KoTSaver.Properties.Resources.DeleteRed;
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(296, 280);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(34, 34);
            this.buttonDelete.TabIndex = 25;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // trackBarStartSleepTime
            // 
            this.trackBarStartSleepTime.BackColor = System.Drawing.SystemColors.Window;
            this.trackBarStartSleepTime.Location = new System.Drawing.Point(272, 352);
            this.trackBarStartSleepTime.Maximum = 5;
            this.trackBarStartSleepTime.Minimum = 1;
            this.trackBarStartSleepTime.Name = "trackBarStartSleepTime";
            this.trackBarStartSleepTime.Size = new System.Drawing.Size(104, 45);
            this.trackBarStartSleepTime.TabIndex = 26;
            this.trackBarStartSleepTime.Value = 5;
            this.trackBarStartSleepTime.Scroll += new System.EventHandler(this.trackBarStartSleepTime_Scroll);
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.BackColor = System.Drawing.Color.Transparent;
            this.labelStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStartTime.Location = new System.Drawing.Point(258, 333);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(128, 16);
            this.labelStartTime.TabIndex = 27;
            this.labelStartTime.Text = "Start sleep : 5sec";
            // 
            // textBoxTimers
            // 
            this.textBoxTimers.Location = new System.Drawing.Point(440, 27);
            this.textBoxTimers.Name = "textBoxTimers";
            this.textBoxTimers.Size = new System.Drawing.Size(84, 247);
            this.textBoxTimers.TabIndex = 28;
            this.textBoxTimers.Text = "";
            this.textBoxTimers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTimers_KeyPress);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::KoTSaver.Properties.Resources.main_background;
            this.ClientSize = new System.Drawing.Size(535, 400);
            this.Controls.Add(this.textBoxTimers);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.trackBarStartSleepTime);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.checkBoxSlowdown);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelLayoutName);
            this.Controls.Add(this.labelBaseNum);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelLayout);
            this.Controls.Add(this.labelBase);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "KoTSaver (by saroga.sak)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStartSleepTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Label labelBase;
        private System.Windows.Forms.Label labelLayout;
        private System.Windows.Forms.TextBox textBoxLayout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelBaseNum;
        private System.Windows.Forms.Label labelLayoutName;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterKeyToolStripMenuItem;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxSlowdown;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TrackBar trackBarStartSleepTime;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.RichTextBox textBoxTimers;
    }
}

