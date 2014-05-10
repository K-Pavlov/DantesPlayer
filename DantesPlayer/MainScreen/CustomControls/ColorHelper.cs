namespace MainScreen.CustomControls
{
    #region Namespaces
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    #endregion 

    /// <summary>
    /// Static class which is for color creation
    /// </summary>
    internal static class ColorHelper
    {
        /// <summary>
        /// Does the overlay math
        /// </summary>
        /// <param name="ibase">integer base</param>
        /// <param name="blend">integer blend</param>
        /// <returns>Integer overlay math</returns>
        public static int OverlayMath(int ibase, int blend)
        {
            double dbase;
            double dblend;
            dbase = (double)ibase / 255;
            dblend = (double)blend / 255;
            if (dbase < 0.5)
            {
                return (int)((2 * dbase * dblend) * 255);
            }
            else
            {
                return (int)((1 - (2 * (1 - dbase) * (1 - dblend))) * 255);
            }
        }

        /// <summary>
        /// Creates a rgb color
        /// </summary>
        /// <param name="redC">Integer value</param>
        /// <param name="greenC">Integer value</param>
        /// <param name="blueC">Integer value</param>
        /// <returns>Returns a Color</returns>
        public static Color CreateColor(int redC, int greenC, int blueC)
        {
            int red = redC;
            int green = greenC;
            int blue = blueC;
            CheckColor(ref red);
            CheckColor(ref green);
            CheckColor(ref blue);
            return Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// Creates an opacity mix, ugly
        /// </summary>
        /// <param name="blendColor">Color, The blend Color</param>
        /// <param name="baseColor">Color, The base Color</param>
        /// <param name="opacity">Integer opacity</param>
        /// <returns>A color</returns>
        public static Color OpacityMix(Color blendColor, Color baseColor, int opacity)
        {
            int red1, red2, red3;
            int blue1, blue2, blue3;
            int green1, green2, green3;
            red1 = blendColor.R;
            green1 = blendColor.G;
            blue1 = blendColor.B;
            red2 = baseColor.R;
            green2 = baseColor.G;
            blue2 = baseColor.B;
            red3 = (int)(((red1 * ((float)opacity / 100)) + (red2 * (1 - ((float)opacity / 100)))));
            green3 = (int)(((green1 * ((float)opacity / 100)) + (green2 * (1 - ((float)opacity / 100)))));
            blue3 = (int)(((blue1 * ((float)opacity / 100)) + (blue2 * (1 - ((float)opacity / 100)))));
            return CreateColor(red3, green3, blue3);
        }

        /// <summary>
        /// Creates a soft light mix
        /// </summary>
        /// <param name="baseColor">Color, The blend Color</param>
        /// <param name="blendColor">Color, The base Color</param>
        /// <param name="opacity">Integer opacity</param>
        /// <returns>A Color</returns>
        public static Color SoftLightMix(Color baseColor, Color blendColor, int opacity)
        {
            int red1;
            int green1;
            int blue1;
            int red2;
            int green2;
            int blue2;
            int red3;
            int green3;
            int blue3;
            red1 = baseColor.R;
            green1 = baseColor.G;
            blue1 = baseColor.B;
            red2 = blendColor.R;
            green2 = blendColor.G;
            blue2 = blendColor.B;
            red3 = SoftLightMath(red1, red2);
            green3 = SoftLightMath(green1, green2);
            blue3 = SoftLightMath(blue1, blue2);
            return OpacityMix(CreateColor(red3, green3, blue3), baseColor, opacity);
        }

        /// <summary>
        /// Creates a overlay mix
        /// </summary>
        /// <param name="baseColor">Color, The blend Color</param>
        /// <param name="blendColor">Color, The base Color</param>
        /// <param name="opacity">Integer opacity</param>
        /// <returns>A Color</returns>
        public static Color OverlayMix(Color baseColor, Color blendColor, int opacity)
        {
            int red1;
            int green1;
            int blue1;
            int red2;
            int green2;
            int blue2;
            int red3;
            int green3;
            int blue3;
            red1 = baseColor.R;
            green1 = baseColor.G;
            blue1 = baseColor.B;
            red2 = blendColor.R;
            green2 = blendColor.G;
            blue2 = blendColor.B;
            red3 = OverlayMath(baseColor.R, blendColor.R);
            green3 = OverlayMath(baseColor.G, blendColor.G);
            blue3 = OverlayMath(baseColor.B, blendColor.B);
            return OpacityMix(CreateColor(red3, green3, blue3), baseColor, opacity);
        }

        /// <summary>
        /// Does the soft light math
        /// </summary>
        /// <param name="ibase">Integer value</param>
        /// <param name="blend">Integer value</param>
        /// <returns>Integer value</returns>
        private static int SoftLightMath(int ibase, int blend)
        {
            float dbase;
            float dblend;
            dbase = (float)ibase / 255;
            dblend = (float)blend / 255;
            if (dblend < 0.5)
            {
                return (int)(((2 * dbase * dblend) + (Math.Pow(dbase, 2)) * (1 - (2 * dblend))) * 255);
            }
            else
            {
                return (int)(((Math.Sqrt(dbase) * (2 * dblend - 1)) + ((2 * dbase) * (1 - dblend))) * 255);
            }
        }

        /// <summary>
        /// Checks if color is in 0 .. 255 bounds
        /// </summary>
        /// <param name="color">A integer value</param>
        private static void CheckColor(ref int color)
        {
            if (color > 255)
            {
                color = 255;
            }
            else if (color < 0)
            {
                color = 0;
            }
        }
    }
}
