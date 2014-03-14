namespace MainScreen.VideoHandling
{
    #region Namespaces
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DirectAllias = Microsoft.DirectX.AudioVideoPlayback;
    using AudioHandling;
    #endregion 

    /// <summary>
    /// The main video class where we configure which
    /// video to play the size of the video
    /// </summary>
    public sealed class Video
    {
        private string loadedMovie;
        private bool autoPlay;
        private int height;
        private int width;
        /// <summary>
        /// Constructor of the video class
        /// takes which movie to play as a string
        /// should the video play automatically 
        /// and it's width and height
        /// </summary>
        /// <param name="loadedMovie"></param>
        /// <param name="autoPlay"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Video(string loadedMovie, bool autoPlay, int width, int height)
        {
            this.LoadedMovie = loadedMovie;
            this.AutoPlay = autoPlay;
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// Return the video, readonly 
        /// </summary>
        public DirectAllias::Video DirectVideo { get; private set; }

        private string LoadedMovie
        {
            get
            {
                return this.loadedMovie;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Movie name is null or empty");
                }

                this.loadedMovie = value;
            }
        }

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
        /// Configure video creates and a new video and calls a static method
        /// which attaches the video a panel and a form and shows it
        /// </summary>
        private void ConfigureVideo()
        {
            this.DirectVideo = new DirectAllias::Video(this.LoadedMovie, autoPlay);
            HolderForm.AttachVideoToForm(this.DirectVideo, new Size(this.Height, this.Width));
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
            catch(NullReferenceException)
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
            catch(NullReferenceException)
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
                HolderForm.DispatchVideoAndForm(this.DirectVideo);
            }
            catch(NullReferenceException)
            {

            }
        }

        /// <summary>
        /// Increases volume by 10%
        /// </summary>
        /// <param name="bar"></param>
        public void VolumeUp(ProgressBar bar)
        {
            AudioForVideos.VolumeUp(this, bar);
        }

        /// <summary>
        /// Decreases volume by 10%
        /// </summary>
        /// <param name="bar"></param>
        public void VolumeDown(ProgressBar bar)
        {
            AudioForVideos.VolumeDown(this, bar);
        }

        // TODO: Open in fullscr
        public void OpenVideoInFullScreen()
        {
            HolderForm.ChangeFormSize(new Size(Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width));
        }



    }
}
