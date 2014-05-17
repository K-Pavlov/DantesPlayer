using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScreen
{
    public interface IPlayable
    {
        string PathToSource { get; set; }

        int PlayBackSpeed { get; set; }

        void Start();

        void Play();

        void Pause();

        void Stop();

        void Rewind();

        void FastForward();

        void Close();

        void VolumeUp(CustomControls.CustomSlider customSlider);

        void VolumeDown(CustomControls.CustomSlider customSlider);
    }
}
