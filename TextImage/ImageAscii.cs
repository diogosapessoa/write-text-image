using System.Drawing;

namespace TextImage
{
    /// <summary>
    /// To be added.
    /// </summary>
    public sealed class ImageAscii : ImageTextAbstract
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public const string palette = " .:-=+*#%@";

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="source"></param>
        public ImageAscii(Bitmap source)
        {
            Source = source;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override char GetChar(int x, int y)
        {
            var color = Source.GetPixel(x, y);
            var average = (color.R + color.G + color.B) * 0.33333;
            int index = (int)((palette.Length * average) / byte.MaxValue);
            return palette[index];
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CreateText(1, 2);
        }
    }
}
