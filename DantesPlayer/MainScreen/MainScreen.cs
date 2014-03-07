using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MainScreen
{
    public partial class MainScreen : Form
    {
        static int i = 0;
        //Hardcoded video, try one yourselves
        SmallVideo video = new SmallVideo(
            "C:\\Users\\kalo\\Downloads\\Saw.IV.2007.BRRip.XviD.AC3-ViSiON\\SawIV.avi", true, 1020,1020);
        public MainScreen()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Needs to be fixed will play
        /// a hardcoded video for now
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                video.StartVideo();
                i++;
            }
            else
            {
                video.PlayVideo();
            }
        }
        
        private void StopButton_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// When button pause is clicked pauses
        /// the video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseButton_Click(object sender, EventArgs e)
        {
            video.PauseVideo();
        }

    }
}
