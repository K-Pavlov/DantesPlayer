namespace MainScreen.CustomControls
{
    #region Namespaces
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    #endregion 

    /// <summary>
    /// Round Button
    /// </summary>
    class CustomButton : Button
    {
        /// <summary>
        /// Ovverides the on paint the make
        /// the buttom round, then calls the base
        /// method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }

        public override void NotifyDefault(bool value)
        {
        }

    }
}
