
using MainScreen.UserFormComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainScreen
{
    public partial class Playlist : Form
    {
        #region Video/Audio Formats
        private const string Formats = "All Videos Files |*.dat; *.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;*.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
                   " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm; *.3gp;*.wav;*.ogg;*.mp3;*.wma;*.flac;";
        #endregion

        internal Timer timerForNextItem = new Timer();
        private ButtonClicks buttonClicks = new ButtonClicks();
        private MainScreen mainScreenInstance;

        public MainScreen MainScreenInstance
        {
            get 
            {
                return this.mainScreenInstance;
            }

            set
            {
                this.mainScreenInstance = value;
                this.buttonClicks.MainScreenInstance = value;
            }            
        }

        public Playlist()
        {
            InitializeComponent();
            this.timerForNextItem.Interval = 1500;
            this.timerForNextItem.Tick += timerForNextItem_Tick;
        }

        void timerForNextItem_Tick(object sender, EventArgs e)
        {
            
        }

        private void AddPlaylist_Click(object sender, EventArgs e)
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
                    this.listView1.Items.Add((Dialog1.FileName));
                }
            }
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.MainScreenInstance.video != null &&
                this.MainScreenInstance.video.DirectVideo != null)
            {
                this.MainScreenInstance.video.DirectVideo.Dispose();
                this.MainScreenInstance.video.DirectVideo = null;
                this.MainScreenInstance.audio = null;
            }

            if (this.MainScreenInstance.audio != null &&
                this.MainScreenInstance.audio.DirectAudio != null)
            {
                this.MainScreenInstance.audio.DirectAudio.Dispose();
                this.mainScreenInstance.audio.DirectAudio = null;
                this.MainScreenInstance.audio = null;
            }
            try
            {
                this.buttonClicks.Open(
                    (string)this.listView1.SelectedItems[
                    this.listView1.SelectedItems.Count - 1].Text);
            }
            catch
            {

            }            
        }
    }
}


