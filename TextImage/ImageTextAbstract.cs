using System;
using System.Drawing;
using System.Text;

using TextImage.Extensions;
using TextImage.Interfaces;

namespace TextImage
{
    /// <summary>
    /// To be added.
    /// </summary>
    public abstract class ImageTextAbstract : IImageConverter
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public Bitmap Source { get; protected set; }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract char GetChar(int x, int y);

        /// <summary>
        /// To be added.
        /// </summary>
        public virtual void Validate()
        {
            var bpp = Source.BytesPerPixel();

            if (bpp != 3 && bpp != 4)
                throw new Exception("pixel format not supported.");
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="incX"></param>
        /// <param name="incY"></param>
        /// <returns></returns>
        protected virtual string CreateText(int incX, int incY)
        {
            Validate();

            var sb = new StringBuilder();
            for (var y = 0; y < Source.Height; y += incY)
            {
                for (var x = 0; x < Source.Width; x += incX)
                    sb.Append(GetChar(x, y));
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
