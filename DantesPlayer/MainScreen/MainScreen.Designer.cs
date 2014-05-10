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
            this.label1 = new System.Windows.Forms.Label();
            this.HideShowAudioFormButton = new CustomControls.CustomButton();
            this.FullScreenButton = new CustomControls.CustomButton();
            this.CloseVideoButton = new CustomControls.CustomButton();
            this.OpenVideoButton = new CustomControls.CustomButton();
            this.MinimizeButton = new CustomControls.CustomButton();
            this.ExitButton = new CustomControls.CustomButton();
            this.StopButton = new CustomControls.CustomButton();
            this.PauseButton = new CustomControls.CustomButton();
            this.FFButton = new CustomControls.CustomButton();
            this.RewindButton = new CustomControls.CustomButton();
            this.PlayButton = new CustomControls.CustomButton();
            this.VideoSlider = new CustomControls.CustomSlider();
            this.SuspendLayout();
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
            // HideShowAudioFormButton
            // 
            this.HideShowAudioFormButton.BackColor = System.Drawing.Color.Transparent;
            this.HideShowAudioFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideShowAudioFormButton.Image = global::MainScreen.Properties.Resources.HideShowForm;
            this.HideShowAudioFormButton.Location = new System.Drawing.Point(63, 81);
            this.HideShowAudioFormButton.Name = "HideShowAudioFormButton";
            this.HideShowAudioFormButton.Size = new System.Drawing.Size(25, 23);
            this.HideShowAudioFormButton.TabIndex = 32;
            this.HideShowAudioFormButton.TabStop = false;
            this.HideShowAudioFormButton.UseVisualStyleBackColor = false;
            this.HideShowAudioFormButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HideShowAudioFormButton_MouseDown);
            this.HideShowAudioFormButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HideShowAudioFormButton_MouseUp);
            // 
            // FullScreenButton
            // 
            this.FullScreenButton.BackColor = System.Drawing.Color.Transparent;
            this.FullScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FullScreenButton.Image = global::MainScreen.Properties.Resources.FullScreenButton;
            this.FullScreenButton.Location = new System.Drawing.Point(492, 118);
            this.FullScreenButton.Name = "FullScreenButton";
            this.FullScreenButton.Size = new System.Drawing.Size(30, 25);
            this.FullScreenButton.TabIndex = 31;
            this.FullScreenButton.TabStop = false;
            this.FullScreenButton.UseVisualStyleBackColor = false;
            this.FullScreenButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FullScreenButton_MouseDown);
            this.FullScreenButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FullScreenButton_MouseUp);
            // 
            // CloseVideoButton
            // 
            this.CloseVideoButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseVideoButton.Image = global::MainScreen.Properties.Resources.CloseVideoButton;
            this.CloseVideoButton.Location = new System.Drawing.Point(492, 149);
            this.CloseVideoButton.Name = "CloseVideoButton";
            this.CloseVideoButton.Size = new System.Drawing.Size(25, 25);
            this.CloseVideoButton.TabIndex = 30;
            this.CloseVideoButton.TabStop = false;
            this.CloseVideoButton.UseVisualStyleBackColor = false;
            this.CloseVideoButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseVideoButton_MouseDown);
            this.CloseVideoButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CloseVideoButton_MouseUp);
            // 
            // OpenVideoButton
            // 
            this.OpenVideoButton.BackColor = System.Drawing.Color.Transparent;
            this.OpenVideoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenVideoButton.Image = global::MainScreen.Properties.Resources.OpenFile;
            this.OpenVideoButton.Location = new System.Drawing.Point(103, 74);
            this.OpenVideoButton.Name = "OpenVideoButton";
            this.OpenVideoButton.Size = new System.Drawing.Size(29, 30);
            this.OpenVideoButton.TabIndex = 29;
            this.OpenVideoButton.TabStop = false;
            this.OpenVideoButton.UseVisualStyleBackColor = false;
            this.OpenVideoButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenVideoButton_MouseDown);
            this.OpenVideoButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenVideoButton_MouseUp);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Image = global::MainScreen.Properties.Resources.buttonMinimize2;
            this.MinimizeButton.Location = new System.Drawing.Point(481, 86);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(20, 20);
            this.MinimizeButton.TabIndex = 28;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimizeButton_MouseDown);
            this.MinimizeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MinimizeButton_MouseUp);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = global::MainScreen.Properties.Resources.buttonExit2;
            this.ExitButton.Location = new System.Drawing.Point(510, 86);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(23, 23);
            this.ExitButton.TabIndex = 27;
            this.ExitButton.TabStop = false;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExitButton_MouseDown);
            this.ExitButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ExitButton_MouseUp);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.Transparent;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Image = global::MainScreen.Properties.Resources.buttonStop2;
            this.StopButton.Location = new System.Drawing.Point(189, 148);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(28, 23);
            this.StopButton.TabIndex = 26;
            this.StopButton.TabStop = false;
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StopButton_MouseDown);
            this.StopButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopButton_MouseUp);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.Transparent;
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseButton.Image = global::MainScreen.Properties.Resources.buttonPause2;
            this.PauseButton.Location = new System.Drawing.Point(152, 148);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(28, 23);
            this.PauseButton.TabIndex = 25;
            this.PauseButton.TabStop = false;
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PauseButton_MouseDown);
            this.PauseButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PauseButton_MouseUp);
            // 
            // FFButton
            // 
            this.FFButton.BackColor = System.Drawing.Color.Transparent;
            this.FFButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FFButton.Image = global::MainScreen.Properties.Resources.buttonFF2;
            this.FFButton.Location = new System.Drawing.Point(223, 148);
            this.FFButton.Name = "FFButton";
            this.FFButton.Size = new System.Drawing.Size(28, 23);
            this.FFButton.TabIndex = 23;
            this.FFButton.TabStop = false;
            this.FFButton.UseVisualStyleBackColor = false;
            this.FFButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FFButton_MouseDown);
            this.FFButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FFButton_MouseUp);
            // 
            // RewindButton
            // 
            this.RewindButton.BackColor = System.Drawing.Color.Transparent;
            this.RewindButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RewindButton.Image = global::MainScreen.Properties.Resources.RewindButton;
            this.RewindButton.Location = new System.Drawing.Point(260, 148);
            this.RewindButton.Name = "RewindButton";
            this.RewindButton.Size = new System.Drawing.Size(28, 23);
            this.RewindButton.TabIndex = 22;
            this.RewindButton.TabStop = false;
            this.RewindButton.UseVisualStyleBackColor = false;
            this.RewindButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RewindButton1_MouseDown);
            this.RewindButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RewindButton_MouseUp);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Image = global::MainScreen.Properties.Resources.PlayButtonLast;
            this.PlayButton.Location = new System.Drawing.Point(118, 148);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(28, 23);
            this.PlayButton.TabIndex = 21;
            this.PlayButton.TabStop = false;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayButton_MouseDown_1);
            this.PlayButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlayButton_MouseUp);
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
            this.VideoSlider.TabStop = false;
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
            this.VideoSlider.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CustomSlider1_MouseClick);
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
            this.Controls.Add(this.HideShowAudioFormButton);
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
        private CustomButton HideShowAudioFormButton;


    }
}
