using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainScreen.VideoHandling
{
    class SubtitleForm : Form
    {

        private Label label1;


        public Label SubLabel
        {
            get { return this.label1; }
            set { this.label1 = value; }
        }
        

        public SubtitleForm()
        {
            this.InitializeComponent();
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
           // this.label1.ForeColor = Color.Red;
            this.label1.Font = new Font("Arial", 30);
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SubLabel.Location = new Point(this.Location.X, this.Location.Y);
            this.TopMost = true;
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // SubtitleForm
            // 
            this.ClientSize = new System.Drawing.Size(595, 635);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubtitleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
