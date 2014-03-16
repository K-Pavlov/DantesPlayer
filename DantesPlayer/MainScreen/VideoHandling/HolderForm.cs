namespace MainScreen.VideoHandling
{
    #region Namespaces
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DirectXAllias = Microsoft.DirectX.AudioVideoPlayback;
    #endregion

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
        private static FormForVideo holderForm;
        private static FormForVideo fullScreenForm = new FormForVideo();

        /// <summary>
        /// Attach the video to the form and panel 
        /// and show it to the world
        /// </summary>
        /// <param name="video">DirectX video</param>
        /// <param name="height">The height of the video</param>
        /// <param name="width">The width of the video</param>
        public static void AttachVideoToForm(DirectXAllias::Video video, Size size)
        {
            holderForm = new FormForVideo();
            holderForm.MinimumSize = new Size(200, 200);
            holderForm.StartPosition = FormStartPosition.CenterScreen;
            holderForm.Video = video;
            holderForm.ControlBox = false;
            holderForm.Size = size;
            video.Owner = holderForm;
            video.Size = holderForm.Size;
            holderForm.Show();
        }
        
        /// <summary>
        /// Dispatches the video and form meaning
        /// it cleans all resources behind
        /// after and the video is stopped 
        /// AND the form is closed
        /// </summary>
        /// <param name="video">The DirectX video</param>
        public static void DispatchVideoAndForm(DirectXAllias::Video video)
        {
            holderForm.Dispose();
            video.Dispose();
        }


    }
}
