namespace MainScreen
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using UserInterfaceDialogs;
    using VideoHandling;
    using AudioHandling;
    #endregion

    public partial class MainScreen : Form
    {
        private static string videoName;
        private Video video;
        public MainScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Left + 100;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height/3;
        }
        
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                this.video.PlayVideo();
            }
        }
        
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                this.video.StopVideo();
            }
        }
        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                this.video.PauseVideo();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoName = ChooseVideoDialog.TakePathToVideo();
            if(CheckException.CheckNull(videoName))
            {
                video = new Video(videoName, false, 800, 600);
                video.StartVideo();
                AudioForVideos.VolumeInit(this.video, this.VolumeProgress);
            }

        }

        private void closeVideo_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                this.video.CloseVideo();
                this.video = null;
            }
        }

        private void FullScreen_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                this.video.OpenVideoInFullScreen();
            }
        }

        private void VolumeDown_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                this.video.VolumeDown(this.VolumeProgress);
            }
            else
            {
                if (this.VolumeProgress.Value > this.VolumeProgress.Minimum)
                {
                    this.VolumeProgress.Value -= this.VolumeProgress.Step;
                }
            }
        }

        private void VolumeUp_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                this.video.VolumeUp(this.VolumeProgress);
            }
            else
            {
                if (this.VolumeProgress.Value < this.VolumeProgress.Maximum)
                {
                    this.VolumeProgress.Value += this.VolumeProgress.Step;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.Close();
                if (CheckException.CheckNull(video))
                {
                    this.video.CloseVideo();
                }
                this.Dispose();
        }

    }
}
