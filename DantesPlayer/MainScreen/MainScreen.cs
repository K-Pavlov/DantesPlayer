using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MainScreen.UserInterfaceDialogs;
using MainScreen.VideoHandling;

namespace MainScreen
{
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
        /// <summary>
        /// Needs to be fixed will play
        /// a hardcoded video for now
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (this.video != null)
            {
                this.video.PlayVideo();
            }
        }
        
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (this.video != null)
            {
                this.video.StopVideo();
            }
        }
        /// <summary>
        /// When button pause is clicked pauses
        /// the video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (this.video != null)
            {
                this.video.PauseVideo();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoName = ChooseVideoDialog.TakePathToVideo();
            if (videoName != null)
            {
                video = new Video(videoName, false, 800, 600);
                video.StartVideo();
                this.VolumeProgress.Value = 100;
            }
        }

        private void closeVideo_Click(object sender, EventArgs e)
        {
            if (this.video != null)
            {
                this.video.CloseVideo();
            }
        }

        private void FullScreen_Click(object sender, EventArgs e)
        {
            if (video != null)
            {
                this.video.OpenVideoInFullScreen();
            }
        }

        private void VolumeDown_Click(object sender, EventArgs e)
        {
            if (this.video.directVideo.Audio.Volume > -10000)
            {
                this.video.directVideo.Audio.Volume -= 1000;
            }
            if (this.VolumeProgress.Value > 0)
            {
                this.VolumeProgress.Value -= 10;
            }
        }

        private void VolumeUp_Click(object sender, EventArgs e)
        {
            if (this.video.directVideo.Audio.Volume < 0)
            {
                this.video.directVideo.Audio.Volume += 1000;
            }
            if (this.VolumeProgress.Value + 10 <= 100)
            {
                this.VolumeProgress.Value += 10;
            }
        }

    }
}
