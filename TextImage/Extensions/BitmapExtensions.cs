using System.Drawing;
using System.Drawing.Imaging;

namespace TextImage.Extensions
{
    /// <summary>
    /// To be added.
    /// </summary>
    public static class BitmapExtensions
    {
        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static int BytesPerPixel(this Bitmap bitmap)
        {
            switch (bitmap.PixelFormat)
            {
                case PixelFormat.Format8bppIndexed:
                    return 1;
                case PixelFormat.Format24bppRgb:
                    return 3;
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
