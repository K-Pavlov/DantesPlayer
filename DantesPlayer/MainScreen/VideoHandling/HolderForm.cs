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

        /// <summary>
        /// A static form where we will the video
        /// </summary>
        private static FormForVideo holderForm = new FormForVideo();
        /// <summary>
        /// Attach the video to the form and panel 
        /// and show it to the world
        /// </summary>
        /// <param name="video"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public static void AttachVideoToForm(DirectXAllias::Video video, int height, int width)
        {
            holderForm.MinimumSize = new Size(200, 200);
            holderForm.Video = video;
            holderForm.Show();
            holderForm.StartPosition = FormStartPosition.CenterScreen;
            holderForm.ControlBox = false;
            holderForm.Size = new Size(height + 10, width + 10);
            video.Owner = holderForm;
            video.Size = holderForm.Size;
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
            holderForm.Dispose();
            video.Dispose();
        }

    }
}
