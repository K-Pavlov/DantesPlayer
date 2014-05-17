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

        private bool PlHidden = true;

        /// <summary>
        /// Plays the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void PlayVideo(Button button)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                if (!this.MainScreenInstance.timerForVideoProgress.Enabled)
                {
                    this.MainScreenInstance.timerForVideoProgress.Start();
                }

                this.MainScreenInstance.video.Play();
            }

            if (this.MainScreenInstance.timerForRF.Enabled)
            {
                this.MainScreenInstance.timerForRF.Stop();
                this.MainScreenInstance.video.PlayBackSpeed = 0;
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
        public void PauseVideo(Button button)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                this.MainScreenInstance.video.Pause();
            }

            if (this.MainScreenInstance.timerForRF.Enabled)
            {
                this.MainScreenInstance.timerForRF.Stop();
                this.MainScreenInstance.video.PlayBackSpeed = 0;
            }

            if (this.MainScreenInstance.timerForVideoProgress.Enabled)
            {
                this.MainScreenInstance.timerForVideoProgress.Stop();
            }
        }

        /// <summary>
        /// Stops the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void StopVideo(Button button)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                this.MainScreenInstance.timerForRF.Stop();
                this.MainScreenInstance.video.Stop();
            }

            if (this.MainScreenInstance.timerForVideoProgress.Enabled)
            {
                this.MainScreenInstance.timerForVideoProgress.Stop();
                this.MainScreenInstance.WriteVideoTime();
            }
        }
        public void OpenPlaylist(Button button)
        {
            if (!this.PlHidden)
            {
                this.MainScreenInstance.playList.Hide();
                this.PlHidden = true;
                return;
            }
            this.MainScreenInstance.playList.Show();
            this.PlHidden = false;

        }

        /// <summary>
        /// Rewinds the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void RewindVideo(Button button)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                this.MainScreenInstance.timerForRF.Start();
                this.MainScreenInstance.video.PlayBackSpeed -= 5;
                this.MainScreenInstance.rewindFired = true;
            }
        }

        /// <summary>
        /// Fast forwards the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void FFVideo(Button button)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                this.MainScreenInstance.timerForRF.Start();
                this.MainScreenInstance.video.PlayBackSpeed += 5;
                this.MainScreenInstance.fastForwardFired = true;
            }
        }

        /// <summary>
        /// Closes the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void CloseVideo(Button button)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                HolderForm.NullVideoAndForm(this.MainScreenInstance.video.DirectVideo);
            }

            this.MainScreenInstance.GetSlider().Value = 0;
            this.MainScreenInstance.GetSlider().Enabled = false;
            this.MainScreenInstance.timerForVideoProgress.Stop();
            this.MainScreenInstance.timerForSubsSync.Stop();
            this.MainScreenInstance.GetLabel().Text = string.Empty;
        }

        /// <summary>
        /// Opens a video
        /// </summary>
        public void OpenVideo(Button button)
        {
            this.SwitchButtonStyle(button);
            this.VideoName = ChooseVideoDialog.TakePathToVideo();
            if (CheckException.CheckNull(this.VideoName))
            {
                try
                {
                    this.OpenVideo(this.VideoName);
                }
                catch (Microsoft.DirectX.DirectXException)
                {
                    MessageBox.Show(TypeExpecption, "Warning");
                }
            }
            else if(CheckException.CheckNull(this.MainScreenInstance.video))
            {
                this.VideoName = this.MainScreenInstance.video.PathToSource;
            }
        }

        public void OpenVideo(string VideoName)
        {
            try
            {
                if (this.MainScreenInstance.video == null)
                {
                    this.MainScreenInstance.video = new Video(VideoName, false, 800, 600);
                    this.MainScreenInstance.video.Start();
                    this.MainScreenInstance.timerForVideoProgress.Start();
                    this.MainScreenInstance.timerForVideoProgress.Start();
                    this.MainScreenInstance.video.DirectVideo.Ending += this.MainScreenInstance.DirectVideo_Ending;
                    this.MainScreenInstance.GetSlider().Enabled = true;
                    AudioControl.VolumeInit(this.MainScreenInstance.video.DirectVideo.Audio, this.MainScreenInstance.AudioControl.VolumeProgress);
                    this.MainScreenInstance.video.DirectVideo.Ending += this.MainScreenInstance.ClearTimers;
                    this.MainScreenInstance.video.PathToSource = VideoName;
                }
                else
                {
                    HolderForm.NullVideoAndForm(this.MainScreenInstance.video.DirectVideo);
                    this.MainScreenInstance.video = null;
                    this.MainScreenInstance.video = new Video(VideoName, false, 800, 600);
                    this.MainScreenInstance.video.Start();
                    this.MainScreenInstance.timerForVideoProgress.Start();
                    this.MainScreenInstance.timerForVideoProgress.Start();
                    this.MainScreenInstance.GetSlider().Enabled = true;
                    AudioControl.VolumeInit(this.MainScreenInstance.video.DirectVideo.Audio, this.MainScreenInstance.AudioControl.VolumeProgress);
                    this.MainScreenInstance.video.DirectVideo.Ending += this.MainScreenInstance.ClearTimers;
                    this.MainScreenInstance.video.PathToSource = VideoName;
                }
            }
            catch (Microsoft.DirectX.DirectXException)
            {
                MessageBox.Show(TypeExpecption, "Warning");
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
                    this.MainScreenInstance.menuBar.MainScreenInstance = this.MainScreenInstance;
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
