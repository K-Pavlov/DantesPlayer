namespace MainScreen
{
    #region Namespaces
    using System;
    using System.Runtime.InteropServices;
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
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int volumeStep = 10;
        #endregion

        #region Private Variables
        private static MenuBarFullScreenForm menuBar = new MenuBarFullScreenForm();
        private static FormWindowState lastWindowState;
        private static int xPosition;
        private static int yPosition;
        private static Point formStartLocation;
        private static Point startMouseLocation;
        private Button ShowHideAudioButton;
        internal static Timer timerForVideoTime = new Timer();
        internal static Timer timerForRF = new Timer();
        internal static Timer timerForVideoProgress = new Timer();
        internal static Timer timerForMouseFormMovement = new Timer();
        internal static Timer timerForMenuBar = new Timer();
        private static bool fastForwardFired = false;
        private static bool rewindFired = false;
        private static bool audioHidden = false;
        private static string videoName;
        private const string typeExpecption = "I can't play the video :(.";
        private AudioFormControl audioControl;
        #endregion

        internal static Video video;

        #region SingletonImpelemntation
        /// <summary>
        /// Thread safe c# singleton ~~ lazy right?
        /// </summary>
        private static Lazy<MainScreen> lazy =
            new Lazy<MainScreen>(() => new MainScreen());

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static MainScreen Instance { get { return lazy.Value; } }
        /// <summary>
        /// Constructor - gets:
        /// -audio control instance and shows it
        /// - sets forms to top most
        /// </summary>
        private MainScreen()
        {
            //   this.Activated += MainScreen_Activated;
            //  this.Deactivate += MainScreen_Deactivate;
            this.Enter += MainScreen_Enter;
            this.Click += new System.EventHandler(this.SetTopMost);
            audioControl = AudioFormControl.Instance;
            this.audioControl.VolumeProgress.Value = 50;
            audioControl.Show();
            this.audioControl.Owner = this;
            this.GotFocus += MainScreen_GotFocus;
            InitializeComponent();
        }

        void MainScreen_Enter(object sender, EventArgs e)
        {
        }

        void MainScreen_GotFocus(object sender, EventArgs e)
        {
            this.audioControl.BringToFront();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// On load gives the form a nice starting position
        /// the intervals for the timers and gives their
        /// tick events a method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Left + Screen.PrimaryScreen.WorkingArea.Right / 4;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height / 2;
            timerForVideoTime.Interval = 1000;
            timerForVideoTime.Tick += timerForVideoTime_Tick;
            timerForMouseFormMovement.Interval = 1;
            timerForMouseFormMovement.Tick += timerForMouseFormMovementTick;
            timerForRF.Interval = 1000;
            timerForRF.Tick += timer_Tick;
            timerForVideoProgress.Interval = 1000;
            timerForVideoProgress.Tick += timerForVideoProgress_Tick;
            //timerForVideoProgress.Tick += MenuBarFullScreenForm.timerForVideoProgress_Tick;
            timerForMenuBar.Interval = 500;
            timerForMenuBar.Tick += timerForMenuBar_Tick;
            this.VideoSlider.Enabled = false;
        }

        void timerForMenuBar_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(this.IsActive(HolderForm.holderForm.Handle));
            if (CheckException.CheckNull(video.DirectVideo) && !HolderForm.holderForm.IsDisposed)
            {
                if (Cursor.Position.Y > Screen.PrimaryScreen.WorkingArea.Height - 100)
                {
                    if (!menuBar.IsDisposed)
                    {
                        if (this.IsActive(HolderForm.holderForm.Handle) || this.IsActive(menuBar.Handle))
                        {
                            menuBar.Show();
                            menuBar.BringToFront();
                            menuBar.TopMost = true;
                            Console.WriteLine(HolderForm.holderForm.TopLevel);
                            menuBar.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 3, Screen.PrimaryScreen.WorkingArea.Height - 40);
                        }
                    }
                    else
                    {
                        timerForMenuBar.Stop();
                        menuBar = null;
                    }
                }
                else
                {
                    menuBar.Hide();
                }
            }
            else
            {
                if (HolderForm.holderForm.IsDisposed)
                {
                    timerForVideoProgress.Stop();
                }
                timerForMenuBar.Stop();
                menuBar.Dispose();
                menuBar = null;
            }
        }

        /// <summary>
        /// clears all timers except click timer, method for event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearTimers(object sender, EventArgs e)
        {
            timerForVideoProgress.Stop();
            timerForRF.Stop();
            timerForVideoTime.Stop();
        }

        /// <summary>
        /// Calls the method that writes the video time; method for event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerForVideoTime_Tick(object sender, EventArgs e)
        {
            this.WriteVideoTime();
        }


        /// <summary>
        /// Writes to a label where the video is
        /// at the given moment
        /// </summary>
        private void WriteVideoTime()
        {
            this.label1.Text = "00:00:";
            if (video.DirectVideo.CurrentPosition < 10)
            {
                this.label1.Text += "0";
            }
            this.label1.Text += String.Format("{0:0}", video.DirectVideo.CurrentPosition);
            this.label1.Text = this.label1.Text.Replace('.', ':');
            this.label1.Text += String.Format("/00:00:{0:0}", video.DirectVideo.Duration);
        }

        /// <summary>
        /// On left mouse hold and movement in the form
        /// moves the form with the mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerForMouseFormMovementTick(object sender, EventArgs e)
        {
            xPosition = formStartLocation.X + Cursor.Position.X - startMouseLocation.X;
            yPosition = formStartLocation.Y + Cursor.Position.Y - startMouseLocation.Y;
            this.Location = new Point(xPosition, yPosition);
        }

        /// <summary>
        /// Sets the main and audio form to top most
        /// </summary>
        private void SetTopMost(object sender, EventArgs e)
        {
            audioControl.BringToFront();
        }

        /// <summary>
        /// Fixes the slider and the video
        /// so they go correctly together;
        /// event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// rewind and fast forward fix up;
        /// event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Opens a dialog and starts the chosen video
        /// DIRECT VIDEO ENDING DELEGATE IS GIVEN THE CLEAR TIMERS HERE
        /// event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void DirectVideo_Ending(object sender, EventArgs e)
        {
            timerForVideoTime.Stop();
            timerForVideoProgress.Stop();
            timerForMenuBar.Stop();
        }

        /// <summary>
        /// Closes the video, stopping the needed timers;
        /// event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Shows or hides the audio controls; event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHideAudioButton_Click(object sender, EventArgs e)
        {

            if (!audioHidden)
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

        /// <summary>
        /// Sets the forms to top most and starts 
        /// dragging the form with the mouse;
        /// event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            formStartLocation = this.Location;
            startMouseLocation = Cursor.Position;
            Console.WriteLine(Cursor.Position - new Size(this.Location));
            timerForMouseFormMovement.Start();
        }

        private void MainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            timerForMouseFormMovement.Stop();
        }

        #endregion

        #region ButtonOnClickStyles
        /// <summary>
        /// Pauses the video and stops the
        /// ff/rw timers and the video time timer;
        /// event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// stops the video and stops the
        /// rw/ff timer and the video time timer;
        /// event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// starts rewinding; event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// if the video is paused, plays the video
        /// and vice versa, STOPS the rw/ff timers
        /// starts the video time timer; event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButton_MouseDown(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// starts the ff/rw timer with a new value; delegate method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void StopButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.StopButton.FlatStyle = FlatStyle.Flat;
        }

        private void RewindButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.PauseButton.FlatStyle = FlatStyle.Flat;
        }

        private void PauseButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.PauseButton.FlatStyle = FlatStyle.Flat;
        }

        private void PlayButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.PlayButton.FlatStyle = FlatStyle.Flat;
        }

        /// <summary>
        /// starts the rw/ff timer with a modified value; event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void FullScreen_MouseDown(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// closes the video and its form
        /// stops all timers but the click timer
        /// fixes the label text; event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeVideo_MouseDown(object sender, MouseEventArgs e)
        {
        }
        #endregion

        #region Protected Methods

        /// <summary>
        /// Disable double click maximize
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                m.Result = IntPtr.Zero;
                return;
            }
            audioControl.Location = this.Location - new Size(250, -100);
            base.WndProc(ref m);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (this.WindowState != lastWindowState)
            {
                if (lastWindowState == FormWindowState.Minimized)
                {
                    this.audioControl.BringToFront();
                    this.audioControl.Show();
                }
                lastWindowState = this.WindowState;
            }
            base.OnClientSizeChanged(e);
        }
        #endregion
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public bool IsActive(IntPtr handle)
        {
            IntPtr activeHandle = GetForegroundWindow();
            return (activeHandle == handle);
        }

        private void PlayButton_MouseDown_1(object sender, MouseEventArgs e)
        {
            this.PlayButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                if (!timerForVideoTime.Enabled)
                {
                    timerForVideoTime.Start();
                }
                video.PlayVideo();
            }
            if (timerForRF.Enabled)
            {
                timerForRF.Stop();
                video.Speed = 0;
            }
        }

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
            if (timerForVideoTime.Enabled)
            {
                timerForVideoTime.Stop();
            }
        }

        private void RewindButton1_MouseDown(object sender, MouseEventArgs e)
        {
            this.PauseButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                timerForRF.Start();
                video.Speed -= 5;
                rewindFired = true;
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

        private void StopButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.StopButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(video))
            {
                timerForRF.Stop();
                video.StopVideo();
            }
            if (timerForVideoTime.Enabled)
            {
                timerForVideoTime.Stop();
                this.WriteVideoTime();
            }
        }

        private void MinimizeButton_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.audioControl.Hide();
            lastWindowState = this.WindowState;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            if (CheckException.CheckNull(video))
            {
                video.CloseVideo();
            }
            this.Dispose();
        }

        private void OpenVideoButton_MouseDown(object sender, MouseEventArgs e)
        {
            videoName = ChooseVideoDialog.TakePathToVideo();
            if (CheckException.CheckNull(videoName))
            {
                try
                {
                    if (video == null)
                    {
                        video = new Video(videoName, false, 800, 600);
                        video.StartVideo();
                        timerForVideoTime.Start();
                        timerForVideoProgress.Start();
                        video.DirectVideo.Ending += DirectVideo_Ending;
                        this.VideoSlider.Enabled = true;
                        AudioForVideos.VolumeInit(video, this.audioControl.VolumeProgress);
                        video.DirectVideo.Ending += clearTimers;
                    }
                    else
                    {
                        HolderForm.NullVideoAndForm(video.DirectVideo);
                        video = null;
                        video = new Video(videoName, false, 800, 600);
                        video.StartVideo();
                        timerForVideoTime.Start();
                        timerForVideoProgress.Start();
                        this.VideoSlider.Enabled = true;
                        AudioForVideos.VolumeInit(video, this.audioControl.VolumeProgress);
                        video.DirectVideo.Ending += clearTimers;
                    }
                }
                catch (Microsoft.DirectX.DirectXException)
                {
                    MessageBox.Show(typeExpecption, "Warning");
                }

            }
        }

        private void FullScreenButton_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                video.OpenVideoInFullScreen();
                video.isFullScreen = true;
            }
            if (video.isFullScreen)
            {
                menuBar = new MenuBarFullScreenForm();
                timerForMenuBar.Start();
            }
        }

        private void CloseVideoButton_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                HolderForm.NullVideoAndForm(video.DirectVideo);
            }
            this.VideoSlider.Value = 0;
            this.VideoSlider.Enabled = false;
            timerForVideoTime.Stop();
            this.label1.Text = "";
        }

    }
}

