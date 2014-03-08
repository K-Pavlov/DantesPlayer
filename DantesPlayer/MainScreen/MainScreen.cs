using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainScreen.VideoHandling;

namespace MainScreen
{
    public partial class MainScreen : Form
    {
        static int i = 0;
        //Hardcoded video, try one yourselves
        private SmallVideo video;
        public MainScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Left + 100;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height/3;
        }
        /// <summary>
        /// Needs to be fixed will play
        /// a hardcoded video for now
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (this.video != null)
            {
                this.video.PlayVideo();
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
            if (this.video != null)
            {
                video.PauseVideo();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            video = new SmallVideo(openFileDialog1.FileName , true, 1020, 1020);
                            this.video.StartVideo();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


    }
}
