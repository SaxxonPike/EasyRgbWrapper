// ReSharper disable UnusedMember.Global

namespace EasyRgbWrapper.Lib
{
    public interface IRgbEasyCaptureCard
    {
        int InputCount { get; }
        bool IsDirectDmaSupported { get; }
        bool IsDeinterlaceSupported { get; }
        bool IsYuvSupported { get; }
    }
}