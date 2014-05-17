namespace MainScreen
{
    #region Namespaces
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using UserInterfaceDialogs;
    using VideoHandling;
    using AudioHandling;
    using UserFormComponents;
    #endregion
    public sealed partial class MainScreen : Form
    {
        #region Constant Values
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int volumeStep = 10;
        #endregion

        public Playlist playList = new Playlist();
        public MenuBarFullScreenForm menuBar = new MenuBarFullScreenForm();
        public FormWindowState lastWindowState;
        internal readonly Timer timerForRF = new Timer();
        internal readonly Timer timerForVideoProgress = new Timer();
        internal readonly Timer timerForMouseFormMovement = new Timer();
        internal readonly Timer timerForMenuBar = new Timer();
        internal readonly Timer timerForSubs = new Timer();
        internal readonly Timer timerForSubsSync = new Timer();
        private static int xPosition;
        private static int yPosition;
        private static Point formStartLocation;
        private static Point startMouseLocation;
        private Subtitles subtitles = new Subtitles();
        private SubtitleForm subForm = new SubtitleForm();
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        private ButtonClicks buttonClicks { get; set; }

        public AudioFormControl AudioControl { get; private set; }

        public bool fastForwardFired { get; set; }

        public bool rewindFired { get; set; }

        private int subLine = 0;

        public Label GetLabel()
        {
            return this.label1;
        }

        public CustomControls.CustomSlider GetSlider()
        {
            return this.VideoSlider;
        }

        public Video video { get; set; }

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

        public static MainScreen GetInstance()
        {
            return lazy.Value;
        }

        /// <summary>
        /// Constructor - gets:
        /// -audio control instance and shows it
        /// - sets forms to top most
        /// </summary>
        private MainScreen()
        {
            this.buttonClicks = new ButtonClicks();
            this.buttonClicks.MainScreenInstance = this;
            this.buttonClicks.MainScreenInstance = this;
            this.playList.MainScreenInstance = this;
            this.Click += new System.EventHandler(this.SetTopMost);
            this.AudioControl = AudioFormControl.Instance;
            this.AudioControl.MainScreenInstance = this;
            this.AudioControl.VolumeProgress.Value = 50;
            this.AudioControl.Show();
            this.AudioControl.Owner = this;
            this.InitializeComponent();
            this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.subForm.Show();
            this.menuBar.mainScreenInstance = this;
            this.subForm.BringToFront();
            //this.TransparencyKey = Color.WhiteSmoke;
            //this.BackColor = System.Drawing.Color.Transparent;
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
            this.timerForMouseFormMovement.Interval = 1;
            this.timerForMouseFormMovement.Tick += this.TimerForMouseFormMovementTick;
            this.timerForRF.Interval = 1000;
            this.timerForRF.Tick += this.TimerForRF_Tick;
            this.timerForVideoProgress.Interval = 1000;
            this.timerForVideoProgress.Tick += this.TimerForVideoProgress_Tick;
            this.timerForVideoProgress.Tick += this.TimerForVideoTime_Tick;
            this.timerForMenuBar.Interval = 500;
            this.timerForMenuBar.Tick += this.TimerForMenuBar_Tick;
            this.timerForSubs.Interval = 500;
            this.timerForSubs.Tick += this.CheckSubs;
            this.timerForSubsSync.Interval = 1;
            this.timerForSubsSync.Tick += this.SyncSubtitles;
            this.VideoSlider.Enabled = false;
        }

        private void SyncSubtitles(object sender, EventArgs e)
        {
            int xLocation = HolderForm.FormForVideo.Location.X;
            int yLocation = HolderForm.FormForVideo.Location.Y;
            int xSize = HolderForm.FormForVideo.Size.Width;
            int ySize = HolderForm.FormForVideo.Size.Height;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height / 1.2);
            const double ScreenToSubRatio = 3.7;
            if (this.video.DirectVideo != null)
            {
                if (video.IsFullScreen)
                {
                    subForm.Location = new Point(Convert.ToInt32(screenWidth / ScreenToSubRatio), screenHeight);
                    return;
                }
                this.subForm.Location = new Point(Convert.ToInt32(xSize - xLocation), ySize - yLocation);
                this.subForm.Size = HolderForm.FormForVideo.Size;
            }
            else
            {
                this.timerForSubsSync.Stop();
            }
        }

        private void TimerForMenuBar_Tick(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            const int MenuBarPadding = 100;
            const double ScreenToMenuBarRatio = 3.7;
            //Console.WriteLine(this.IsActive(HolderForm.FormForVideo.Handle));
            if (CheckException.CheckNull(video.DirectVideo) && !HolderForm.FormForVideo.IsDisposed)
            {
                if (Cursor.Position.Y > screenHeight - MenuBarPadding)
                {
                    if (!menuBar.IsDisposed)
                    {
                        if (this.IsActive(HolderForm.FormForVideo.Handle) || this.IsActive(menuBar.Handle) || this.IsActive(this.subForm.Handle))
                        {
                            menuBar.Show();
                            menuBar.BringToFront();
                            menuBar.TopMost = true;
                            //Console.WriteLine(HolderForm.FormForVideo.TopLevel);
                            menuBar.Location = new Point(Convert.ToInt32(screenWidth / ScreenToMenuBarRatio), screenHeight - 50);
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
                if (HolderForm.FormForVideo.IsDisposed)
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
        public void ClearTimers(object sender, EventArgs e)
        {
            timerForVideoProgress.Stop();
            timerForRF.Stop();
        }

        /// <summary>
        /// Calls the method that writes the video time; method for event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerForVideoTime_Tick(object sender, EventArgs e)
        {
            this.timerForSubs.Start();
            this.timerForSubsSync.Start();
            this.WriteVideoTime();
        }


        /// <summary>
        /// Writes to a label where the video is
        /// at the given moment
        /// </summary>
        public void WriteVideoTime()
        {
            this.label1.Text = String.Empty;
            double fullTime = this.video.DirectVideo.CurrentPosition;
            FixTime(fullTime, ref this.label1);
            this.label1.Text += "/";
            FixTime(this.video.DirectVideo.Duration, ref this.label1);
        }

        /// <summary>
        /// On left mouse hold and movement in the form
        /// moves the form with the mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerForMouseFormMovementTick(object sender, EventArgs e)
        {
            xPosition = formStartLocation.X + Cursor.Position.X - startMouseLocation.X;
            yPosition = formStartLocation.Y + Cursor.Position.Y - startMouseLocation.Y;
            this.Location = new Point(xPosition, yPosition);
        }

        private static void FixTime(double fullTime, ref Label label1)
        {
            int hourParse = 3600;
            int minuteParse = 60;
            int hours = (int)Math.Floor(fullTime / hourParse);
            fullTime -= hours * hourParse;
            int minutes = (int)Math.Floor(fullTime / minuteParse);
            fullTime -= minutes * minuteParse;
            int seconds = (int)Math.Floor(fullTime);

            if (hours < 10)
            {
                label1.Text += "0";
            }

            label1.Text += hours.ToString() + ':';
            if (minutes < 10)
            {
                label1.Text += '0';
            }

            label1.Text += minutes.ToString() + ':';
            if (seconds < 10)
            {
                label1.Text += '0';
            }
            label1.Text += seconds.ToString();
        }

        /// <summary>
        /// Sets the main and audio form to top most
        /// </summary>
        private void SetTopMost(object sender, EventArgs e)
        {
            AudioControl.BringToFront();
        }

        private void TimerForVideoProgress_Tick(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                if (CheckException.CheckNull(video.DirectVideo))
                {
                    HolderForm.HandleVideoProgress(this.VideoSlider, this.video.DirectVideo);
                }
                else
                {
                    this.timerForSubs.Stop();
                    this.timerForSubsSync.Stop();
                    this.timerForVideoProgress.Stop();
                }
            }
            else
            {
                this.timerForSubs.Stop();
                this.timerForSubsSync.Stop();
                this.timerForVideoProgress.Stop();
            }
        }

        private void CheckSubs(object sender, EventArgs e)
        {
            if (subtitles.SubsLoaded && !video.DirectVideo.Disposed)
            {
                //while (true)
                //{
                //    if (this.subtitles.CheckSubEnded(Convert.ToInt32(this.video.DirectVideo.CurrentPosition), this.subtitles.EndSubTime[subLine]) && this.subWritten)
                //    {
                //        this.subForm.SubLabel.Text = String.Empty;
                //        this.subWritten = false;
                //        if (this.subLine != this.subtitles.EndSubTime.Count - 1)
                //        {
                //            this.subLine++;
                //        }
                //        else
                //        {
                //            break;
                //        }
                //    }
                //    else
                //    {
                //        break;
                //    }
                //}

                //if (this.subtitles.CheckPrint(Convert.ToInt32(this.video.DirectVideo.CurrentPosition), this.subtitles.StartSubTime[subLine]) && !this.subWritten)
                //{
                //    if (this.subLine == this.subtitles.EndSubTime.Count - 1)
                //    {
                //        while (this.subtitles.CheckSubEnded(Convert.ToInt32(this.video.DirectVideo.CurrentPosition), this.subtitles.EndSubTime[subLine]))
                //        {
                //            if (this.subLine == 0)
                //            {
                //                break;
                //            }

                //            this.subLine--;
                //        }
                //    }

                //    this.subWritten = true;
                //    this.subForm.SubLabel.Text = subtitles.Subtitle[subLine];
                //}
                this.subForm.SubLabel.Text = pickSub(Convert.ToInt32(this.video.DirectVideo.CurrentPosition), this.subtitles);
            }
        }

        private static string pickSub(int currentVideoTime, Subtitles subtitles)
        {
            string correctSubtitle = "";
            for (int i = 0; i < subtitles.SubtitleLinesTotal; i++)
            {
                if(currentVideoTime >= subtitles.StartSubTime[i] && currentVideoTime <= subtitles.EndSubTime[i])
                {
                    correctSubtitle = subtitles.Subtitle[i];
                }
            }

            return correctSubtitle;
        }

        /// <summary>
        /// rewind and fast forward fix up;
        /// event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerForRF_Tick(object sender, EventArgs e)
        {
            if (fastForwardFired)
            {
                if (CheckException.CheckNull(video))
                {
                    video.FastForward();
                    if (video.PlayBackSpeed == 0)
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
                    if (video.PlayBackSpeed == 0)
                    {
                        timerForRF.Stop();
                    }
                }
            }
        }

        public void DirectVideo_Ending(object sender, EventArgs e)
        {
            timerForVideoProgress.Stop();
            timerForMenuBar.Stop();
        }

        /// <summary>
        /// Slider moves, video changes appropriately
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomSlider1_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                HolderForm.HandleBarMovemenet(this.VideoSlider, video.DirectVideo);
            }
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
            timerForMouseFormMovement.Start();
        }

        private void MainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            timerForMouseFormMovement.Stop();
        }

        #endregion

        #region ButtonOnClickStyles
        private void PlayButton_MouseDown_1(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.PlayButton);
        }

        private void PauseButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.PauseButton);
        }

        private void RewindButton1_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.RewindButton);
        }

        private void FFButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.FFButton);
        }

        private void StopButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.StopButton);
        }

        private void OpenVideoButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.OpenVideoButton);
        }

        private void MinimizeButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.MinimizeButton);
        }

        private void ExitButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.ExitButton);
        }

        private void FullScreenButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.FullScreenButton);
        }

        private void CloseVideoButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(CloseVideoButton);
        }

        private void HideShowAudioFormButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonClicks.SwitchButtonStyle(this.HideShowAudioFormButton);
        }

        private void PlayButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.PlayVideo(this.PlayButton);
            //this.Focus();
        }
        private void Subs_Button_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.LoadSubs(this.Subs_Button, this.subtitles);
        }
        private void PlaylistButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.OpenPlaylist(this.PlaylistButton);
        }

        private void PauseButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.PauseVideo(this.PauseButton);
        }

        private void StopButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.StopVideo(this.StopButton);
        }

        private void FFButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.FFVideo(this.FFButton);
        }

        private void RewindButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.RewindVideo(this.RewindButton);
        }

        private void OpenVideoButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.OpenVideo(this.OpenVideoButton);
            if(this.video != null)
            {
                this.subForm.Location = HolderForm.FormForVideo.Location;
                this.subForm.Size = HolderForm.FormForVideo.Size;
            }
        }

        private void FullScreenButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.FullScreenVideo(this.FullScreenButton);
        }

        private void CloseVideoButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.CloseVideo(this.CloseVideoButton);
        }

        private void HideShowAudioFormButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.ShowHideAudioForm(this.HideShowAudioFormButton);
        }

        private void MinimizeButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.MinimizeForm(this.MinimizeButton);
        }

        private void ExitButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttonClicks.ExitVideoPlayer(this.ExitButton);
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
            AudioControl.Location = this.Location - new Size(250, -100);
            base.WndProc(ref m);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (this.WindowState != lastWindowState)
            {
                if (lastWindowState == FormWindowState.Minimized)
                {
                    this.AudioControl.BringToFront();
                    this.AudioControl.Show();
                }
                lastWindowState = this.WindowState;
            }
            base.OnClientSizeChanged(e);
        }
        #endregion

        public bool IsActive(IntPtr handle)
        {
            IntPtr activeHandle = GetForegroundWindow();
            return (activeHandle == handle);
        }

        
    }
}