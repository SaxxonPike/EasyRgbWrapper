namespace EasyRgbWrapper.Lib
{
    public struct RgbEasyCropping
    {
        public RgbEasyCropping(int top, int left, int width, int height)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        public int Top { get; }
        public int Left { get; }
        public int Width { get; }
        public int Height { get; }
    }
}