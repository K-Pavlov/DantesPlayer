using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainScreen.AudioHandling;
using MainScreen.VideoHandling;

namespace MainScreen
{
    public partial class AudioFormControl : Form
    {
        private const int VolumeStep = 10;

        #region SingletonImpelementation
        private static Lazy<AudioFormControl> lazy =
            new Lazy<AudioFormControl>(() => new AudioFormControl());

        public static AudioFormControl Instance { get { return lazy.Value; } }

        private AudioFormControl()
        {
            this.ShowInTaskbar = false;
            this.Click += new System.EventHandler(this.SetTopMost);
            InitializeComponent();
            this.volumeDownButton.Click += this.VolumeDown_MouseDown;
            this.VolumeUpButton.Click += this.VolumeUp_MouseDown;
        }
        #endregion

        public MainScreen MainScreenInstance { get; set; }

        /// <summary>
        /// Remove from task manager, property override
        /// </summary>
        /// 
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
                return cp;
            }
        }

        private void SetTopMost(object sender, EventArgs e)
        {
            this.BringToFront();
            //this.TopMost = true;
            //ApplicationSetUp.mainScreen.TopMost = true;
        }

        private void VolumeDown_MouseDown(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(this.MainScreenInstance.video) &&
                CheckException.CheckNull(this.MainScreenInstance.video.DirectVideo))
            {
                this.MainScreenInstance.video.VolumeDown(this.VolumeProgress);
            }
            else if (CheckException.CheckNull(this.MainScreenInstance.audio) &&
                CheckException.CheckNull(this.MainScreenInstance.audio.DirectAudio))
            {
                this.MainScreenInstance.audio.VolumeDown(this.VolumeProgress);
            }
            else
            {
                if (this.VolumeProgress.Value > this.VolumeProgress.Minimum)
                {
                    this.VolumeProgress.Value -= VolumeStep;
                }
            }
        }

        private void VolumeDown_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void VolumeUp_MouseDown(object sender, EventArgs e)
        {
            if (CheckException.CheckNull(MainScreenInstance.video))
            {
                MainScreenInstance.video.VolumeUp(this.VolumeProgress);
            }
            else if (CheckException.CheckNull(this.MainScreenInstance.audio) &&
            CheckException.CheckNull(this.MainScreenInstance.audio.DirectAudio))
            {
                this.MainScreenInstance.audio.VolumeUp(this.VolumeProgress);
            }
            else
            {
                if (this.VolumeProgress.Value < this.VolumeProgress.Maximum)
                {
                    this.VolumeProgress.Value += VolumeStep;
                }
            }
        }

        private void VolumeUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.VolumeUpButton.FlatStyle = FlatStyle.Flat;
        }

        private void VolumeProgress_ValueChanged(object sender, decimal value)
        {
            if (CheckException.CheckNull(MainScreenInstance.video) &&
                CheckException.CheckNull(MainScreenInstance.video.DirectVideo))
            {
                AudioControl.VolumeInit(
                    MainScreenInstance.video.DirectVideo.Audio,
                    this.VolumeProgress);
            }

            if(CheckException.CheckNull(MainScreenInstance.audio) &&
                CheckException.CheckNull(
                MainScreenInstance.audio.DirectAudio))
            {
                AudioControl.VolumeInit(
                    MainScreenInstance.audio.DirectAudio, this.VolumeProgress);
            }
        }
        
        private void VolumeInit()
        {
            AudioControl.VolumeInit(
                MainScreenInstance.video.DirectVideo.Audio,
                this.VolumeProgress);
        }
    }
}
