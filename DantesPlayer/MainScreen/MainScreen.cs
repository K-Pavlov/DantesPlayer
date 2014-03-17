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
        private static Timer timerForRF = new Timer();
        private static Timer timerForVideoProgress = new Timer();
        private static bool fastForwardFired = false;
        private static bool rewindFired = false;
        private static string videoName;
        private static string typeExpecption = "The type ";
        private Video video;
        public MainScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Left + 100;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height/3;
            timerForRF.Interval = 1000;
            timerForRF.Tick += timer_Tick;
            timerForVideoProgress.Interval = 1000;
            timerForVideoProgress.Tick += timerForVideoProgress_Tick;
        }

        void timerForVideoProgress_Tick(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                if (CheckException.CheckNull(this.video.DirectVideo))
                {
                    HolderForm.HandleVideoProgress(VideoProgress, this.video.DirectVideo);
                }
                else
                {
                    timerForVideoProgress.Stop();
                }
            }
            else
            {
                timerForVideoProgress.Stop();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (fastForwardFired)
            {
                if (CheckException.CheckNull(video))
                {
                    this.video.FastForward();
                    if (this.video.Speed == 0)
                    {
                        timerForRF.Stop();
                    }
                }
            }
            
            if (rewindFired)
            {
                if (CheckException.CheckNull(video))
                {
                    this.video.Rewind();
                    if (this.video.Speed == 0)
                    {
                        timerForRF.Stop();
                    }
                }
            }
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoName = ChooseVideoDialog.TakePathToVideo();
            if(CheckException.CheckNull(videoName))
            {
                try
                {
                    video = new Video(videoName, false, 800, 600);
                    video.StartVideo();
                    timerForVideoProgress.Start();
                    AudioForVideos.VolumeInit(this.video, this.VolumeProgress);
                }
                catch (TypeLoadException)
                {
                    typeExpecption += videoName.Substring(videoName.LastIndexOf('.') + 1) ;
                    typeExpecption += " is currently unsupported. We are sorry for the inconvinience.";
                    MessageBox.Show(typeExpecption,"Warning");
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

        #region ButtonOnClickStyles
        private void PauseButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.PauseButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                this.video.PauseVideo();
            }
            if (timerForRF.Enabled)
            {
                timerForRF.Stop();
                this.video.Speed = 0;
            }
        }

        private void StopButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.StopButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                timerForRF.Stop();
                this.video.StopVideo();
                this.VideoProgress.Value = 0;
            }
        }

        private void RewindButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.RewindButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                timerForRF.Start();
                this.video.Speed -= 5;
                rewindFired = true;
            }
        }

        private void PlayButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.PlayButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                this.video.PlayVideo();
            }
            if (timerForRF.Enabled)
            {
                timerForRF.Stop();
                this.video.Speed = 0;
            }
        }

        private void FFButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.FFButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                timerForRF.Start();
                this.video.Speed += 5;
                fastForwardFired = true;
            }
        }

        private void FFButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.FFButton.FlatStyle = FlatStyle.Flat;
        }

        private void StopButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.StopButton.FlatStyle = FlatStyle.Flat;
        }

        private void RewindButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.RewindButton.FlatStyle = FlatStyle.Flat;
        }

        private void PauseButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.PauseButton.FlatStyle = FlatStyle.Flat;
        }

        private void PlayButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.PlayButton.FlatStyle = FlatStyle.Flat;
        }

        private void VolumeDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.VolumeDown.FlatStyle = FlatStyle.Popup;
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

        private void VolumeUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.VolumeUp.FlatStyle = FlatStyle.Popup;
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

        private void VolumeDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.VolumeDown.FlatStyle = FlatStyle.Flat;
        }

        private void VolumeUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.VolumeUp.FlatStyle = FlatStyle.Flat;
        }

        private void Repeat_MouseDown(object sender, MouseEventArgs e)
        {
            this.Repeat.FlatStyle = FlatStyle.Popup;
        }

        private void Playlist_MouseDown(object sender, MouseEventArgs e)
        {
            this.Playlist.FlatStyle = FlatStyle.Popup;
        }

        private void FullScreen_MouseDown(object sender, MouseEventArgs e)
        {
            this.FullScreen.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                this.video.OpenVideoInFullScreen();
            }
        }

        private void closeVideo_MouseDown(object sender, MouseEventArgs e)
        {
            this.closeVideo.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                this.video.CloseVideo();
                this.video = null;
                this.VideoProgress.Value = 0;
            }
        }

        private void Repeat_MouseUp(object sender, MouseEventArgs e)
        {
            this.Repeat.FlatStyle = FlatStyle.Flat;
        }

        private void Playlist_MouseUp(object sender, MouseEventArgs e)
        {
            this.Playlist.FlatStyle = FlatStyle.Flat;
        }

        private void FullScreen_MouseUp(object sender, MouseEventArgs e)
        {
            this.FullScreen.FlatStyle = FlatStyle.Flat;
        }

        private void closeVideo_MouseUp(object sender, MouseEventArgs e)
        {
            this.closeVideo.FlatStyle = FlatStyle.Flat;
        }
        #endregion
    }
}
