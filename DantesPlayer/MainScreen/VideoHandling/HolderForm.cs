using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectXAllias = Microsoft.DirectX.AudioVideoPlayback;
namespace MainScreen.VideoHandling
{
    /// <summary>
    /// Configuration of the video meaning
    /// that here we make a panel with a set width and height 
    /// and we show the form the world
    /// </summary>
    public static class HolderForm
    {
        /* 
         */
        

        /// <summary>
        /// A static form and panel where we will the video
        /// </summary>
        private static Form holderForm = new Form();
        private static Panel holderPanel = new Panel();
        /// <summary>
        /// Attach the video to the form and panel 
        /// and show it to the world
        /// </summary>
        /// <param name="video"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public static void AttachVideoToForm(DirectXAllias::Video video, int height, int width)
        {
            holderForm.Show();
            holderForm.ControlBox = false;
            holderPanel.Size = new Size(width, height);
            holderForm.Controls.Add(holderPanel);
            video.Owner = holderPanel;
        }

        /// <summary>
        /// Dispatches the video and form meaning
        /// it cleans all resources behind
        /// after and the video is stopped 
        /// AND the form is closed
        /// </summary>
        /// <param name="video"></param>
        public static void DispatchVideoAndForm(DirectXAllias::Video video)
        {
        }
    }
}
