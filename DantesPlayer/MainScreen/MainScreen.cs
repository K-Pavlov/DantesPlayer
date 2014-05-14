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
    using UserFormComponents;
    #endregion
    public sealed partial class MainScreen : Form
    {
        #region Constant Values
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int volumeStep = 10;
        #endregion

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        public MenuBarFullScreenForm menuBar = new MenuBarFullScreenForm();
        public FormWindowState lastWindowState;
        private static int xPosition;
        private static int yPosition;
        private static Point formStartLocation;
        private static Point startMouseLocation;
        internal Timer timerForVideoTime = new Timer();
        internal Timer timerForRF = new Timer();
        internal Timer timerForVideoProgress = new Timer();
        internal Timer timerForMouseFormMovement = new Timer();
        internal Timer timerForMenuBar = new Timer();

        private Subtitles subtitles = new Subtitles();
        private SubtitleForm subForm = new SubtitleForm();
        private bool subWritten = false;
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

        /// <summary>
        /// Constructor - gets:
        /// -audio control instance and shows it
        /// - sets forms to top most
        /// </summary>
        private MainScreen()
        {
            buttonClicks = new ButtonClicks();
            buttonClicks.MainScreenInstance = this;
            buttonClicks.MainScreenInstance = this;
            this.Click += new System.EventHandler(this.SetTopMost);
            AudioControl = AudioFormControl.Instance;
            AudioControl.MainScreenInstance = this;
            this.AudioControl.VolumeProgress.Value = 50;
            AudioControl.Show();
            this.AudioControl.Owner = this;
            InitializeComponent();
            this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.subForm.Show();
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
            timerForVideoTime.Interval = 1000;
            timerForVideoTime.Tick += timerForVideoTime_Tick;
            timerForMouseFormMovement.Interval = 1;
            timerForMouseFormMovement.Tick += timerForMouseFormMovementTick;
            timerForRF.Interval = 1000;
            timerForRF.Tick += TimerForRF_Tick;
            timerForVideoProgress.Interval = 1000;
            timerForVideoProgress.Tick += TimerForVideoProgress_Tick;
            timerForMenuBar.Interval = 500;
            timerForMenuBar.Tick += timerForMenuBar_Tick;
            this.VideoSlider.Enabled = false;
        }

        void timerForMenuBar_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(this.IsActive(HolderForm.FormForVideo.Handle));
            if (CheckException.CheckNull(video.DirectVideo) && !HolderForm.FormForVideo.IsDisposed)
            {
                if (Cursor.Position.Y > Screen.PrimaryScreen.WorkingArea.Height - 100)
                {
                    if (!menuBar.IsDisposed)
                    {
                        if (this.IsActive(HolderForm.FormForVideo.Handle) || this.IsActive(menuBar.Handle))
                        {
                            menuBar.Show();
                            menuBar.BringToFront();
                            menuBar.TopMost = true;
                            Console.WriteLine(HolderForm.FormForVideo.TopLevel);
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
        public void WriteVideoTime()
        {
            this.label1.Text = String.Empty;
            double fullTime = this.video.DirectVideo.CurrentPosition;
            //this.label1.Text = "00:00:";
            //if (video.DirectVideo.CurrentPosition < 10)
            //{
            //    this.label1.Text += "0";
            //}
            //this.label1.Text += String.Format("{0:0}", video.DirectVideo.CurrentPosition);
            //this.label1.Text = this.label1.Text.Replace('.', ':');
            //this.label1.Text += String.Format("/00:00:{0:0}", video.DirectVideo.Duration);
            fixTime(fullTime, ref this.label1);
            this.label1.Text += "/";
            fixTime(this.video.DirectVideo.Duration, ref this.label1);
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

        private static void fixTime(double fullTime, ref Label label1)
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

        /// <summary>
        /// Fixes the slider and the video
        /// so they go correctly together;
        /// event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerForVideoProgress_Tick(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(video))
            {
                if (CheckException.CheckNull(video.DirectVideo))
                {
                    HolderForm.HandleVideoProgress(this.VideoSlider, video.DirectVideo);
                    if (subtitles.SubsLoaded && !video.DirectVideo.Disposed)
                    {
                        //while (subtitles.EndSubTime[this.subLine] < Convert.ToInt32(this.video.DirectVideo.CurrentPosition))
                        //{
                        //    if (this.subLine != this.subtitles.EndSubTime.Count - 1)
                        //    {
                        //        this.subLine++;
                        //    }
                        //    else
                        //    {
                        //        break;
                        //    }
                        //}

                        //if(subLine == 14)
                        //{
                        //    subForm.BringToFront();
                        //}

                        //if(this.subLine > this.subtitles.StartSubTime.Count)
                        //{
                        //    this.subLine -= 14;
                        //}

                        //while (subtitles.StartSubTime[this.subLine] > Convert.ToInt32(video.DirectVideo.CurrentPosition))
                        //{
                        //    this.subLine--;
                        //}
                        while (true)
                        {
                            if (subtitles.CheckSubEnded(Convert.ToInt32(this.video.DirectVideo.CurrentPosition), subtitles.EndSubTime[subLine]) && subWritten)
                            {
                                subForm.SubLabel.Text = String.Empty;
                                ///HolderForm.FormForVideo.SubLabel.Text = String.Empty;
                                subWritten = false;
                                if (subLine != subtitles.EndSubTime.Count - 1)
                                {
                                    subLine++;
                                }
                                else
                                {
                                    break;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }
                        if (subtitles.CheckPrint(Convert.ToInt32(this.video.DirectVideo.CurrentPosition), subtitles.StartSubTime[subLine]) && !subWritten)
                        {
                            if (this.subLine == this.subtitles.EndSubTime.Count - 1)
                            {
                                while (this.subtitles.CheckSubEnded(Convert.ToInt32(this.video.DirectVideo.CurrentPosition), subtitles.EndSubTime[subLine]))
                                {
                                    if (subLine == 0)
                                    {
                                        break;
                                    }
                                    subLine--;
                                }
                            }
                            subWritten = true;
                            subForm.SubLabel.Text = subtitles.Subtitle[subLine];
                            /// HolderForm.FormForVideo.SubLabel.Text = subtitles.Subtitle[subLine];
                        }
                    }
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
        private void TimerForRF_Tick(object sender, EventArgs e)
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

        public void DirectVideo_Ending(object sender, EventArgs e)
        {
            timerForVideoTime.Stop();
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