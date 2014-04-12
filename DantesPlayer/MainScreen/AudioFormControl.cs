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
        public AudioFormControl()
        {
            InitializeComponent();
        }



        private void VolumeDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.VolumeDown.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(MainScreen.video))
            {
                MainScreen.video.VolumeDown(this.VolumeProgress);
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
            this.VolumeDown.FlatStyle = FlatStyle.Flat;
        }

        private void VolumeUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.VolumeUp.FlatStyle = FlatStyle.Popup;
            if (CheckException.CheckNull(MainScreen.video))
            {
                MainScreen.video.VolumeUp(this.VolumeProgress);
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
            this.VolumeUp.FlatStyle = FlatStyle.Flat;
        }

        private void VolumeProgress_ValueChanged(object sender, decimal value)
        {
            if (CheckException.CheckNull(MainScreen.video))
            {
                AudioForVideos.VolumeInit(MainScreen.video, this.VolumeProgress);
            }
        }
        
        private void VolumeInit()
        {
            AudioForVideos.VolumeInit(MainScreen.video, this.VolumeProgress);
        }
    }
}
