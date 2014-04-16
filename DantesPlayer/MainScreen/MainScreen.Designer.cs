namespace MainScreen
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using UserInterfaceDialogs;
    using VideoHandling;
    using AudioHandling;
    using CustomControls;
    #endregion
    public sealed partial class MainScreen
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
            this.ShowHideAudioButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenVideoButton = new CustomControls.CustomButton();
            this.MinimizeButton = new CustomControls.CustomButton();
            this.ExitButton = new CustomControls.CustomButton();
            this.StopButton = new CustomControls.CustomButton();
            this.PauseButton = new CustomControls.CustomButton();
            this.FFButton = new CustomControls.CustomButton();
            this.RewindButton = new CustomControls.CustomButton();
            this.PlayButton = new CustomControls.CustomButton();
            this.VideoSlider = new CustomControls.CustomSlider();
            this.CloseVideoButton = new CustomControls.CustomButton();
            this.FullScreenButton = new CustomControls.CustomButton();
            this.SuspendLayout();
            // 
            // ShowHideAudioButton
            // 
            this.ShowHideAudioButton.Location = new System.Drawing.Point(48, 74);
            this.ShowHideAudioButton.Name = "ShowHideAudioButton";
            this.ShowHideAudioButton.Size = new System.Drawing.Size(49, 23);
            this.ShowHideAudioButton.TabIndex = 19;
            this.ShowHideAudioButton.Text = "button1";
            this.ShowHideAudioButton.UseVisualStyleBackColor = true;
            this.ShowHideAudioButton.Click += new System.EventHandler(this.ShowHideAudioButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(157, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 20;
            // 
            // OpenVideoButton
            // 
            this.OpenVideoButton.Image = global::MainScreen.Properties.Resources.OpenFile;
            this.OpenVideoButton.Location = new System.Drawing.Point(103, 74);
            this.OpenVideoButton.Name = "OpenVideoButton";
            this.OpenVideoButton.Size = new System.Drawing.Size(29, 30);
            this.OpenVideoButton.TabIndex = 29;
            this.OpenVideoButton.UseVisualStyleBackColor = true;
            this.OpenVideoButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenVideoButton_MouseDown);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Image = global::MainScreen.Properties.Resources.buttonMinimize2;
            this.MinimizeButton.Location = new System.Drawing.Point(481, 86);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(23, 23);
            this.MinimizeButton.TabIndex = 28;
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click_1);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::MainScreen.Properties.Resources.buttonExit2;
            this.ExitButton.Location = new System.Drawing.Point(510, 86);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(23, 23);
            this.ExitButton.TabIndex = 27;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Image = global::MainScreen.Properties.Resources.buttonStop2;
            this.StopButton.Location = new System.Drawing.Point(189, 148);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(28, 23);
            this.StopButton.TabIndex = 26;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StopButton_MouseDown);
            // 
            // PauseButton
            // 
            this.PauseButton.Image = global::MainScreen.Properties.Resources.buttonPause2;
            this.PauseButton.Location = new System.Drawing.Point(152, 148);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(28, 23);
            this.PauseButton.TabIndex = 25;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PauseButton_MouseDown);
            // 
            // FFButton
            // 
            this.FFButton.Image = global::MainScreen.Properties.Resources.buttonFF2;
            this.FFButton.Location = new System.Drawing.Point(223, 148);
            this.FFButton.Name = "FFButton";
            this.FFButton.Size = new System.Drawing.Size(28, 23);
            this.FFButton.TabIndex = 23;
            this.FFButton.UseVisualStyleBackColor = true;
            this.FFButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FFButton_MouseDown);
            // 
            // RewindButton
            // 
            this.RewindButton.Image = global::MainScreen.Properties.Resources.RewindButton;
            this.RewindButton.Location = new System.Drawing.Point(260, 148);
            this.RewindButton.Name = "RewindButton";
            this.RewindButton.Size = new System.Drawing.Size(28, 23);
            this.RewindButton.TabIndex = 22;
            this.RewindButton.UseVisualStyleBackColor = true;
            this.RewindButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RewindButton1_MouseDown);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayButton.Image = global::MainScreen.Properties.Resources.PlayButtonLast;
            this.PlayButton.Location = new System.Drawing.Point(113, 148);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(33, 23);
            this.PlayButton.TabIndex = 21;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayButton_MouseDown_1);
            // 
            // VideoSlider
            // 
            this.VideoSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.VideoSlider.BackColor = System.Drawing.Color.Transparent;
            this.VideoSlider.BorderColor = System.Drawing.Color.Transparent;
            this.VideoSlider.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoSlider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.VideoSlider.IndentHeight = 10;
            this.VideoSlider.Location = new System.Drawing.Point(63, 169);
            this.VideoSlider.Maximum = 20;
            this.VideoSlider.Minimum = 0;
            this.VideoSlider.Name = "VideoSlider";
            this.VideoSlider.Size = new System.Drawing.Size(303, 30);
            this.VideoSlider.TabIndex = 17;
            this.VideoSlider.Text = "customSlider1";
            this.VideoSlider.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.VideoSlider.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.VideoSlider.TickHeight = 4;
            this.VideoSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VideoSlider.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.VideoSlider.TrackerSize = new System.Drawing.Size(10, 10);
            this.VideoSlider.TrackLineColor = System.Drawing.Color.DimGray;
            this.VideoSlider.TrackLineHeight = 10;
            this.VideoSlider.Value = 0;
            this.VideoSlider.MouseClick += new System.Windows.Forms.MouseEventHandler(this.customSlider1_MouseClick);
            // 
            // CloseVideoButton
            // 
            this.CloseVideoButton.Image = global::MainScreen.Properties.Resources.CloseVideoButton;
            this.CloseVideoButton.Location = new System.Drawing.Point(492, 149);
            this.CloseVideoButton.Name = "CloseVideoButton";
            this.CloseVideoButton.Size = new System.Drawing.Size(32, 23);
            this.CloseVideoButton.TabIndex = 30;
            this.CloseVideoButton.UseVisualStyleBackColor = true;
            this.CloseVideoButton.Click += new System.EventHandler(this.CloseVideoButton_Click);
            // 
            // FullScreenButton
            // 
            this.FullScreenButton.Image = global::MainScreen.Properties.Resources.FullScreenButton;
            this.FullScreenButton.Location = new System.Drawing.Point(492, 118);
            this.FullScreenButton.Name = "FullScreenButton";
            this.FullScreenButton.Size = new System.Drawing.Size(30, 25);
            this.FullScreenButton.TabIndex = 31;
            this.FullScreenButton.UseVisualStyleBackColor = true;
            this.FullScreenButton.Click += new System.EventHandler(this.FullScreenButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MainScreen.Properties.Resources.background_000;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(571, 263);
            this.ControlBox = false;
            this.Controls.Add(this.FullScreenButton);
            this.Controls.Add(this.CloseVideoButton);
            this.Controls.Add(this.OpenVideoButton);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.FFButton);
            this.Controls.Add(this.RewindButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowHideAudioButton);
            this.Controls.Add(this.VideoSlider);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DantesPlayer";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainScreen_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainScreen_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.CustomSlider VideoSlider;
        private Label label1;
        private CustomControls.CustomButton PlayButton;
        private CustomButton RewindButton;
        private CustomButton FFButton;
        private CustomButton PauseButton;
        private CustomButton StopButton;
        private CustomButton ExitButton;
        private CustomButton MinimizeButton;
        private CustomButton OpenVideoButton;
        private CustomButton CloseVideoButton;
        private CustomButton FullScreenButton;


    }
}

