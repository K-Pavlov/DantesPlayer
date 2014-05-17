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
                return directAudio;
            }
            set
            {
                if (CheckException.CheckNull(value))
                {
                    directAudio = value;
                }
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

        public int PlayBackSpeed { get; set; }

        public void Start()
        {
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
            throw new NotImplementedException();
        }

        public void FastForward()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {

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
