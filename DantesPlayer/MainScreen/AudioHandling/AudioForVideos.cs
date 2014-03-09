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
        private static readonly int noSound = -10000;
        private static readonly int volumeStep = 400;
        private static readonly int maxVolumeValue = 0;
        private static readonly int minVolumeValue = -4000;
        
        public static void VolumeUp(VideoHandling.Video video, ProgressBar bar)
        {
            if (video != null)
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

        public static void VolumeDown(VideoHandling.Video video, ProgressBar bar)
        {
            if (video != null)
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
            int usableValue = Convert.ToInt32(value * (0.025) + 100);
            return usableValue;
        }

    }
}
