using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScreen.VideoHandling
{
    public sealed class BigVideo : Video
    {
        public BigVideo(string movie, bool autoPlay, int height, int width)
            :base(movie, autoPlay, height, width)
        {
                
        }
    }
}
