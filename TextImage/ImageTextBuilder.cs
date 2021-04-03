using System;
using System.Drawing;

using TextImage.Enums;

namespace TextImage
{
    /// <summary>
    /// To be added.
    /// </summary>
    public sealed class ImageTextBuilder : IDisposable
    {
        private Bitmap _source;

        private byte _threshold = 127;

        private ImageTextAbstract _imageText;

        /// <summary>
        /// To be added.
        /// </summary>
        public ImageTextBuilder() { }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ImageTextBuilder WithSource(Bitmap source)
        {
            _source = source;
            return this;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="fileImage"></param>
        /// <returns></returns>
        public ImageTextBuilder WithSource(string fileImage)
        {
            _source = (Bitmap)Image.FromFile(fileImage);
            return this;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public ImageTextBuilder WithThreshold(byte threshold)
        {
            _threshold = threshold;
            return this;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public ImageTextBuilder WithFormat(ImageTextFormat format)
        {
            if (_source == null)
                throw new NullReferenceException("call 'WithSource' first.");

            _imageText = format switch
            {
                ImageTextFormat.Ascii => new ImageAscii(_source),
                ImageTextFormat.Braille => new ImageBraille(_source, _threshold),
                _ => throw new ArgumentNullException(nameof(format)),
            };

            return this;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            return _imageText?.ToString();
        }

        /// <summary>
        /// To be added.
        /// </summary>
        public void Dispose()
        {
            _source?.Dispose();
        }
    }
}
