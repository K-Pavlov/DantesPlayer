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
    public class HolderForm
    {       

        /// <summary>
        /// A static form where we will the video
        /// </summary>
        private FormForVideo holderForm = new FormForVideo();

        /// <summary>
        /// Attach the video to the form and panel 
        /// and show it to the world
        /// </summary>
        /// <param name="video">DirectX video</param>
        /// <param name="height">The height of the video</param>
        /// <param name="width">The width of the video</param>
        public void AttachVideoToForm(DirectXAllias::Video video, Size size)
        {
            holderForm.MinimumSize = new Size(200, 200);
            holderForm.MaximumSize = new Size(801, 601);
            holderForm.Video = video;
            holderForm.ControlBox = false;
            holderForm.Size = new Size(800, 600);
           // Display the form in the center of the screen.
            holderForm.StartPosition = FormStartPosition.CenterScreen;
            video.Owner = holderForm;
            holderForm.Show();
            holderForm.Activate();
            video.Size = new Size(800,600);
        }
        
        /// <summary>
        /// Dispatches the video and form meaning
        /// it cleans all resources behind
        /// after and the video is stopped 
        /// AND the form is closed
        /// </summary>
        /// <param name="video">The DirectX video</param>
        public void DispatchVideoAndForm(DirectXAllias::Video video)
        {
            holderForm.Dispose();
            video.Dispose();
        }

        public static void HandleVideoProgress(CustomControls.CustomSlider slider, DirectXAllias::Video video)
        {
            slider.Maximum = Convert.ToInt32(video.Duration);
            slider.Value = Convert.ToInt32(video.CurrentPosition);
            if (Convert.ToInt32(video.CurrentPosition) > slider.Maximum)
            {
                slider.Value = slider.Maximum;
                return;
            }
        }

        public static void HandleBarMovemenet(CustomControls.CustomSlider slider, DirectXAllias::Video video)
        {
            if(CheckException.CheckNull(video))
            {
                video.CurrentPosition = slider.Value;
            }
        }
    }
}
