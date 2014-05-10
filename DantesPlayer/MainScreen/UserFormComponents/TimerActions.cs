using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MainScreen.UserFormComponents
{
    public class TimerActions
    {
        public MainScreen mainScreenInstance;

        private Timer timerForVideoTime = new Timer();
        private Timer timerForRF = new Timer();
        private Timer timerForVideoProgress = new Timer();
        private Timer timerForMouseFormMovement = new Timer();
        private Timer timerForMenuBar = new Timer();
        //private static int xPosition;
        //private static int yPosition;
        //private static Point formStartLocation;
        //private static Point startMouseLocation;

        //public TimerActions()
        //{
        //    timerForVideoTime = new Timer();
        //    timerForRF = new Timer();
        //    timerForVideoProgress = new Timer();
        //    timerForMouseFormMovement = new Timer();
        //    timerForMenuBar = new Timer();
        //    timerForVideoTime.Interval = 1000;
        //    timerForVideoTime.Tick += timerForVideoTime_Tick;
        //    timerForMouseFormMovement.Interval = 1;
        //    timerForMouseFormMovement.Tick += timerForMouseFormMovementTick;
        //    timerForRF.Interval = 1000;
        //    timerForRF.Tick += timer_Tick;
        //    timerForVideoProgress.Interval = 1000;
        //    timerForVideoProgress.Tick += timerForVideoProgress_Tick;
        //    timerForMenuBar.Interval = 500;
        //    timerForMenuBar.Tick += timerForMenuBar_Tick;
        //}

    //    void timerForMenuBar_Tick(object sender, EventArgs e)
    //    {
    //        Console.WriteLine(this.IsActive(HolderForm.holderForm.Handle));
    //        if (CheckException.CheckNull(video.DirectVideo) && !HolderForm.holderForm.IsDisposed)
    //        {
    //            if (Cursor.Position.Y > Screen.PrimaryScreen.WorkingArea.Height - 100)
    //            {
    //                if (!menuBar.IsDisposed)
    //                {
    //                    if (this.IsActive(HolderForm.holderForm.Handle) || this.IsActive(menuBar.Handle))
    //                    {
    //                        menuBar.Show();
    //                        menuBar.BringToFront();
    //                        menuBar.TopMost = true;
    //                        Console.WriteLine(HolderForm.holderForm.TopLevel);
    //                        menuBar.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 3, Screen.PrimaryScreen.WorkingArea.Height - 40);
    //                    }
    //                }
    //                else
    //                {
    //                    timerForMenuBar.Stop();
    //                    menuBar = null;
    //                }
    //            }
    //            else
    //            {
    //                menuBar.Hide();
    //            }
    //        }
    //        else
    //        {
    //            if (HolderForm.holderForm.IsDisposed)
    //            {
    //                timerForVideoProgress.Stop();
    //            }
    //            timerForMenuBar.Stop();
    //            menuBar.Dispose();
    //            menuBar = null;
    //        }
    //    }

    //    /// <summary>
    //    /// clears all timers except click timer, method for event
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    public void ClearTimers(object sender, EventArgs e)
    //    {
    //        timerForVideoProgress.Stop();
    //        timerForRF.Stop();
    //        timerForVideoTime.Stop();
    //    }

    //    /// <summary>
    //    /// Calls the method that writes the video time; method for event
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void timerForVideoTime_Tick(object sender, EventArgs e)
    //    {
    //        this.WriteVideoTime();
    //    }


    //    /// <summary>
    //    /// Writes to a label where the video is
    //    /// at the given moment
    //    /// </summary>
    //    public void WriteVideoTime()
    //    {
    //        this.label1.Text = "00:00:";
    //        if (video.DirectVideo.CurrentPosition < 10)
    //        {
    //            this.label1.Text += "0";
    //        }
    //        this.label1.Text += String.Format("{0:0}", video.DirectVideo.CurrentPosition);
    //        this.label1.Text = this.label1.Text.Replace('.', ':');
    //        this.label1.Text += String.Format("/00:00:{0:0}", video.DirectVideo.Duration);
    //    }

    //    /// <summary>
    //    /// On left mouse hold and movement in the form
    //    /// moves the form with the mouse
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void timerForMouseFormMovementTick(object sender, EventArgs e)
    //    {
    //        xPosition = formStartLocation.X + Cursor.Position.X - startMouseLocation.X;
    //        yPosition = formStartLocation.Y + Cursor.Position.Y - startMouseLocation.Y;
    //        this.Location = new Point(xPosition, yPosition);
    //    }

    //    /// <summary>
    //    /// Fixes the slider and the video
    //    /// so they go correctly together;
    //    /// event method
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void timerForVideoProgress_Tick(object sender, EventArgs e)
    //    {
    //        if (CheckException.CheckNull(video))
    //        {
    //            if (CheckException.CheckNull(video.DirectVideo))
    //            {
    //                HolderForm.HandleVideoProgress(this.VideoSlider, video.DirectVideo);
    //            }
    //            else
    //            {
    //                timerForVideoProgress.Stop();
    //            }
    //        }
    //        else
    //        {
    //            timerForVideoProgress.Stop();
    //        }

    //    }

    //    /// <summary>
    //    /// rewind and fast forward fix up;
    //    /// event method
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void timer_Tick(object sender, EventArgs e)
    //    {
    //        if (fastForwardFired)
    //        {
    //            if (CheckException.CheckNull(video))
    //            {
    //                video.FastForward();
    //                if (video.Speed == 0)
    //                {
    //                    timerForRF.Stop();
    //                }
    //            }
    //        }

    //        if (rewindFired)
    //        {
    //            if (CheckException.CheckNull(video))
    //            {
    //                video.Rewind();
    //                if (video.Speed == 0)
    //                {
    //                    timerForRF.Stop();
    //                }
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Opens a dialog and starts the chosen video
    //    /// DIRECT VIDEO ENDING DELEGATE IS GIVEN THE CLEAR TIMERS HERE
    //    /// event method
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>

    //    public void DirectVideo_Ending(object sender, EventArgs e)
    //    {
    //        timerForVideoTime.Stop();
    //        timerForVideoProgress.Stop();
    //        timerForMenuBar.Stop();
    //    }
    }
}
