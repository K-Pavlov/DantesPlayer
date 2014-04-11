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
        #region Constant Values
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int CS_DBLCLKS = 0x8;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int volumeStep = 10;
        #endregion
        private bool valueCanChange = true;
        private static string videoName;
        private static string typeExpecption = "The type ";
        AudioFormControl control = new AudioFormControl();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public MainScreen()
        {
            this.control.TopMost = true;
            this.TopMost = true;
            control.Show();
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
            this.VideoSlider.Enabled = false;
        }

        void timerForVideoProgress_Tick(object sender, EventArgs e)
        {
            this.valueCanChange = false;
            if (CheckException.CheckNull(video))
            {
                if (CheckException.CheckNull(this.video.DirectVideo))
                {
                    HolderForm.HandleVideoProgress(this.VideoSlider, this.video.DirectVideo);
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
            this.valueCanChange = false;
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
                    this.VideoSlider.Enabled = true;
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

        private void customSlider1_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckException.CheckNull(this.video))
            {
                HolderForm.HandleBarMovemenet(this.VideoSlider, this.video.DirectVideo);
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                    this.VolumeProgress.Value -= volumeStep;
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
                    this.VolumeProgress.Value += volumeStep;
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
            }
            this.VideoSlider.Value = 0;
            this.VideoSlider.Enabled = false;
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

        #region Protected Methods

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }

                    return;
            }
            control.Location = this.Location - new Size(280, -50);
            base.WndProc(ref m);
        }
        #endregion

        private void VolumeProgress_ValueChanged(object sender, decimal value)
        {
            if (CheckException.CheckNull(video))
            {
                AudioForVideos.VolumeInit(video, VolumeProgress);
            }
        }
    }
}
