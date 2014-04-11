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
            this.VolumeDownButton = new System.Windows.Forms.Button();
            this.VolumeUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VolumeDownButton
            // 
            this.VolumeDownButton.Location = new System.Drawing.Point(26, 114);
            this.VolumeDownButton.Name = "VolumeDownButton";
            this.VolumeDownButton.Size = new System.Drawing.Size(75, 23);
            this.VolumeDownButton.TabIndex = 0;
            this.VolumeDownButton.UseVisualStyleBackColor = true;
            this.VolumeDownButton.Click += new System.EventHandler(this.VolumeDownButton_Click);
            // 
            // VolumeUpButton
            // 
            this.VolumeUpButton.Location = new System.Drawing.Point(160, 56);
            this.VolumeUpButton.Name = "VolumeUpButton";
            this.VolumeUpButton.Size = new System.Drawing.Size(75, 23);
            this.VolumeUpButton.TabIndex = 1;
            this.VolumeUpButton.UseVisualStyleBackColor = true;
            this.VolumeUpButton.Click += new System.EventHandler(this.VolumeUpButton_Click);
            // 
            // AudioFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 174);
            this.ControlBox = false;
            this.Controls.Add(this.VolumeUpButton);
            this.Controls.Add(this.VolumeDownButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioFormControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AudioFormControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button VolumeDownButton;
        private System.Windows.Forms.Button VolumeUpButton;
    }
}