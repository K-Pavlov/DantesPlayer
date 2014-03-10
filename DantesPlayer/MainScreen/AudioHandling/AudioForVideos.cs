using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainScreen.AudioHandling
{
    public static class AudioForVideos
    {
        private static const int noSound = -10000;
        private static const int volumeStep = 400;
        private static const int maxVolumeValue = 0;
        private static const int minVolumeValue = -4000;
        private static const int maxProgressBarValue = 100;
        private static const double valueNormalizer = -((double)maxProgressBarValue / (double)minVolumeValue);
        /// <summary>
        /// Increases volume with a step
        /// and adjusts the progress bar
        /// </summary>
        /// <param name="video"></param>
        /// <param name="bar"></param>
        public static void VolumeUp(VideoHandling.Video video, ProgressBar bar)
        {
            if (CheckException.CheckNull(video.directVideo.Audio))
            {
                if (video.directVideo.Audio.Volume < maxVolumeValue)
                {
                    if (video.directVideo.Audio.Volume == noSound)
                    {
                        video.directVideo.Audio.Volume = minVolumeValue + volumeStep;
                    }
                    else
                    {
                        video.directVideo.Audio.Volume += volumeStep;
                    }

                }
            }
            HandleProgressBar(bar, video.directVideo.Audio.Volume);
        }
        /// <summary>
        /// Decreases volume by a step
        /// and adjusts the progress bar
        /// </summary>
        /// <param name="video"></param>
        /// <param name="bar"></param>
        public static void VolumeDown(VideoHandling.Video video, ProgressBar bar)
        {
            if (CheckException.CheckNull(video.directVideo.Audio))
            {
                if (video.directVideo.Audio.Volume > minVolumeValue)
                {
                    video.directVideo.Audio.Volume -= volumeStep;
                    HandleProgressBar(bar, video.directVideo.Audio.Volume);
                }
                else
                {
                    video.directVideo.Audio.Volume = noSound;
                    HandleProgressBar(bar, minVolumeValue);
                }
            }
        }

        private static void HandleProgressBar(ProgressBar progressBar, int value)
        {
            progressBar.Value = GetCorrectValue(value);
        }

        private static int GetCorrectValue(double value)
        {
            int usableValue = Convert.ToInt32(value * (valueNormalizer) + maxProgressBarValue);
            return usableValue;
        }

    }
}
