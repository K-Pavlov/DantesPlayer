using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectXAllias = Microsoft.DirectX.AudioVideoPlayback;

namespace MainScreen.VideoHandling
{
    public class FormForVideo : Form
    {
        protected override void Dispose(bool disposing)
        {
            Video.Dispose();
            base.Dispose(disposing);
        }

        public DirectXAllias::Video Video { get; set; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormForVideo
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "FormForVideo";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormForVideo_MouseClick);
            this.ResumeLayout(false);

        }

        private void FormForVideo_MouseClick(object sender, MouseEventArgs e)
        {
            if (Video.Playing)
            {
                Video.Pause();
            }
            else
            {
                Video.Play();
            }
        }

    }
}
