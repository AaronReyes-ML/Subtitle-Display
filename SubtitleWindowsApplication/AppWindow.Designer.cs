namespace SubtitleWindowsApplication
{
    partial class AppWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.StartPrompt = new System.Windows.Forms.Button();
            this.SubtitleDisplayBox = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.CountDown = new System.Windows.Forms.Label();
            this.PauseStatus = new System.Windows.Forms.Label();
            this.MoreThanOne = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SubtitleBox2 = new System.Windows.Forms.Label();
            this.Pause = new System.Windows.Forms.Button();
            this.LanguageSelectorA = new System.Windows.Forms.Button();
            this.LanguageSelectorB = new System.Windows.Forms.Button();
            this.DeveloperMode = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Paused = new System.Windows.Forms.PictureBox();
            this.gettingPaused4 = new System.Windows.Forms.PictureBox();
            this.gettingPaused3 = new System.Windows.Forms.PictureBox();
            this.gettingPaused2 = new System.Windows.Forms.PictureBox();
            this.gettingPaused1 = new System.Windows.Forms.PictureBox();
            this.NotPaused = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Paused)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gettingPaused4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gettingPaused3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gettingPaused2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gettingPaused1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotPaused)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // StartPrompt
            // 
            resources.ApplyResources(this.StartPrompt, "StartPrompt");
            this.StartPrompt.Name = "StartPrompt";
            this.StartPrompt.UseVisualStyleBackColor = true;
            this.StartPrompt.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubtitleDisplayBox
            // 
            this.SubtitleDisplayBox.BackColor = System.Drawing.Color.Magenta;
            resources.ApplyResources(this.SubtitleDisplayBox, "SubtitleDisplayBox");
            this.SubtitleDisplayBox.ForeColor = System.Drawing.Color.Snow;
            this.SubtitleDisplayBox.Name = "SubtitleDisplayBox";
            this.SubtitleDisplayBox.UseCompatibleTextRendering = true;
            this.SubtitleDisplayBox.Click += new System.EventHandler(this.SubtitleDisplayBox_Click);
            // 
            // StartButton
            // 
            resources.ApplyResources(this.StartButton, "StartButton");
            this.StartButton.Name = "StartButton";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CountDown
            // 
            resources.ApplyResources(this.CountDown, "CountDown");
            this.CountDown.BackColor = System.Drawing.Color.Magenta;
            this.CountDown.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.CountDown.Name = "CountDown";
            this.CountDown.Click += new System.EventHandler(this.CountDown_Click);
            // 
            // PauseStatus
            // 
            resources.ApplyResources(this.PauseStatus, "PauseStatus");
            this.PauseStatus.BackColor = System.Drawing.Color.Magenta;
            this.PauseStatus.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.PauseStatus.Name = "PauseStatus";
            // 
            // MoreThanOne
            // 
            resources.ApplyResources(this.MoreThanOne, "MoreThanOne");
            this.MoreThanOne.Name = "MoreThanOne";
            this.MoreThanOne.UseVisualStyleBackColor = true;
            this.MoreThanOne.Click += new System.EventHandler(this.MoreThanOne_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // SubtitleBox2
            // 
            this.SubtitleBox2.BackColor = System.Drawing.Color.Magenta;
            resources.ApplyResources(this.SubtitleBox2, "SubtitleBox2");
            this.SubtitleBox2.ForeColor = System.Drawing.Color.Snow;
            this.SubtitleBox2.Name = "SubtitleBox2";
            this.SubtitleBox2.UseCompatibleTextRendering = true;
            // 
            // Pause
            // 
            resources.ApplyResources(this.Pause, "Pause");
            this.Pause.Name = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // LanguageSelectorA
            // 
            resources.ApplyResources(this.LanguageSelectorA, "LanguageSelectorA");
            this.LanguageSelectorA.Name = "LanguageSelectorA";
            this.LanguageSelectorA.UseVisualStyleBackColor = true;
            this.LanguageSelectorA.Click += new System.EventHandler(this.LanguageSelectorA_Click);
            // 
            // LanguageSelectorB
            // 
            resources.ApplyResources(this.LanguageSelectorB, "LanguageSelectorB");
            this.LanguageSelectorB.Name = "LanguageSelectorB";
            this.LanguageSelectorB.UseVisualStyleBackColor = true;
            this.LanguageSelectorB.Click += new System.EventHandler(this.LanguageSelectorB_Click);
            // 
            // DeveloperMode
            // 
            resources.ApplyResources(this.DeveloperMode, "DeveloperMode");
            this.DeveloperMode.Name = "DeveloperMode";
            this.DeveloperMode.UseVisualStyleBackColor = true;
            this.DeveloperMode.Click += new System.EventHandler(this.DeveloperMode_Click);
            // 
            // Password
            // 
            resources.ApplyResources(this.Password, "Password");
            this.Password.Name = "Password";
            this.Password.UseSystemPasswordChar = true;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // Paused
            // 
            resources.ApplyResources(this.Paused, "Paused");
            this.Paused.Name = "Paused";
            this.Paused.TabStop = false;
            // 
            // gettingPaused4
            // 
            resources.ApplyResources(this.gettingPaused4, "gettingPaused4");
            this.gettingPaused4.Name = "gettingPaused4";
            this.gettingPaused4.TabStop = false;
            // 
            // gettingPaused3
            // 
            resources.ApplyResources(this.gettingPaused3, "gettingPaused3");
            this.gettingPaused3.Name = "gettingPaused3";
            this.gettingPaused3.TabStop = false;
            // 
            // gettingPaused2
            // 
            resources.ApplyResources(this.gettingPaused2, "gettingPaused2");
            this.gettingPaused2.Name = "gettingPaused2";
            this.gettingPaused2.TabStop = false;
            // 
            // gettingPaused1
            // 
            resources.ApplyResources(this.gettingPaused1, "gettingPaused1");
            this.gettingPaused1.Name = "gettingPaused1";
            this.gettingPaused1.TabStop = false;
            // 
            // NotPaused
            // 
            resources.ApplyResources(this.NotPaused, "NotPaused");
            this.NotPaused.Name = "NotPaused";
            this.NotPaused.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SubtitleWindowsApplication.Properties.Resources.WaitingImgLeft;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SubtitleWindowsApplication.Properties.Resources.WaitingImgRight;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // AppWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.Password);
            this.Controls.Add(this.DeveloperMode);
            this.Controls.Add(this.LanguageSelectorB);
            this.Controls.Add(this.LanguageSelectorA);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.SubtitleBox2);
            this.Controls.Add(this.MoreThanOne);
            this.Controls.Add(this.PauseStatus);
            this.Controls.Add(this.Paused);
            this.Controls.Add(this.gettingPaused4);
            this.Controls.Add(this.gettingPaused3);
            this.Controls.Add(this.gettingPaused2);
            this.Controls.Add(this.gettingPaused1);
            this.Controls.Add(this.NotPaused);
            this.Controls.Add(this.CountDown);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.SubtitleDisplayBox);
            this.Controls.Add(this.StartPrompt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "AppWindow";
            this.Load += new System.EventHandler(this.Interface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Paused)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gettingPaused4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gettingPaused3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gettingPaused2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gettingPaused1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotPaused)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button StartPrompt;
        private System.Windows.Forms.Label SubtitleDisplayBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label CountDown;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox NotPaused;
        private System.Windows.Forms.PictureBox gettingPaused1;
        private System.Windows.Forms.PictureBox gettingPaused2;
        private System.Windows.Forms.PictureBox gettingPaused3;
        private System.Windows.Forms.PictureBox gettingPaused4;
        private System.Windows.Forms.PictureBox Paused;
        private System.Windows.Forms.Label PauseStatus;
        private System.Windows.Forms.Button MoreThanOne;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label SubtitleBox2;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button LanguageSelectorA;
        private System.Windows.Forms.Button LanguageSelectorB;
        private System.Windows.Forms.Button DeveloperMode;
        private System.Windows.Forms.TextBox Password;
    }
}