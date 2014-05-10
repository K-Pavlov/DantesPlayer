namespace MainScreen.AudioHandling
{
    #region Namespaces
    using System;
    using System.Windows.Forms;
    using CustomControls;
    #endregion

    /// <summary>
    /// Static class for the audio of the videos
    /// </summary>
    public static class AudioForVideos
    {
        #region Constants
        /// <summary>
        /// Value where there is no sound
        /// </summary>
        private const int NoSound = -10000;

        /// <summary>
        /// The volume step (this is for the slider)
        /// </summary>
        private const int VolumeStep = 10;

        /// <summary>
        /// The maximal volume
        /// </summary>
        private const int MaxVolumeValue = 0;

        /// <summary>
        /// The minimal volume
        /// </summary>
        private const int MinVolumeValue = -4000;

        /// <summary>
        /// Max progress bar value 
        /// </summary>
        private const int MaxProgressBarValue = 100;

        /// <summary>
        /// Changes from bar to volume value
        /// </summary>
        private const double ValueNormalizer = -((double)MinVolumeValue / (double)MaxProgressBarValue);
        #endregion
        
        /// <summary>
        /// Initializes the volume of the video at start
        /// with the value of the progress bar
        /// </summary>
        /// <param name="video">A video object</param>
        /// <param name="slider">A custom slider object</param>
        public static void VolumeInit(VideoHandling.Video video, CustomSlider slider)
        {
            if (video.DirectVideo.Audio != null)
            {
                video.DirectVideo.Audio.Volume = Convert.ToInt32(slider.Value * (ValueNormalizer)+MinVolumeValue);
            }
        }
        
        /// <summary>
        /// Increases volume with a step
        /// and adjusts the progress bar
        /// </summary>
        /// <param name="video">A video object</param>
        /// <param name="slider">A custom slider object</param>
        public static void VolumeUp(VideoHandling.Video video, CustomSlider slider)
        {
            if (slider.Value < MaxProgressBarValue)
            {
                slider.Value += VolumeStep;
                if (CheckException.CheckNull(video.DirectVideo.Audio))
                {
                    HandleAudio(video, slider.Value);
                }
            }
        }

        /// <summary>
        /// Decreases volume by a step
        /// and adjusts the progress bar
        /// </summary>
        /// <param name="video">A video object</param>
        /// <param name="slider">A custom slider object</param>
        public static void VolumeDown(VideoHandling.Video video, CustomSlider slider)
        {
            if (slider.Value > slider.Minimum)
            {
                slider.Value -= VolumeStep;
                if (CheckException.CheckNull(video.DirectVideo.Audio))
                {
                    HandleAudio(video, slider.Value);
                }
            }
        }

        /// <summary>
        /// Checks if the value is adequate and sets the volume
        /// </summary>
        /// <param name="video">A video object</param>
        /// <param name="value">An integer value</param>
        private static void HandleAudio(VideoHandling.Video video, int value)
        {
            if (value != 0)
            {
                video.DirectVideo.Audio.Volume = Convert.ToInt32(GetCorrectValue(value));
            }
            else
            {
                video.DirectVideo.Audio.Volume = NoSound;
            }            
        }

        /// <summary>
        /// Gets the correct value to set the volume to
        /// </summary>
        /// <param name="value">A double value</param>
        /// <returns>An integer value which is for the volume</returns>
        private static int GetCorrectValue(double value)
        {
            int usableValue = Convert.ToInt32(value * (ValueNormalizer)+MinVolumeValue);
            return usableValue;
        }
    }
}
