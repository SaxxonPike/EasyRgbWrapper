using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    public struct RgbEasySignalType
    {
        public RgbEasySignalType(int width, int height, int refreshRate, SIGNALTYPE type)
        {
            Width = width;
            Height = height;
            RefreshRate = refreshRate;
            Type = type;
        }
        
        public SIGNALTYPE Type { get; }
        public int Width { get; }
        public int Height { get; }
        public int RefreshRate { get; }
    }
}