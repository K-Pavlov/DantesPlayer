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
        /// Gets or sets a static form where the video will be attached to
        /// </summary>
        internal static FormForVideo FormForVideo { get; set; }

        /// <summary>
        /// Kills the video and everything
        /// associated with it
        /// </summary>
        /// <param name="video">DirectX video</param>
        public static void NullVideoAndForm(DirectXAllias::Video video)
        {
            if (CheckException.CheckNull(FormForVideo))
            {
                FormForVideo.Dispose();
                FormForVideo = null;
            }

            if (CheckException.CheckNull(video))
            {
                video.Dispose();
                video = null;
            }
        }

        /// <summary>
        /// Makes the slider go correctly with
        /// the video
        /// </summary>
        /// <param name="slider">A custom slider object</param>
        /// <param name="video">DirectX video</param>
        public static void HandleVideoProgress(
            CustomControls.CustomSlider slider, DirectXAllias::Video video)
        {
            if (video.Disposed == false)
            {
                slider.Maximum = Convert.ToInt32(video.Duration);
                slider.Value = Convert.ToInt32(video.CurrentPosition);
                if (Convert.ToInt32(video.CurrentPosition) > slider.Maximum)
                {
                    slider.Value = slider.Maximum;
                    return;
                }
            }
        }


        public static void HandleAudioProgress(
            CustomControls.CustomSlider slider, DirectXAllias::Audio audio)
        {
            if(audio.Disposed == false)
            {
                slider.Maximum = Convert.ToInt32(audio.Duration);
                slider.Value = Convert.ToInt32(audio.CurrentPosition);
                if (Convert.ToInt32(audio.CurrentPosition) > slider.Maximum)
                {
                    slider.Value = slider.Maximum;
                    return;
                }
            }
        }

        /// <summary>
        /// Handles slider movement 
        /// </summary>
        /// <param name="slider">A custom slider object</param>
        /// <param name="video">A DirectX video</param>
        public static void HandleBarMovemenetVideo(
            CustomControls.CustomSlider slider, DirectXAllias::Video video)
        {
            if (CheckException.CheckNull(video))
            {
                video.CurrentPosition = slider.Value;
            }
        }

        public static void HandleBarMovementAudio(
            CustomControls.CustomSlider slider, DirectXAllias::Audio audio)
        {
            if (CheckException.CheckNull(audio))
            {
                audio.CurrentPosition = slider.Value;
            }
        }

        /// <summary>
        /// Opens the video in full screen removing the 
        /// maximum size limitation of the video
        /// </summary>
        public static void OpenInFullScreen()
        {
            FormForVideo.MaximumSize = new Size(5000, 5000);
            FormForVideo.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Attach the video to the form and panel 
        /// and show it to the world
        /// </summary>
        /// <param name="video">DirectX video</param>
        /// <param name="size">Size of the video</param>
        public void AttachVideoToForm(DirectXAllias::Video video, Size size)
        {
            FormForVideo = new FormForVideo();
            FormForVideo.MinimumSize = new Size(200, 200);
            FormForVideo.MaximumSize = new Size(801, 601);
            FormForVideo.Video = video;
            FormForVideo.ControlBox = false;
            FormForVideo.Size = new Size(800, 600);
            FormForVideo.StartPosition = FormStartPosition.CenterScreen;
            video.Owner = FormForVideo;
            FormForVideo.Show();
            FormForVideo.Activate();
            video.Size = new Size(800, 600);
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
            FormForVideo.Dispose();
            video.Dispose();
        }
    }
}
