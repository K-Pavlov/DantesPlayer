namespace MainScreen.VideoHandling
{
    #region Namespaces
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using AudioHandling;
    using CustomControls;
    using DirectAllias = Microsoft.DirectX.AudioVideoPlayback;
    #endregion 

    /// <summary>
    /// The main video class where we configure which
    /// video to play the size of the video
    /// </summary>
    public sealed class Video
    {
        /// <summary>
        /// The video that is loaded
        /// </summary>
        private string loadedVideo;

        /// <summary>
        /// Should the video start automatically
        /// </summary>
        private bool autoPlay;

        /// <summary>
        /// The height of the video 
        /// </summary>
        private int height;

        /// <summary>
        /// The width of the video
        /// </summary>
        private int width;

        /// <summary>
        /// Initializes a new instance of the <see cref="Video"/> class.
        /// Constructor of the video class
        /// takes which movie to play as a string
        /// should the video play automatically 
        /// and it's width and height
        /// </summary>
        /// <param name="loadedVideo">The video that is loaded</param>
        /// <param name="autoPlay">The form that holds the video</param>
        /// <param name="width">The width of the video</param>
        /// <param name="height"> The height of the video</param>
        public Video(string loadedVideo, bool autoPlay, int width, int height)
        {
            this.LoadedVideo = loadedVideo;
            this.AutoPlay = autoPlay;
            this.Height = height;
            this.Width = width;
            this.Speed = 0;
            this.IsFullScreen = false;
            this.HolderForm = new HolderForm();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the video should be full screen 
        /// </summary>
        public bool IsFullScreen { get; set; }

        /// <summary>
        /// Gets or sets the speed of rewind/fast forward
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Gets the DirectX video
        /// </summary>
        public DirectAllias::Video DirectVideo { get; private set; }

        /// <summary>
        /// Gets or sets the form that holds the video
        /// </summary>
        private HolderForm HolderForm { get; set; }

        public string PathToVideo { get; set; }

        /// <summary>
        /// Gets or sets the loaded video
        /// </summary>
        private string LoadedVideo
        {
            get
            {
                return this.loadedVideo;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Movie name is null or empty");
                }

                this.loadedVideo = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the auto play
        /// </summary>
        private bool AutoPlay
        {
            get
            {
                return this.autoPlay;
            }

            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentException("Autoplay must have a value");
                }

                this.autoPlay = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the height of the video
        /// </summary>
        private int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value.Equals(null) || value <= 0)
                {
                    throw new ArgumentException("Height must be more than 0 and not null");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the video
        /// </summary>
        private int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value.Equals(null) || value <= 0)
                {
                    throw new ArgumentException("Width must be more than 0 and not null");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Starts the configured video
        /// </summary>
        public void StartVideo()
        {
            this.ConfigureVideo();
            this.DirectVideo.Play();
        }
    
        /// <summary>
        /// Check if the video is playing and if it is pauses it
        /// </summary>
        public void PauseVideo()
        {
            try
            {
                if (this.DirectVideo.Playing)
                {
                    this.DirectVideo.Pause();
                }
            }
            catch (NullReferenceException)
            {             
            }
        }

        /// <summary>
        /// Checks if video is paused and if it is plays it
        /// </summary>
        public void PlayVideo()
        {
            try
            {
                if (!this.DirectVideo.Playing)
                {
                    this.DirectVideo.Play();
                }
            }
            catch
                (NullReferenceException)
            {
            }
        }

        /// <summary>
        /// Stops the video
        /// </summary>
        public void StopVideo()
        {
            try
            {
                this.DirectVideo.Stop();
            }
            catch (NullReferenceException)
            {
            }
        }

        /// <summary>
        /// Closes the video
        /// </summary>
        public void CloseVideo()
        {
            try
            {
                this.HolderForm.DispatchVideoAndForm(this.DirectVideo);
            }
            catch (NullReferenceException)
            {
            }
        }

        /// <summary>
        /// Increases volume by 10%
        /// </summary>
        /// <param name="slider">A custom slider object</param>
        public void VolumeUp(CustomSlider slider)
        {
            AudioForVideos.VolumeUp(this, slider);
        }

        /// <summary>
        /// Decreases volume by 10%
        /// </summary>
        /// <param name="slider">A custom slider object</param>
        public void VolumeDown(CustomSlider slider)
        {
            AudioForVideos.VolumeDown(this, slider);
        }

        /// <summary>
        /// Opens video in full screen
        /// </summary>
        public void OpenVideoInFullScreen()
        {
            HolderForm.OpenInFullScreen();
        }

        /// <summary>
        /// Moves forward the current position of the video with x
        /// </summary>
        public void FastForward()
        {
            if (CheckException.CheckNull(this.DirectVideo))
            {
                if (this.DirectVideo.CurrentPosition + this.Speed > 0)
                {
                    this.DirectVideo.CurrentPosition += this.Speed;
                }
            }    
        }

        /// <summary>
        /// Moves back the current position of the video with x
        /// </summary>
        public void Rewind()
        {
            if (CheckException.CheckNull(this.DirectVideo))
            {
                if (this.DirectVideo.CurrentPosition + this.Speed > 0)
                {
                    this.DirectVideo.CurrentPosition += this.Speed;
                }
            }
        }

        /// <summary>
        /// Configure video creates and a new video and calls a static method
        /// which attaches the video a panel and a form and shows it
        /// </summary>
        private void ConfigureVideo()
        {
            try
            {
                this.DirectVideo = new DirectAllias::Video(this.LoadedVideo, this.autoPlay);
                this.HolderForm.AttachVideoToForm(this.DirectVideo, new Size(this.Height, this.Width));
            }
            catch (Microsoft.DirectX.DirectXException)
            {
                throw new Microsoft.DirectX.DirectXException();
            }
        }
    }
}
