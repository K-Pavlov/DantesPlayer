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
    public sealed partial class MainScreen : Form
    {
        #region Constant Values
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int CS_DBLCLKS = 0x8;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int volumeStep = 10;
        #endregion
        #region Private Variables
        private static int xPosition;
        private static int yPosition;
        private static Point formStartLocation;
        private static Point startMouseLocation;
        private Button MinimizeButton;
        private Button ShowHideAudioButton;
        private static Timer timerForRF = new Timer();
        private static Timer timerForVideoProgress = new Timer();
        private static Timer timerForMouseFormMovement = new Timer();
        private static bool fastForwardFired = false;
        private static bool rewindFired = false;
        private static bool audioHidden = false;
        private static string videoName;
        private const string typeExpecption = "I can't play the video :(.";
        private AudioFormControl audioControl;
        #endregion 

        internal static Video video;

        #region SingletonImpelemntation
        private static Lazy<MainScreen> lazy =
            new Lazy<MainScreen>(() => new MainScreen());
        public static MainScreen Instance { get { return lazy.Value; } }

        private MainScreen()
        {
            //this.Click += new System.EventHandler(this.SetTopMost);
            audioControl = AudioFormControl.Instance;
            this.audioControl.TopMost = true;
            this.TopMost = true;
            audioControl.Show();
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Left + 100;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height/3;
            timerForMouseFormMovement.Interval = 1;
            timerForMouseFormMovement.Tick += timerForMouseFormMovementTick;
            timerForRF.Interval = 1000;
            timerForRF.Tick += timer_Tick;
            timerForVideoProgress.Interval = 1000;
            timerForVideoProgress.Tick += timerForVideoProgress_Tick;
            this.VideoSlider.Enabled = false;
        }

        private void timerForMouseFormMovementTick(object sender, EventArgs e)
        {
            xPosition = formStartLocation.X + Cursor.Position.X - startMouseLocation.X;
            yPosition = formStartLocation.Y + Cursor.Position.Y - startMouseLocation.Y;
            this.Location = new Point(xPosition, yPosition);
        }


        private void SetTopMost()
        {
            this.audioControl.TopMost = true;
            this.TopMost = true;
            //HolderForm.TopMost = false;
        }

        private void timerForVideoProgress_Tick(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                if (CheckException.CheckNull(video.DirectVideo))
                {
                    HolderForm.HandleVideoProgress(this.VideoSlider, video.DirectVideo);
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

        private void timer_Tick(object sender, EventArgs e)
        {
            if (fastForwardFired)
            {
                if (CheckException.CheckNull(video))
                {
                    video.FastForward();
                    if (video.Speed == 0)
                    {
                        timerForRF.Stop();
                    }
                }
            }
            
            if (rewindFired)
            {
                if (CheckException.CheckNull(video))
                {
                    video.Rewind();
                    if (video.Speed == 0)
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
                    this.VideoSlider.Enabled = true;
                }
                catch (TypeLoadException)
                {
                    MessageBox.Show(typeExpecption,"Warning");
                }
            }

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.Close();
                if (CheckException.CheckNull(video))
                {
                    video.CloseVideo();
                }
                this.Dispose();
        }

        /// <summary>
        /// Slider moves, video changes appropriately
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customSlider1_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                HolderForm.HandleBarMovemenet(this.VideoSlider, video.DirectVideo);
            }
        }

        /// <summary>
        /// Minimizes the forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion 

        #region ButtonOnClickStyles
        private void PauseButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.PauseButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                video.PauseVideo();
            }
            if (timerForRF.Enabled)
            {
                timerForRF.Stop();
                video.Speed = 0;
            }
        }

        private void StopButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.StopButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                timerForRF.Stop();
                video.StopVideo();
            }
        }

        private void RewindButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.RewindButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                timerForRF.Start();
                video.Speed -= 5;
                rewindFired = true;
            }
        }

        private void PlayButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.PlayButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                video.PlayVideo();
            }
            if (timerForRF.Enabled)
            {
                timerForRF.Stop();
                video.Speed = 0;
            }
        }

        private void FFButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.FFButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                timerForRF.Start();
                video.Speed += 5;
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
                video.OpenVideoInFullScreen();
            }
        }

        private void closeVideo_MouseDown(object sender, MouseEventArgs e)
        {
            this.closeVideo.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                video.CloseVideo();
                video = null;
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

        /// <summary>
        /// Disable maximize
        /// </summary>
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

        /// <summary>
        /// Make the main form draggable 
        /// /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == WM_LBUTTONDOWN)
            //{
              //  base.WndProc(ref m);
               // this.SetTopMost();
                //this.Location = Cursor.Position - new Size(250, -10);
                //return;
            //}
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                m.Result = IntPtr.Zero;
                return;
            }
            audioControl.Location = this.Location - new Size(301, -70);
            base.WndProc(ref m);
            //this.MinimumSize = this.MaximumSize;
        }
        #endregion

        private void ShowHideAudioButton_Click(object sender, EventArgs e)
        {
            
            if(!audioHidden)
            {
                this.audioControl.Hide();
                this.ShowHideAudioButton.Text = "Show";
                audioHidden = true;
                return;
            }
            this.audioControl.Show();
            this.ShowHideAudioButton.Text = "Hide";
            audioHidden = false;
        }

        private void MainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            this.SetTopMost();
            formStartLocation = this.Location;
            startMouseLocation = Cursor.Position;
            Console.WriteLine(Cursor.Position - new Size(this.Location));
            timerForMouseFormMovement.Start();
        }

        private void MainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            timerForMouseFormMovement.Stop();
        }

    }
}
