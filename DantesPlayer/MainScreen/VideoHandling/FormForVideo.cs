using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using DirectXAllias = Microsoft.DirectX.AudioVideoPlayback;
using System.Runtime.InteropServices;
namespace MainScreen.VideoHandling
{
    public class FormForVideo : Form
    {
        private DirectXAllias::Video video;
        private Timer timer = new Timer();
        //private static bool eventFired = false;

        public FormForVideo()
        {
            this.InitializeComponent();
            //timer.Tick += new EventHandler(timer_Tick); 
            //timer.Interval = 1;              
            //timer.Enabled = true;                       
            //timer.Start();                              

        }

        public DirectXAllias::Video Video
        {
            get
            {
                return this.video;
            }
            set
            {
                this.video = value;
            }
                
        }

        protected override void Dispose(bool disposing)
        {
            if (Video != null)
            {
                Video.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormForVideo
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "FormForVideo";
            //this.MouseEnter += new System.EventHandler(this.FormForVideo_MouseEnter);
            //this.MouseLeave += new System.EventHandler(this.FormForVideo_MouseLeave);
            this.ResumeLayout(false);

        }

        private void PlayPauseVideo()
        {
            if (this.Video != null)
            {
                if (this.Video.Playing)
                {
                    this.Video.Pause();
                }
                else
                {
                    this.Video.Play();
                }
            }
        }

        //private void FormForVideo_MouseEnter(object sender, EventArgs e)
        //{
        //    eventFired = false;
        //}

        //private void FormForVideo_MouseLeave(object sender, EventArgs e)
        //{
        //}

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    //if (eventFired == false && MouseButtons == MouseButtons.Left)
        //    if(MouseButtons == MouseButtons.Left)
        //    {
        //        if (checkIfCursorIsInBounds())
        //        {
        //            this.PlayPauseVideo();
        //        }
        //    }
        //}

        //private bool checkIfCursorIsInBounds()
        //{
        //    return Cursor.Position.X > this.Bounds.Top && Cursor.Position.X < this.Bounds.Bottom && Cursor.Position.Y > this.Bounds.Left && Cursor.Position.Y < this.Bounds.Right;
           
        //}
    }
}
