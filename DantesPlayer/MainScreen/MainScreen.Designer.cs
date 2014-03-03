namespace MainScreen
{
    partial class MainScreen
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
            this.PlayButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.FFButton = new System.Windows.Forms.Button();
            this.RewindButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.Location = new System.Drawing.Point(43, 110);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PauseButton.Location = new System.Drawing.Point(216, 110);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 23);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            // 
            // FFButton
            // 
            this.FFButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FFButton.Location = new System.Drawing.Point(126, 48);
            this.FFButton.Name = "FFButton";
            this.FFButton.Size = new System.Drawing.Size(75, 23);
            this.FFButton.TabIndex = 2;
            this.FFButton.Text = "FF";
            this.FFButton.UseVisualStyleBackColor = true;
            // 
            // RewindButton
            // 
            this.RewindButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RewindButton.Location = new System.Drawing.Point(126, 169);
            this.RewindButton.Name = "RewindButton";
            this.RewindButton.Size = new System.Drawing.Size(75, 23);
            this.RewindButton.TabIndex = 3;
            this.RewindButton.Text = "Rewind";
            this.RewindButton.UseVisualStyleBackColor = true;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 223);
            this.Controls.Add(this.RewindButton);
            this.Controls.Add(this.FFButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button FFButton;
        private System.Windows.Forms.Button RewindButton;
    }
}

