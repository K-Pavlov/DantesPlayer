namespace MainScreen.AudioHandling
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DirectXAllias = Microsoft.DirectX.AudioVideoPlayback;
    #endregion

    public class Audio : IPlayable
    {
        private string loadedAuio;

        private DirectXAllias::Audio directAudio;

        public DirectXAllias::Audio DirectAudio
        {
            get 
            { 
                return this.directAudio;
            }
            set
            {
                this.directAudio = value;
            }
        }
        

        public string PathToSource
        {
            get
            {
                return this.loadedAuio;
            }
            set
            {
                if(CheckException.CheckNull(value))
                {
                    this.loadedAuio = value;
                }
            }
        }

        public Audio(string path)
        {
            this.PathToSource = path;
        }

        public int PlayBackSpeed { get; set; }

        public void Start()
        {
            this.DirectAudio = new DirectXAllias.Audio(this.PathToSource, true);
            this.Play();
        }

        public void Play()
        {
            if(CheckException.CheckNull(this.DirectAudio))
            {
                this.DirectAudio.Play();
            }
        }

        public void Pause()
        {
            if(CheckException.CheckNull(this.DirectAudio))
            {
                this.DirectAudio.Pause();
            }
        }

        public void Stop()
        {
            if(CheckException.CheckNull(this.DirectAudio))
            {
                this.DirectAudio.Stop();
            }
        }

        public void Rewind()
        {
            if (CheckException.CheckNull(this.DirectAudio))
            {
                if (this.DirectAudio.CurrentPosition + this.PlayBackSpeed > 0)
                {
                    this.DirectAudio.CurrentPosition += this.PlayBackSpeed;
                }
            }
        }

        public void FastForward()
        {
            if (CheckException.CheckNull(this.DirectAudio))
            {
                if (this.DirectAudio.CurrentPosition + this.PlayBackSpeed > 0)
                {
                    this.DirectAudio.CurrentPosition += this.PlayBackSpeed;
                }
            }
        }

        public void Close()
        {
            if (CheckException.CheckNull(this.DirectAudio))
            {
                this.DirectAudio.Dispose();
                this.DirectAudio = null;
            }
        }

        public void VolumeUp(CustomControls.CustomSlider customSlider)
        {
            AudioControl.VolumeUp(this.DirectAudio, customSlider);
        }

        public void VolumeDown(CustomControls.CustomSlider customSlider)
        {
            AudioControl.VolumeDown(this.DirectAudio, customSlider);
        }
    }
}
