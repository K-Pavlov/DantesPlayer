using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using DirectAllias = Microsoft.DirectX.AudioVideoPlayback;

namespace MainScreen
{
    /// <summary>
    /// The main video class where we configure which
    /// video to play the size of the video
    /// </summary>
    public abstract class Video
    {
        static bool videoIsPlaying = true;
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
        public Video(string loadedMovie, bool autoPlay, int height, int width)
        {
            this.LoadedMovie = loadedMovie;
            this.AutoPlay = autoPlay;
            this.Height = height;
            this.Width = width;
        }

        
        ///////////// Properties //////////////////////

        private static DirectAllias::Video directVideo;

        protected string LoadedMovie
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

        protected bool AutoPlay
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

        protected int Height
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

        protected int Width
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
        /////////////// End properties ////////////////////////

        /////////////// Methods //////////////////////////////
        /// <summary>
        /// Starts the configured video
        /// </summary>
        public void StartVideo()
        {
            this.ConfigureVideo();
            directVideo.Play();
        }

        /// <summary>
        /// Configure video creates and a new video and calls a static method
        /// which attaches the video a panel and a form and shows it
        /// </summary>
        private void ConfigureVideo()
        {
            directVideo = new DirectAllias::Video(this.LoadedMovie, autoPlay);
            HolderForm.AttachVideoToForm(directVideo, this.Height, this.Width);
        }

        
        /// <summary>
        /// Check if the video is playing and if it is pauses it
        /// </summary>
        public void PauseVideo()
        {
            if (videoIsPlaying)
            {
                directVideo.Pause();
                videoIsPlaying = false;
            }
        }

        /// <summary>
        /// Checks if video is paused and if it is plays it
        /// </summary>
        public void PlayVideo()
        {
            if (!videoIsPlaying)
            {
                directVideo.Play();
                videoIsPlaying = true;
            }
        }


        //////////// End methods //////////////////////////
    }
}
