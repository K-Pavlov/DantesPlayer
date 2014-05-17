namespace MainScreen.VideoHandling
{
    #region Namespaces
    using System;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Input;
    using DirectXAllias = Microsoft.DirectX.AudioVideoPlayback;
    #endregion

    public class FormForVideo : Form
    {
        private DirectXAllias::Video video;
        private Timer timer;

        public FormForVideo()
        {
            this.InitializeComponent();
            this.timer = new Timer();
        }
        

        /// <summary>
        /// Gets or sets the DirectX video
        /// </summary>
        public DirectXAllias::Video Video
        {
            get
            {
                return this.video;
            }

            set
            {
                this.video = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.Video != null)
            {
                this.Video.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && MainScreen.Instance.video.IsFullScreen)
            {
                this.WindowState = FormWindowState.Normal;
                MainScreen.Instance.menuBar.timerForVideoProgress.Stop();
                MainScreen.Instance.menuBar.Dispose();
                MainScreen.Instance.video.IsFullScreen = false;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormForVideo
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "FormForVideo";
            this.Load += new System.EventHandler(this.SetTopMost);
            this.Click += new System.EventHandler(this.SetTopMost);
            this.ResumeLayout(false);

        }

        private void SetTopMost(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void PlayPauseVideo()
        {
            if (this.Video != null)
            {
                if (this.Video.Playing)
                {
                    this.Video.Pause();
                }
                else
                {
                    this.Video.Play();
                }
            }
        }
    }
}
