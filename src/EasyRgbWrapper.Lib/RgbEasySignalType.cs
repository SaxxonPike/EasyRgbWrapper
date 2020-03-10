using Datapath.RGBEasy;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

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

        public override string ToString() => 
            $"{Type}: {Width}x{Height} @ {RefreshRate}hz";
    }
}