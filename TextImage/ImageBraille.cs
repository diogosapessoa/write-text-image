using System;
using System.Drawing;

namespace TextImage
{
    /// <summary>
    /// To be added.
    /// </summary>
    public sealed class ImageBraille : ImageTextAbstract
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public byte Threshold { get; }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="threshold"></param>
        public ImageBraille(Bitmap source, byte threshold = 127)
        {
            Source = source;
            Threshold = threshold;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override char GetChar(int x, int y)
        {
            double value = 0d;

            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 2; j++)
                {
                    var color = Source.GetPixel(j + x, i + y);
                    var average = (color.R + color.G + color.B) * 0.33333f;
                    if (average >= Threshold)
                        value += Math.Pow(2, 5 - i);
                }

            var brailleBinaryValue = (int)value;
            return brailleBinaryValue == 0 ? '⠄' : (char)(10240 + brailleBinaryValue);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        public override void Validate()
        {
            base.Validate();

            if (Source.Width % 2 != 0 || Source.Height % 3 != 0)
                throw new Exception("use width muliple of 2 and height of 3.");
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CreateText(2, 3);
        }
    }
}
