namespace MainScreen.VideoHandling
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using UserFormComponents;
    #endregion

    public class MenuBarFullScreenForm : Form
    {
        private Timer timerForVideoProgress;
        private CustomControls.CustomSlider videoSlider;
        private CustomControls.CustomButton pauseButton;
        private CustomControls.CustomButton stopButton;
        private CustomControls.CustomButton closeButton;
        private CustomControls.CustomButton playButton;
        public MainScreen mainScreenInstance;

        public MenuBarFullScreenForm()
        {
            this.timerForVideoProgress = new Timer();
            this.timerForVideoProgress.Interval = 1000;
            this.timerForVideoProgress.Tick += TimerForVideoProgress_Tick;
            this.InitializeComponent();
            this.ButtonClicks = new ButtonClicks();
            this.ButtonClicks.MainScreenInstance = this.MainScreenInstance;
        }

        /// <summary>
        /// Gets or sets the Main screen singleton instance 
        /// </summary>
        public MainScreen MainScreenInstance 
        { 
            get
            {
                return this.mainScreenInstance;
            }

            set
            {
                this.mainScreenInstance = value;
                this.timerForVideoProgress.Start();
            } 
        }
        

        /// <summary>
        /// Gets or sets the Buttons clicks instance
        /// </summary>
        private ButtonClicks ButtonClicks { get; set; }

        /// <summary>
        /// Occurs on video progress timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerForVideoProgress_Tick(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(MainScreenInstance.video))
            {
                if (CheckException.CheckNull(MainScreenInstance.video.DirectVideo))
                {
                    HolderForm.HandleVideoProgress(this.videoSlider, MainScreenInstance.video.DirectVideo);
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
        /// Override 
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void InitializeComponent()
        {
            this.videoSlider = new CustomControls.CustomSlider();
            this.closeButton = new CustomControls.CustomButton();
            this.playButton = new CustomControls.CustomButton();
            this.stopButton = new CustomControls.CustomButton();
            this.pauseButton = new CustomControls.CustomButton();
            this.SuspendLayout();
            // 
            // videoSlider
            // 
            this.videoSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.videoSlider.BackColor = System.Drawing.Color.Transparent;
            this.videoSlider.BorderColor = System.Drawing.Color.Transparent;
            this.videoSlider.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.videoSlider.IndentHeight = 10;
            this.videoSlider.Location = new System.Drawing.Point(167, -1);
            this.videoSlider.Maximum = 20;
            this.videoSlider.Minimum = 0;
            this.videoSlider.Name = "videoSlider";
            this.videoSlider.Size = new System.Drawing.Size(303, 30);
            this.videoSlider.TabIndex = 17;
            this.videoSlider.Text = "customSlider1";
            this.videoSlider.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.videoSlider.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.videoSlider.TickHeight = 4;
            this.videoSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.videoSlider.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.videoSlider.TrackerSize = new System.Drawing.Size(10, 10);
            this.videoSlider.TrackLineColor = System.Drawing.Color.DimGray;
            this.videoSlider.TrackLineHeight = 10;
            this.videoSlider.Value = 0;
            this.videoSlider.Click += new System.EventHandler(this.VideoSlider_Click);
            // 
            // closeButton
            // 
            this.closeButton.Image = global::MainScreen.Properties.Resources.buttonExit21;
            this.closeButton.Location = new System.Drawing.Point(548, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(29, 23);
            this.closeButton.TabIndex = 22;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click_1);
            // 
            // playButton
            // 
            this.playButton.Image = global::MainScreen.Properties.Resources.PlayButtonLast;
            this.playButton.Location = new System.Drawing.Point(23, -1);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(27, 23);
            this.playButton.TabIndex = 21;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click_1);
            // 
            // stopButton
            // 
            this.stopButton.Image = global::MainScreen.Properties.Resources.buttonStop21;
            this.stopButton.Location = new System.Drawing.Point(125, -1);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(27, 23);
            this.stopButton.TabIndex = 20;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click_1);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.Transparent;
            this.pauseButton.Image = global::MainScreen.Properties.Resources.buttonPause21;
            this.pauseButton.Location = new System.Drawing.Point(74, 0);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(28, 23);
            this.pauseButton.TabIndex = 19;
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // MenuBarFullScreenForm
            // 
            this.ClientSize = new System.Drawing.Size(589, 23);
            this.ControlBox = false;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.videoSlider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuBarFullScreenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Pauses the video
        /// </summary>
        /// <param name="sender">Method for</param>
        /// <param name="e">delegate </param>
        private void PauseButton_Click(object sender, EventArgs e)
        {
            this.ButtonClicks.MainScreenInstance = this.MainScreenInstance;
            this.ButtonClicks.PauseVideo(this.pauseButton);
        }

        /// <summary>
        /// Stops the video
        /// </summary>
        /// <param name="sender">Method for</param>
        /// <param name="e">delegate </param>
        private void StopButton_Click_1(object sender, EventArgs e)
        {
            this.ButtonClicks.StopVideo(this.stopButton);
        }

        /// <summary>
        /// Plays the video 
        /// </summary>
        /// <param name="sender">Method for</param>
        /// <param name="e">delegate </param>
        private void PlayButton_Click_1(object sender, EventArgs e)
        {
            this.ButtonClicks.PlayVideo(this.playButton);
        }

        /// <summary>
        /// Closes the full screen
        /// </summary>
        /// <param name="sender">Method for</param>
        /// <param name="e">delegate </param>
        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            HolderForm.FormForVideo.WindowState = FormWindowState.Normal;
            this.timerForVideoProgress.Stop();
            this.Dispose();
        }

        /// <summary>
        /// Occurs when videos lider value changes 
        /// </summary>
        /// <param name="sender">Method for</param>
        /// <param name="e">delegate </param>
        private void VideoSlider_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                HolderForm.HandleBarMovemenet(this.videoSlider, this.MainScreenInstance.video.DirectVideo);
            }
        }
    }
}
