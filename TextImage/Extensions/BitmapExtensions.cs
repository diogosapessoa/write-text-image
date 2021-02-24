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
            return bitmap.PixelFormat switch
            {
                PixelFormat.Format8bppIndexed => 1,
                PixelFormat.Format24bppRgb => 3,
                PixelFormat.Format32bppArgb or PixelFormat.Format32bppPArgb => 4,
                _ => 0,
            };
        }
    }
}
