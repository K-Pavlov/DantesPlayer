namespace MainScreen.CustomControls
{
    #region Namespaces
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    #endregion

    /// <summary>
    /// Draws aqua pills
    /// </summary>
    internal static class DrawStyleHelper
    {
        /// <summary>
        /// Draws the aqua pill
        /// </summary>
        /// <param name="graphicsDevice">Graphics device</param>
        /// <param name="drawRectF">Float rectangle</param>
        /// <param name="drawColor">A Color</param>
        /// <param name="orientation">Enumeration orientation</param>
        public static void DrawAquaPill(Graphics graphicsDevice, RectangleF drawRectF, Color drawColor, Orientation orientation)
        {
            Color color1;
            Color color2;
            Color color3;
            Color color4;
            Color color5;
            System.Drawing.Drawing2D.LinearGradientBrush gradientBrush;
            System.Drawing.Drawing2D.ColorBlend colorBlend = new System.Drawing.Drawing2D.ColorBlend();
            color1 = ColorHelper.OpacityMix(Color.White, ColorHelper.SoftLightMix(drawColor, Color.Black, 100), 40);
            color2 = ColorHelper.OpacityMix(Color.White, ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColor(64, 64, 64), 100), 20);
            color3 = ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColor(128, 128, 128), 100);
            color4 = ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColor(192, 192, 192), 100);
            color5 = ColorHelper.OverlayMix(ColorHelper.SoftLightMix(drawColor, Color.White, 100), Color.White, 75);
            colorBlend.Colors = new Color[] { color1, color2, color3, color4, color5 };
            colorBlend.Positions = new float[] { 0, 0.25f, 0.5f, 0.75f, 1 };
            if (orientation == Orientation.Horizontal)
            {
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top - 1), new Point((int)drawRectF.Left, (int)drawRectF.Top + (int)drawRectF.Height + 1), color1, color5);
            }
            else
            {
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left - 1, (int)drawRectF.Top), new Point((int)drawRectF.Left + (int)drawRectF.Width + 1, (int)drawRectF.Top), color1, color5);
            }

            gradientBrush.InterpolationColors = colorBlend;
            FillPill(gradientBrush, drawRectF, graphicsDevice);
            color2 = Color.White;
            colorBlend.Colors = new Color[] { color2, color3, color4, color5 };
            colorBlend.Positions = new float[] { 0, 0.5f, 0.75f, 1 };
            if (orientation == Orientation.Horizontal)
            {
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left + 1, (int)drawRectF.Top), new Point((int)drawRectF.Left + 1, (int)drawRectF.Top + (int)drawRectF.Height - 1), color2, color5);
            }
            else
            {
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top + 1), new Point((int)drawRectF.Left + (int)drawRectF.Width - 1, (int)drawRectF.Top + 1), color2, color5);
            }

            gradientBrush.InterpolationColors = colorBlend;
            FillPill(gradientBrush, RectangleF.Inflate(drawRectF, -3, -3), graphicsDevice);
        }

        /// <summary>
        /// Draws the aqua pull single layer
        /// </summary>
        /// <param name="graphicsDevice">Graphics device</param>
        /// <param name="drawRectF">Float rectangle</param>
        /// <param name="drawColor">A Color</param>
        /// <param name="orientation">Enumeration Orientation</param>
        public static void DrawAquaPillSingleLayer(Graphics graphicsDevice, RectangleF drawRectF, Color drawColor, Orientation orientation)
        {
            Color color1;
            Color color2;
            Color color3;
            Color color4;
            System.Drawing.Drawing2D.LinearGradientBrush gradientBrush;
            System.Drawing.Drawing2D.ColorBlend colorBlend = new System.Drawing.Drawing2D.ColorBlend();
            color1 = drawColor;
            color2 = ControlPaint.Light(color1);
            color3 = ControlPaint.Light(color2);
            color4 = ControlPaint.Light(color3);
            colorBlend.Colors = new Color[] { color1, color2, color3, color4 };
            colorBlend.Positions = new float[] { 0, 0.25f, 0.65f, 1 };
            if (orientation == Orientation.Horizontal)
            {
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top), new Point((int)drawRectF.Left, (int)drawRectF.Top + (int)drawRectF.Height), color1, color4);
            }
            else
            {
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top), new Point((int)drawRectF.Left + (int)drawRectF.Width, (int)drawRectF.Top), color1, color4);
            }

            gradientBrush.InterpolationColors = colorBlend;
            FillPill(gradientBrush, drawRectF, graphicsDevice);
        }

        /// <summary>
        /// Fills the aqua pill
        /// </summary>
        /// <param name="brush">A Brush</param>
        /// <param name="rectangle">Float rectangle</param>
        /// <param name="graphicsDivice">Graphics device</param>
        public static void FillPill(Brush brush, RectangleF rectangle, Graphics graphicsDivice)
        {
            if (rectangle.Width > rectangle.Height)
            {
                graphicsDivice.SmoothingMode = SmoothingMode.HighQuality;
                graphicsDivice.FillEllipse(brush, new RectangleF(rectangle.Left, rectangle.Top, rectangle.Height, rectangle.Height));
                graphicsDivice.FillEllipse(brush, new RectangleF(rectangle.Left + rectangle.Width - rectangle.Height, rectangle.Top, rectangle.Height, rectangle.Height));

                float w = rectangle.Width - rectangle.Height;
                float l = rectangle.Left + (rectangle.Height / 2);
                graphicsDivice.FillRectangle(brush, new RectangleF(l, rectangle.Top, w, rectangle.Height));
                graphicsDivice.SmoothingMode = SmoothingMode.Default;
            }
            else if (rectangle.Width < rectangle.Height)
            {
                graphicsDivice.SmoothingMode = SmoothingMode.HighQuality;
                graphicsDivice.FillEllipse(brush, new RectangleF(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Width));
                graphicsDivice.FillEllipse(brush, new RectangleF(rectangle.Left, rectangle.Top + rectangle.Height - rectangle.Width, rectangle.Width, rectangle.Width));

                float t = rectangle.Top + (rectangle.Width / 2);
                float h = rectangle.Height - rectangle.Width;
                graphicsDivice.FillRectangle(brush, new RectangleF(rectangle.Left, t, rectangle.Width, h));
                graphicsDivice.SmoothingMode = SmoothingMode.Default;
            }
            else if (rectangle.Width == rectangle.Height)
            {
                graphicsDivice.SmoothingMode = SmoothingMode.HighQuality;
                graphicsDivice.FillEllipse(brush, rectangle);
                graphicsDivice.SmoothingMode = SmoothingMode.Default;
            }
        }
    }
}
