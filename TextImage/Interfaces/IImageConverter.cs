namespace TextImage.Interfaces
{
    /// <summary>
    /// To be added.
    /// </summary>
    public interface IImageConverter
    {
        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        char GetChar(int x, int y);

        /// <summary>
        /// To be added.
        /// </summary>
        void Validate();
    }
}
