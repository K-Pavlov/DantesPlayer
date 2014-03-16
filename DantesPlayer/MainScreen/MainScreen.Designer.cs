namespace MainScreen
{
    partial class MainScreen
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
            this.PlayButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.FFButton = new System.Windows.Forms.Button();
            this.RewindButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutThePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopButton = new System.Windows.Forms.Button();
            this.Playlist = new System.Windows.Forms.Button();
            this.Repeat = new System.Windows.Forms.Button();
            this.FullScreen = new System.Windows.Forms.Button();
            this.VolumeDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeVideo = new System.Windows.Forms.Button();
            this.VolumeUp = new System.Windows.Forms.Button();
            this.VolumeProgress = new System.Windows.Forms.ProgressBar();
            this.VideoProgress = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Image = global::MainScreen.Properties.Resources.playButtonUpdate;
            this.PlayButton.Location = new System.Drawing.Point(3, 54);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(91, 37);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayButton_MouseDown);
            this.PlayButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlayButton_MouseUp);
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseButton.Image = global::MainScreen.Properties.Resources.pauseButtonUpdate;
            this.PauseButton.Location = new System.Drawing.Point(212, 54);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(91, 37);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PauseButton_MouseDown);
            this.PauseButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PauseButton_MouseUp);
            // 
            // FFButton
            // 
            this.FFButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FFButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FFButton.Image = global::MainScreen.Properties.Resources.fastForwardButton;
            this.FFButton.Location = new System.Drawing.Point(111, 9);
            this.FFButton.Name = "FFButton";
            this.FFButton.Size = new System.Drawing.Size(91, 37);
            this.FFButton.TabIndex = 2;
            this.FFButton.UseVisualStyleBackColor = true;
            this.FFButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FFButton_MouseDown);
            this.FFButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FFButton_MouseUp);
            // 
            // RewindButton
            // 
            this.RewindButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RewindButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RewindButton.Image = global::MainScreen.Properties.Resources.rewindButtonUpdate;
            this.RewindButton.Location = new System.Drawing.Point(111, 97);
            this.RewindButton.Name = "RewindButton";
            this.RewindButton.Size = new System.Drawing.Size(91, 37);
            this.RewindButton.TabIndex = 3;
            this.RewindButton.UseVisualStyleBackColor = true;
            this.RewindButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RewindButton_MouseDown);
            this.RewindButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RewindButton_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(572, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem,
            this.aboutThePlayerToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.aboutUsToolStripMenuItem.Text = "About us";
            // 
            // aboutThePlayerToolStripMenuItem
            // 
            this.aboutThePlayerToolStripMenuItem.Name = "aboutThePlayerToolStripMenuItem";
            this.aboutThePlayerToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.aboutThePlayerToolStripMenuItem.Text = "About the player";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // StopButton
            // 
            this.StopButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Image = global::MainScreen.Properties.Resources.stopButtonUpdate;
            this.StopButton.Location = new System.Drawing.Point(111, 54);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(91, 37);
            this.StopButton.TabIndex = 5;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StopButton_MouseDown);
            this.StopButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopButton_MouseUp);
            // 
            // Playlist
            // 
            this.Playlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Playlist.Image = global::MainScreen.Properties.Resources.playListButtonUpdate;
            this.Playlist.Location = new System.Drawing.Point(414, 80);
            this.Playlist.Name = "Playlist";
            this.Playlist.Size = new System.Drawing.Size(91, 37);
            this.Playlist.TabIndex = 6;
            this.Playlist.UseVisualStyleBackColor = true;
            this.Playlist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Playlist_MouseDown);
            this.Playlist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Playlist_MouseUp);
            // 
            // Repeat
            // 
            this.Repeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Repeat.Image = global::MainScreen.Properties.Resources.repeatButtonUpdate;
            this.Repeat.Location = new System.Drawing.Point(414, 22);
            this.Repeat.Name = "Repeat";
            this.Repeat.Size = new System.Drawing.Size(91, 37);
            this.Repeat.TabIndex = 7;
            this.Repeat.UseVisualStyleBackColor = true;
            this.Repeat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Repeat_MouseDown);
            this.Repeat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Repeat_MouseUp);
            // 
            // FullScreen
            // 
            this.FullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FullScreen.Image = global::MainScreen.Properties.Resources.fullScreenButtonUpdate;
            this.FullScreen.Location = new System.Drawing.Point(414, 141);
            this.FullScreen.Name = "FullScreen";
            this.FullScreen.Size = new System.Drawing.Size(91, 37);
            this.FullScreen.TabIndex = 8;
            this.FullScreen.UseVisualStyleBackColor = true;
            this.FullScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FullScreen_MouseDown);
            this.FullScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FullScreen_MouseUp);
            // 
            // VolumeDown
            // 
            this.VolumeDown.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.VolumeDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VolumeDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VolumeDown.Image = global::MainScreen.Properties.Resources.buttonminus;
            this.VolumeDown.Location = new System.Drawing.Point(75, 232);
            this.VolumeDown.Name = "VolumeDown";
            this.VolumeDown.Size = new System.Drawing.Size(31, 23);
            this.VolumeDown.TabIndex = 10;
            this.VolumeDown.UseVisualStyleBackColor = true;
            this.VolumeDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VolumeDown_MouseDown);
            this.VolumeDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VolumeDown_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.StopButton);
            this.panel1.Controls.Add(this.FFButton);
            this.panel1.Controls.Add(this.PauseButton);
            this.panel1.Controls.Add(this.RewindButton);
            this.panel1.Controls.Add(this.PlayButton);
            this.panel1.Location = new System.Drawing.Point(12, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 142);
            this.panel1.TabIndex = 12;
            // 
            // closeVideo
            // 
            this.closeVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeVideo.Image = global::MainScreen.Properties.Resources.closeVideoButtonUpdate;
            this.closeVideo.Location = new System.Drawing.Point(414, 196);
            this.closeVideo.Name = "closeVideo";
            this.closeVideo.Size = new System.Drawing.Size(91, 37);
            this.closeVideo.TabIndex = 13;
            this.closeVideo.UseVisualStyleBackColor = true;
            this.closeVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.closeVideo_MouseDown);
            this.closeVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.closeVideo_MouseUp);
            // 
            // VolumeUp
            // 
            this.VolumeUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VolumeUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VolumeUp.Image = global::MainScreen.Properties.Resources.buttonplus;
            this.VolumeUp.Location = new System.Drawing.Point(234, 232);
            this.VolumeUp.Name = "VolumeUp";
            this.VolumeUp.Size = new System.Drawing.Size(31, 23);
            this.VolumeUp.TabIndex = 14;
            this.VolumeUp.UseVisualStyleBackColor = true;
            this.VolumeUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VolumeUp_MouseDown);
            this.VolumeUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VolumeUp_MouseUp);
            // 
            // VolumeProgress
            // 
            this.VolumeProgress.BackColor = System.Drawing.SystemColors.Control;
            this.VolumeProgress.Location = new System.Drawing.Point(112, 240);
            this.VolumeProgress.Name = "VolumeProgress";
            this.VolumeProgress.Size = new System.Drawing.Size(116, 10);
            this.VolumeProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.VolumeProgress.TabIndex = 15;
            this.VolumeProgress.Value = 100;
            // 
            // VideoProgress
            // 
            this.VideoProgress.BackColor = System.Drawing.Color.Aqua;
            this.VideoProgress.Location = new System.Drawing.Point(15, 204);
            this.VideoProgress.Name = "VideoProgress";
            this.VideoProgress.Size = new System.Drawing.Size(300, 10);
            this.VideoProgress.TabIndex = 16;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MainScreen.Properties.Resources.bg3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(572, 267);
            this.Controls.Add(this.VideoProgress);
            this.Controls.Add(this.VolumeProgress);
            this.Controls.Add(this.VolumeUp);
            this.Controls.Add(this.closeVideo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.VolumeDown);
            this.Controls.Add(this.FullScreen);
            this.Controls.Add(this.Repeat);
            this.Controls.Add(this.Playlist);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.Text = "DantesPlayer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button FFButton;
        private System.Windows.Forms.Button RewindButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutThePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button Playlist;
        private System.Windows.Forms.Button Repeat;
        private System.Windows.Forms.Button FullScreen;
        private System.Windows.Forms.Button VolumeDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeVideo;
        private System.Windows.Forms.Button VolumeUp;
        private System.Windows.Forms.ProgressBar VolumeProgress;
        private System.Windows.Forms.ProgressBar VideoProgress;
    }
}

