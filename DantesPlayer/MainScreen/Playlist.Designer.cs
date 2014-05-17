namespace MainScreen
{
    partial class Playlist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddPlaylist = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // AddPlaylist
            // 
            this.AddPlaylist.BackgroundImage = global::MainScreen.Properties.Resources.AddButtonPlayList;
            this.AddPlaylist.Location = new System.Drawing.Point(0, 0);
            this.AddPlaylist.Name = "AddPlaylist";
            this.AddPlaylist.Size = new System.Drawing.Size(34, 36);
            this.AddPlaylist.TabIndex = 1;
            this.AddPlaylist.UseVisualStyleBackColor = true;
            this.AddPlaylist.Click += new System.EventHandler(this.AddPlaylist_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.MenuText;
            this.listView1.BackgroundImage = global::MainScreen.Properties.Resources.letstry1;
            this.listView1.ForeColor = System.Drawing.Color.Red;
            this.listView1.Location = new System.Drawing.Point(0, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(338, 227);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Playlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(338, 261);
            this.ControlBox = false;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.AddPlaylist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Playlist";
            this.Text = "Playlist";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddPlaylist;
        private System.Windows.Forms.ListView listView1;
    }
}