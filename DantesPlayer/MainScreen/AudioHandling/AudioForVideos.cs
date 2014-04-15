namespace MainScreen.AudioHandling
{
    #region Namespaces
    using System;
    using System.Windows.Forms;
    using CustomControls;
    #endregion

    public static class AudioForVideos
    {
        #region Constants
        private const int noSound = -10000;
        private const int volumeStep = 10;
        private const int maxVolumeValue = 0;
        private const int minVolumeValue = -4000;
        private const int maxProgressBarValue = 100;
        private const double valueNormalizer = -((double)minVolumeValue / (double)maxProgressBarValue);
        #endregion
        
        /// <summary>
        /// Initializes the volume of the video at start
        /// with the value of the progress bar
        /// </summary>
        /// <param name="video"></param>
        /// <param name="slider"></param>
        public static void VolumeInit(VideoHandling.Video video, CustomSlider slider)
        {
            if (video.DirectVideo.Audio != null)
            {
                video.DirectVideo.Audio.Volume = Convert.ToInt32(slider.Value * (valueNormalizer) + minVolumeValue);
            }
        }
        
        /// <summary>
        /// Increases volume with a step
        /// and adjusts the progress bar
        /// </summary>
        /// <param name="video"></param>
        /// <param name="slider"></param>
        public static void VolumeUp(VideoHandling.Video video, CustomSlider slider)
        {
            if (slider.Value < maxProgressBarValue)
            {
                slider.Value += volumeStep;
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
        /// <param name="video"></param>
        /// <param name="slider"></param>
        public static void VolumeDown(VideoHandling.Video video, CustomSlider slider)
        {
            if (slider.Value > slider.Minimum)
            {
                slider.Value -= volumeStep;
                if(CheckException.CheckNull(video.DirectVideo.Audio))
                {
                    HandleAudio(video, slider.Value);
                }
            }
        }

        private static void HandleAudio(VideoHandling.Video video, int value)
        {
            if (value != 0)
            {
                video.DirectVideo.Audio.Volume = Convert.ToInt32(GetCorrectValue(value));
            }
            else
            {
                video.DirectVideo.Audio.Volume = noSound;
            }
            
        }

        private static int GetCorrectValue(double value)
        {
            int usableValue = Convert.ToInt32(value * (valueNormalizer) + minVolumeValue);
            return usableValue;
        }

    }
}
