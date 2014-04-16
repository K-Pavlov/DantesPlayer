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
        private Button PlayButton;
        private Button StopButton;
        private static Timer timerForVideoProgress = new Timer();
        private static CustomControls.CustomSlider VideoSlider;
        private Button CloseButton;

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
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            VideoSlider = new CustomControls.CustomSlider();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(12, 31);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(80, 20);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(114, 31);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(80, 20);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(322, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(20, 20);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "x";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // VideoSlider
            // 
            VideoSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            VideoSlider.BackColor = System.Drawing.Color.Transparent;
            VideoSlider.BorderColor = System.Drawing.Color.Transparent;
            VideoSlider.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VideoSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            VideoSlider.IndentHeight = 10;
            VideoSlider.Location = new System.Drawing.Point(-1, 0);
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
            // MenuBarFullScreenForm
            // 
            this.ClientSize = new System.Drawing.Size(354, 63);
            this.ControlBox = false;
            this.Controls.Add(VideoSlider);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PlayButton);
            this.Name = "MenuBarFullScreenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PlayButton_Click(object sender, EventArgs e)
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

        private void StopButton_Click(object sender, EventArgs e)
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            HolderForm.holderForm.WindowState = FormWindowState.Normal;
            this.Dispose();
        }

        private void VideoSlider_ValueChanged(object sender, decimal value)
        {
            if (CheckException.CheckNull(MainScreen.video))
            {
                HolderForm.HandleBarMovemenet(VideoSlider, MainScreen.video.DirectVideo);
            }
        }


    }
}
