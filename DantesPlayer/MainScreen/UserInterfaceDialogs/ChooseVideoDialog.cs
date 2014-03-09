using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace MainScreen.UserInterfaceDialogs
{
    public class ChooseVideoDialog
    {
        private static readonly OpenFileDialog openFileDialog = new OpenFileDialog();
        private static readonly string formats = "All Videos Files |*.dat; *.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;*.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
                  " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm";

        public static string TakePathToVideo()
        {
            configureOpenFileDialog(formats);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.OpenFile() != null)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }

        private static void configureOpenFileDialog(string formats)
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = formats;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
        }
    }
}
