using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainScreen.VideoHandling
{
    public class MenuBarFullScreenForm : Form
    {
        private static Timer timerForVideoProgress = new Timer();
        private static CustomControls.CustomSlider VideoSlider;
        private CustomControls.CustomButton PauseButton;
        private CustomControls.CustomButton StopButton;
        private CustomControls.CustomButton CloseButton;
        private CustomControls.CustomButton PlayButton;

        public MenuBarFullScreenForm()
        {
            timerForVideoProgress.Interval = 1000;
            timerForVideoProgress.Tick += timerForVideoProgress_Tick;
            this.InitializeComponent();
        }

        internal static void timerForVideoProgress_Tick(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(MainScreen.video))
            {
                if (CheckException.CheckNull(MainScreen.video.DirectVideo))
                {
                    HolderForm.HandleVideoProgress(VideoSlider, MainScreen.video.DirectVideo);
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
                return cp;
            }
        }

        private void InitializeComponent()
        {
            VideoSlider = new CustomControls.CustomSlider();
            this.CloseButton = new CustomControls.CustomButton();
            this.PlayButton = new CustomControls.CustomButton();
            this.StopButton = new CustomControls.CustomButton();
            this.PauseButton = new CustomControls.CustomButton();
            this.SuspendLayout();
            // 
            // VideoSlider
            // 
            VideoSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            VideoSlider.BackColor = System.Drawing.Color.Transparent;
            VideoSlider.BorderColor = System.Drawing.Color.Transparent;
            VideoSlider.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VideoSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            VideoSlider.IndentHeight = 10;
            VideoSlider.Location = new System.Drawing.Point(174, -5);
            VideoSlider.Maximum = 20;
            VideoSlider.Minimum = 0;
            VideoSlider.Name = "VideoSlider";
            VideoSlider.Size = new System.Drawing.Size(303, 30);
            VideoSlider.TabIndex = 18;
            VideoSlider.Text = "customSlider1";
            VideoSlider.TextTickStyle = System.Windows.Forms.TickStyle.None;
            VideoSlider.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            VideoSlider.TickHeight = 4;
            VideoSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            VideoSlider.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            VideoSlider.TrackerSize = new System.Drawing.Size(10, 10);
            VideoSlider.TrackLineColor = System.Drawing.Color.DimGray;
            VideoSlider.TrackLineHeight = 10;
            VideoSlider.Value = 0;
            VideoSlider.ValueChanged += new CustomControls.CustomSlider.ValueChangedHandler(VideoSlider_ValueChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Image = global::MainScreen.Properties.Resources.buttonExit21;
            this.CloseButton.Location = new System.Drawing.Point(548, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(29, 23);
            this.CloseButton.TabIndex = 22;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click_1);
            // 
            // PlayButton
            // 
            this.PlayButton.Image = global::MainScreen.Properties.Resources.PlayButtonLast;
            this.PlayButton.Location = new System.Drawing.Point(23, -1);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(27, 23);
            this.PlayButton.TabIndex = 21;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click_1);
            // 
            // StopButton
            // 
            this.StopButton.Image = global::MainScreen.Properties.Resources.buttonStop21;
            this.StopButton.Location = new System.Drawing.Point(125, -1);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(27, 23);
            this.StopButton.TabIndex = 20;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click_1);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.Transparent;
            this.PauseButton.Image = global::MainScreen.Properties.Resources.buttonPause21;
            this.PauseButton.Location = new System.Drawing.Point(74, 0);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(28, 23);
            this.PauseButton.TabIndex = 19;
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // MenuBarFullScreenForm
            // 
            this.ClientSize = new System.Drawing.Size(589, 23);
            this.ControlBox = false;
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(VideoSlider);
            this.Name = "MenuBarFullScreenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
        }

        private void VideoSlider_ValueChanged(object sender, decimal value)
        {
            if (CheckException.CheckNull(MainScreen.video))
            {
                HolderForm.HandleBarMovemenet(VideoSlider, MainScreen.video.DirectVideo);
            }
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(MainScreen.video))
            {
                MainScreen.video.PauseVideo();
            }
            if (MainScreen.timerForRF.Enabled)
            {
                MainScreen.timerForRF.Stop();
                MainScreen.video.Speed = 0;
            }
            if (MainScreen.timerForVideoTime.Enabled)
            {
                MainScreen.timerForVideoTime.Stop();
            }
        }

        private void StopButton_Click_1(object sender, EventArgs e)
        {
            this.StopButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(MainScreen.video))
            {
                MainScreen.timerForRF.Stop();
                MainScreen.video.StopVideo();
            }
            if (MainScreen.timerForVideoTime.Enabled)
            {
                MainScreen.timerForVideoTime.Stop();
            }
        }

        private void PlayButton_Click_1(object sender, EventArgs e)
        {
            this.PlayButton.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(MainScreen.video))
            {
                if (!MainScreen.timerForVideoTime.Enabled)
                {
                    MainScreen.timerForVideoTime.Start();
                }
                MainScreen.video.PlayVideo();
            }
            if (MainScreen.timerForRF.Enabled)
            {
                MainScreen.timerForRF.Stop();
                MainScreen.video.Speed = 0;
            }
        }

        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            HolderForm.holderForm.WindowState = FormWindowState.Normal;
            this.Dispose();
        }


    }
}
