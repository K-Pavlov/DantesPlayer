namespace MainScreen
{
    partial class AudioFormControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioFormControl));
            this.VolumeProgress = new CustomControls.CustomSlider();
            this.VolumeDown = new System.Windows.Forms.Button();
            this.VolumeUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VolumeProgress
            // 
            this.VolumeProgress.BackColor = System.Drawing.Color.Transparent;
            this.VolumeProgress.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.VolumeProgress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VolumeProgress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolumeProgress.ForeColor = System.Drawing.Color.Black;
            this.VolumeProgress.IndentHeight = 6;
            this.VolumeProgress.IndentWidth = 7;
            this.VolumeProgress.Location = new System.Drawing.Point(78, 24);
            this.VolumeProgress.Maximum = 100;
            this.VolumeProgress.Minimum = 0;
            this.VolumeProgress.Name = "VolumeProgress";
            this.VolumeProgress.Size = new System.Drawing.Size(127, 42);
            this.VolumeProgress.TabIndex = 20;
            this.VolumeProgress.TickColor = System.Drawing.SystemColors.MenuHighlight;
            this.VolumeProgress.TickFrequency = 50;
            this.VolumeProgress.TickHeight = 7;
            this.VolumeProgress.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.VolumeProgress.TrackerSize = new System.Drawing.Size(8, 8);
            this.VolumeProgress.TrackLineColor = System.Drawing.Color.White;
            this.VolumeProgress.TrackLineHeight = 8;
            this.VolumeProgress.Value = 0;
            this.VolumeProgress.ValueChanged += new CustomControls.CustomSlider.ValueChangedHandler(this.VolumeProgress_ValueChanged);
            // 
            // VolumeDown
            // 
            this.VolumeDown.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.VolumeDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VolumeDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VolumeDown.Image = global::MainScreen.Properties.Resources.buttonminus;
            this.VolumeDown.Location = new System.Drawing.Point(41, 34);
            this.VolumeDown.Name = "VolumeDown";
            this.VolumeDown.Size = new System.Drawing.Size(31, 23);
            this.VolumeDown.TabIndex = 21;
            this.VolumeDown.UseVisualStyleBackColor = true;
            this.VolumeDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VolumeDown_MouseDown);
            this.VolumeDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VolumeDown_MouseUp);
            // 
            // VolumeUp
            // 
            this.VolumeUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VolumeUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VolumeUp.Image = global::MainScreen.Properties.Resources.buttonplus;
            this.VolumeUp.Location = new System.Drawing.Point(211, 34);
            this.VolumeUp.Name = "VolumeUp";
            this.VolumeUp.Size = new System.Drawing.Size(31, 23);
            this.VolumeUp.TabIndex = 22;
            this.VolumeUp.UseVisualStyleBackColor = true;
            this.VolumeUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VolumeUp_MouseDown);
            this.VolumeUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VolumeUp_MouseUp);
            // 
            // AudioFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(286, 88);
            this.ControlBox = false;
            this.Controls.Add(this.VolumeUp);
            this.Controls.Add(this.VolumeDown);
            this.Controls.Add(this.VolumeProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioFormControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AudioFormControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal CustomControls.CustomSlider VolumeProgress;
        private System.Windows.Forms.Button VolumeDown;
        private System.Windows.Forms.Button VolumeUp;
    }
}