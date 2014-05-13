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

        /// <summary>
        /// Plays the video
        /// </summary>
        /// <param name="button">Button to set styles to</param>
        public void PlayVideo(Button button)
        {
            this.SwitchButtonStyle(button);
            if (CheckException.CheckNull(this.MainScreenInstance.video))
            {
                if (!this.MainScreenInstance.timerForVideoTime.Enabled)
                {
                    this.MainScreenInstance.timerForVideoTime.Start();
                }

                this.MainScreenInstance.video.PlayVideo();
            }

            if (this.MainScreenInstance.timerForRF.Enabled)
            {
                this.MainScreenInstance.timerForRF.Stop();
                this.MainScreenInstance.video.Speed = 0;
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
                subtitles.Load(this.SubsName);
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
                this.MainScreenInstance.video.PauseVideo();
            }

            if (this.MainScreenInstance.timerForRF.Enabled)
            {
                this.MainScreenInstance.timerForRF.Stop();
                this.MainScreenInstance.video.Speed = 0;
            }

            if (this.MainScreenInstance.timerForVideoTime.Enabled)
            {
                this.MainScreenInstance.timerForVideoTime.Stop();
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
                this.MainScreenInstance.video.StopVideo();
            }

            if (this.MainScreenInstance.timerForVideoTime.Enabled)
            {
                this.MainScreenInstance.timerForVideoTime.Stop();
                this.MainScreenInstance.WriteVideoTime();
            }
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
                this.MainScreenInstance.video.Speed -= 5;
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
                this.MainScreenInstance.video.Speed += 5;
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
            this.MainScreenInstance.timerForVideoTime.Stop();
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
                    if (this.MainScreenInstance.video == null)
                    {
                        this.MainScreenInstance.video = new Video(this.VideoName, false, 800, 600);
                        this.MainScreenInstance.video.StartVideo();
                        this.MainScreenInstance.timerForVideoTime.Start();
                        this.MainScreenInstance.timerForVideoProgress.Start();
                        this.MainScreenInstance.video.DirectVideo.Ending += this.MainScreenInstance.DirectVideo_Ending;
                        this.MainScreenInstance.GetSlider().Enabled = true;
                        AudioForVideos.VolumeInit(this.MainScreenInstance.video, this.MainScreenInstance.AudioControl.VolumeProgress);
                        this.MainScreenInstance.video.DirectVideo.Ending += this.MainScreenInstance.ClearTimers;
                        this.MainScreenInstance.video.PathToVideo = this.VideoName;
                    }
                    else
                    {
                        HolderForm.NullVideoAndForm(this.MainScreenInstance.video.DirectVideo);
                        this.MainScreenInstance.video = null;
                        this.MainScreenInstance.video = new Video(this.VideoName, false, 800, 600);
                        this.MainScreenInstance.video.StartVideo();
                        this.MainScreenInstance.timerForVideoTime.Start();
                        this.MainScreenInstance.timerForVideoProgress.Start();
                        this.MainScreenInstance.GetSlider().Enabled = true;
                        AudioForVideos.VolumeInit(this.MainScreenInstance.video, this.MainScreenInstance.AudioControl.VolumeProgress);
                        this.MainScreenInstance.video.DirectVideo.Ending += this.MainScreenInstance.ClearTimers;
                        this.MainScreenInstance.video.PathToVideo = this.VideoName;
                    }
                }
                catch (Microsoft.DirectX.DirectXException)
                {
                    MessageBox.Show(TypeExpecption, "Warning");
                }
            }
            else if(CheckException.CheckNull(this.MainScreenInstance.video))
            {
                this.VideoName = this.MainScreenInstance.video.PathToVideo;
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
                this.MainScreenInstance.video.CloseVideo();
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

        private void extractSubtitleTime(ref int destination, string source, int startPos, int endPos)
        {
            //Time factor for hours then for minutes 3600 -> 60 -> 1
            int timeFactor = 3600;
            for(int i = startPos; i < endPos; i++)
            {
                destination += int.Parse(source.Split(':')[i]) * timeFactor;
                timeFactor /= 60;
            }
        }
    }
}
