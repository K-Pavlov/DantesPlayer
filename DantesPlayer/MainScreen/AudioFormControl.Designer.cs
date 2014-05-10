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
            this.volumeDownButton = new CustomControls.CustomButton();
            this.VolumeUpButton = new CustomControls.CustomButton();
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
            this.VolumeProgress.TabStop = false;
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
            // volumeDownButton
            // 
            this.volumeDownButton.BackColor = System.Drawing.Color.Transparent;
            this.volumeDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.volumeDownButton.Image = global::MainScreen.Properties.Resources.volumeDownButton;
            this.volumeDownButton.Location = new System.Drawing.Point(49, 24);
            this.volumeDownButton.Name = "volumeDownButton";
            this.volumeDownButton.Size = new System.Drawing.Size(23, 23);
            this.volumeDownButton.TabIndex = 21;
            this.volumeDownButton.TabStop = false;
            this.volumeDownButton.UseVisualStyleBackColor = false;
            // 
            // VolumeUpButton
            // 
            this.VolumeUpButton.BackColor = System.Drawing.Color.Transparent;
            this.VolumeUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VolumeUpButton.Image = global::MainScreen.Properties.Resources.volumeUpButton;
            this.VolumeUpButton.Location = new System.Drawing.Point(212, 23);
            this.VolumeUpButton.Name = "VolumeUpButton";
            this.VolumeUpButton.Size = new System.Drawing.Size(19, 23);
            this.VolumeUpButton.TabIndex = 22;
            this.VolumeUpButton.TabStop = false;
            this.VolumeUpButton.UseVisualStyleBackColor = false;
            // 
            // AudioFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(286, 88);
            this.ControlBox = false;
            this.Controls.Add(this.VolumeUpButton);
            this.Controls.Add(this.volumeDownButton);
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
        private CustomControls.CustomButton volumeDownButton;
        private CustomControls.CustomButton VolumeUpButton;
    }
}