#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace MainScreen.AudioHandling
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    #endregion

    public static class AudioForVideos
    {
        #region Constants
        private const int noSound = -10000;
        private const int volumeStep = 400;
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
        /// <param name="bar"></param>
        public static void VolumeInit(VideoHandling.Video video, ProgressBar bar)
        {
            video.DirectVideo.Audio.Volume = Convert.ToInt32(bar.Value * (valueNormalizer) + minVolumeValue);
        }
        
        /// <summary>
        /// Increases volume with a step
        /// and adjusts the progress bar
        /// </summary>
        /// <param name="video"></param>
        /// <param name="bar"></param>
        public static void VolumeUp(VideoHandling.Video video, ProgressBar bar)
        {
            if (bar.Value < maxProgressBarValue)
            {
                bar.Value += bar.Step;
                if (CheckException.CheckNull(video.DirectVideo.Audio))
                {
                    HandleAudio(video, bar.Value);
                }
            }
        }

        /// <summary>
        /// Decreases volume by a step
        /// and adjusts the progress bar
        /// </summary>
        /// <param name="video"></param>
        /// <param name="bar"></param>
        public static void VolumeDown(VideoHandling.Video video, ProgressBar bar)
        {
            if (bar.Value > bar.Minimum)
            {
                bar.Value -= bar.Step;
                if(CheckException.CheckNull(video.DirectVideo.Audio))
                {
                    HandleAudio(video, bar.Value);
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
