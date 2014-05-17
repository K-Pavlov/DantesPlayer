namespace MainScreen.UserFormComponents
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using AudioHandling;
    using UserInterfaceDialogs;
    using VideoHandling;
    using System.Text.RegularExpressions;
    using System.IO;
    #endregion

    /// <summary>
    /// Methods for button clicks
    /// </summary>
    public class ButtonClicks
    {
        private const string TypeExpecption = "I can't play the video :(.";
        private const string Formats = "Subs |*.SRT";

        /// <summary>
        /// Gets or sets the main screen instance 
        /// </summary>
        public MainScreen MainScreenInstance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the audio control is hidden
        /// </summary>
        private bool AudioHidden { get; set; }

        /// <summary>
        /// Gets or sets the video name 
        /// </summary>
        private string VideoName { get; set; }

        private string SubsName { get; set; }

        private bool playListHidden = true;

        /// <summary>
        /// Plays the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void Play(Button button, IPlayable playable)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(playable))
            {
                if (!this.MainScreenInstance.timerForProgress.Enabled)
                {
                    this.MainScreenInstance.timerForProgress.Start();
                }

                playable.Play();
            }

            if (this.MainScreenInstance.timerForRF.Enabled)
            {
                this.MainScreenInstance.timerForRF.Stop();
                playable.PlayBackSpeed = 0;
            }
        }

        public void LoadSubs(Button button, Subtitles subtitles)
        {
            if (CheckException.CheckNull(this.VideoName))
            {
                OpenFileDialog Dialog1 = new OpenFileDialog();
                Dialog1.InitialDirectory = "c:\\";
                Dialog1.Filter = Formats;
                Dialog1.FilterIndex = 2;
                Dialog1.RestoreDirectory = true;
                if (Dialog1.ShowDialog() == DialogResult.OK)
                {
                    if (Dialog1.OpenFile() != null)
                    {
                        this.SubsName = Dialog1.FileName;
                    }
                }
                if (CheckException.CheckNull(this.SubsName))
                {
                    subtitles.Load(this.SubsName);    
                }
            }
        }

        /// <summary>
        /// Pauses the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void Pause(Button button, IPlayable playable)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(playable))
            {
                playable.Pause();
            }

            if (this.MainScreenInstance.timerForRF.Enabled)
            {
                this.MainScreenInstance.timerForRF.Stop();
                playable.PlayBackSpeed = 0;
            }

            if (this.MainScreenInstance.timerForProgress.Enabled)
            {
                this.MainScreenInstance.timerForProgress.Stop();
            }
        }

        /// <summary>
        /// Stops the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void Stop(Button button, IPlayable playable)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(playable))
            {
                this.MainScreenInstance.timerForRF.Stop();
                playable.Stop();
            }

            if (this.MainScreenInstance.timerForProgress.Enabled)
            {
                this.MainScreenInstance.timerForProgress.Stop();
                this.MainScreenInstance.WriteVideoTime();
            }
        }
        public void OpenPlaylist(Button button)
        {
            if (!this.playListHidden)
            {
                this.MainScreenInstance.playList.Hide();
                this.playListHidden = true;
                return;
            }
            this.MainScreenInstance.playList.Show();
            this.playListHidden = false;

        }

        /// <summary>
        /// Rewinds the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void Rewind(Button button, IPlayable playable)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(playable))
            {
                this.MainScreenInstance.timerForRF.Start();
                playable.PlayBackSpeed -= 5;
                this.MainScreenInstance.rewindFired = true;
            }
        }

        /// <summary>
        /// Fast forwards the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void FastForward(Button button, IPlayable playable)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(playable))
            {
                this.MainScreenInstance.timerForRF.Start();
                playable.PlayBackSpeed += 5;
                this.MainScreenInstance.fastForwardFired = true;
            }
        }

        /// <summary>
        /// Closes the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void Close(Button button)
        {
            this.SwitchButtonStyle(button);

            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                HolderForm.NullVideoAndForm(this.MainScreenInstance.video.DirectVideo);
            }

            if(CheckException.CheckNull(this.MainScreenInstance.audio))
            {
                this.MainScreenInstance.audio.DirectAudio.Dispose();
                this.MainScreenInstance.audio = null;
            }

            this.MainScreenInstance.GetSlider().Value = 0;
            this.MainScreenInstance.GetSlider().Enabled = false;
            this.MainScreenInstance.timerForProgress.Stop();
            this.MainScreenInstance.timerForSubsSync.Stop();
            this.MainScreenInstance.GetLabel().Text = string.Empty;
        }

        /// <summary>
        /// Opens a video
        /// </summary>
        public void Open(Button button)
        {
            this.SwitchButtonStyle(button);
            this.VideoName = ChooseVideoDialog.TakePathToVideo();
            if (CheckException.CheckNull(this.VideoName))
            {
                this.Open(this.VideoName);
            }
            else if(CheckException.CheckNull(this.MainScreenInstance.video))
            {
                this.VideoName = this.MainScreenInstance.video.PathToSource;
            }
        }

        public void Open(string path)
        {
            try
            {
                if (this.MainScreenInstance.video == null)
                {
                    this.MainScreenInstance.subtitles.UnLoad();
                    this.MainScreenInstance.video = new Video(path, false, 800, 600);
                    this.MainScreenInstance.video.Start();
                    this.MainScreenInstance.timerForProgress.Start();
                    this.MainScreenInstance.timerForProgress.Start();
                    this.MainScreenInstance.video.DirectVideo.Ending += this.MainScreenInstance.DirectVideo_Ending;
                    this.MainScreenInstance.GetSlider().Enabled = true;
                    AudioControl.VolumeInit(this.MainScreenInstance.video.DirectVideo.Audio, this.MainScreenInstance.AudioControl.VolumeProgress);
                    this.MainScreenInstance.video.DirectVideo.Ending += this.MainScreenInstance.ClearTimers;
                    this.MainScreenInstance.video.PathToSource = path;
                }
                else
                {
                    this.MainScreenInstance.subtitles.UnLoad();
                    HolderForm.NullVideoAndForm(this.MainScreenInstance.video.DirectVideo);
                    this.MainScreenInstance.video = null;
                    this.MainScreenInstance.video = new Video(path, false, 800, 600);
                    this.MainScreenInstance.video.Start();
                    this.MainScreenInstance.timerForProgress.Start();
                    this.MainScreenInstance.timerForProgress.Start();
                    this.MainScreenInstance.GetSlider().Enabled = true;
                    AudioControl.VolumeInit(this.MainScreenInstance.video.DirectVideo.Audio, this.MainScreenInstance.AudioControl.VolumeProgress);
                    this.MainScreenInstance.video.DirectVideo.Ending += this.MainScreenInstance.ClearTimers;
                    this.MainScreenInstance.video.PathToSource = path;
                }
            }
            catch (Microsoft.DirectX.DirectXException)
            {
                try
                {
                    if(this.MainScreenInstance.audio == null)
                    {
                        this.MainScreenInstance.subtitles.UnLoad();
                        this.MainScreenInstance.audio = new Audio(path);
                        this.MainScreenInstance.audio.Start();
                        this.MainScreenInstance.timerForProgress.Start();
                        this.MainScreenInstance.timerForProgress.Start();
                        this.MainScreenInstance.GetSlider().Enabled = true;
                        AudioControl.VolumeInit(this.MainScreenInstance.audio.DirectAudio, this.MainScreenInstance.AudioControl.VolumeProgress);
                    }
                    else
                    {
                        this.MainScreenInstance.subtitles.UnLoad();
                        this.MainScreenInstance.audio = null;
                        this.MainScreenInstance.audio = new Audio(path);
                        this.MainScreenInstance.audio.Start();
                        this.MainScreenInstance.timerForProgress.Start();
                        this.MainScreenInstance.timerForProgress.Start();
                        this.MainScreenInstance.GetSlider().Enabled = true;
                        AudioControl.VolumeInit(this.MainScreenInstance.audio.DirectAudio, this.MainScreenInstance.AudioControl.VolumeProgress);

                    }
                }
                catch (Microsoft.DirectX.DirectXException)
                {
                    MessageBox.Show(TypeExpecption, "Warning");
                }              
            }
        }

        /// <summary>
        /// Minimizes the video player
        /// </summary>
        public void MinimizeForm(Button button)
        {
            this.SwitchButtonStyle(button);
            this.MainScreenInstance.WindowState = FormWindowState.Minimized;
            this.MainScreenInstance.AudioControl.Hide();
            this.MainScreenInstance.lastWindowState = this.MainScreenInstance.WindowState;
        }

        /// <summary>
        /// Closes the video player
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void ExitVideoPlayer(Button button)
        {
            this.SwitchButtonStyle(button);
            this.MainScreenInstance.Close();
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                this.MainScreenInstance.video.Close();
            }

            if(CheckException.CheckNull(this.MainScreenInstance.audio))
            {
                this.MainScreenInstance.audio.Close();
            }
            
            this.MainScreenInstance.Dispose();
        }

        /// <summary>
        /// Goes to full screen
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void FullScreenVideo(Button button)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                this.MainScreenInstance.video.OpenVideoInFullScreen();
                this.MainScreenInstance.video.IsFullScreen = true;
            }
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                if (this.MainScreenInstance.video.IsFullScreen)
                {
                    this.MainScreenInstance.menuBar = new MenuBarFullScreenForm();
                    this.MainScreenInstance.menuBar.MainScreenInstance = MainScreen.Instance;
                    this.MainScreenInstance.timerForMenuBar.Start();
                }
            }
        }

        /// <summary>
        /// Shows or respectively hides the audio form
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void ShowHideAudioForm(Button button)
        {
            this.SwitchButtonStyle(button);
            if (!this.AudioHidden)
            {
                this.MainScreenInstance.AudioControl.Hide();
                this.AudioHidden = true;
                return;
            }

            this.MainScreenInstance.AudioControl.Show();
            this.AudioHidden = false;
        }

        public void SwitchButtonStyle(Button button)
        {
            if (button.FlatStyle == FlatStyle.Standard)
            {
                button.FlatStyle = FlatStyle.Popup;
                return;
            }
            button.FlatStyle = FlatStyle.Standard;
        }
    }
}
