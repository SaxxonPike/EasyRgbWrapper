// ReSharper disable UnusedMember.Global

namespace EasyRgbWrapper.Lib
{
    public interface IRgbEasyInput
    {
        bool IsVgaSupported { get; }
        bool IsDviSupported { get; }
        bool IsComponentSupported { get; }
        bool IsCompositeSupported { get; }
        bool IsSvideoSupported { get; }
        RgbEasySignalType Signal { get; }
        int Number { get; }
        IRgbEasyCapture OpenCapture();
    }
}