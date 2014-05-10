namespace MainScreen.UserInterfaceDialogs
{
    #region Namespaces
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    #endregion

    /// <summary>
    /// Static assisting for the opening
    /// of the choose file dialog
    /// </summary>
    public static class ChooseVideoDialog
    {
        #region VideoFormats
        private const string Formats = "All Videos Files |*.dat; *.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;*.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
                  " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm";
        #endregion 
        private static OpenFileDialog openFileDialog = new OpenFileDialog();

        /// <summary>
        /// Opens a form and and let's the user choose a video to play
        /// giving a path to the video
        /// </summary>
        /// <returns>String with the video name or null</returns>
        public static string TakePathToVideo()
        {
            ConfigureOpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.OpenFile() != null)
                {
                    return openFileDialog.FileName;
                }
            }

            return null;
        }

        /// <summary>
        /// Chooses initial directory, sets filters
        /// </summary>
        private static void ConfigureOpenFileDialog()
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = Formats;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
        }
    }
}
