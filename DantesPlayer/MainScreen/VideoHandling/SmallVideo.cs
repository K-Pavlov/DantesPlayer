using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScreen
{
    public sealed class SmallVideo : Video
    {
        public SmallVideo(string movie, bool autoPlay, int height, int width)
            :base(movie, autoPlay, height, width)
        {

        }
    }
}
