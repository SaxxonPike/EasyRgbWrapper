using System;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    public interface IRgbEasyCapture : IDisposable
    {
        event EventHandler<RgbEasyFrameCapturedEventArgs> FrameCaptured;
        event EventHandler<RgbEasyModeChangedEventArgs> ModeChanged;
        
        bool EnableFrameCapturedEvent { set; }
        bool EnableModeChangedEvent { set; }
        int HorizontalScaleMinimum { get; }
        int HorizontalScaleMaximum { get; }
        int HorizontalScaleDefault { get; }
        int HorizontalScale { get; set; }
        int HorizontalPositionMinimum { get; }
        int HorizontalPositionMaximum { get; }
        int HorizontalPositionDefault { get; }
        int HorizontalPosition { get; set; }
        int VerticalPositionMinimum { get; }
        int VerticalPositionMaximum { get; }
        int VerticalPositionDefault { get; }
        int VerticalPosition { get; set; }
        int CaptureWidthMinimum { get; }
        int CaptureWidthMaximum { get; }
        int CaptureWidthDefault { get; }
        int CaptureWidth { get; set; }
        int CaptureHeightMinimum { get; }
        int CaptureHeightMaximum { get; }
        int CaptureHeightDefault { get; }
        int CaptureHeight { get; set; }
        int BrightnessMinimum { get; }
        int BrightnessMaximum { get; }
        int BrightnessDefault { get; }
        int Brightness { get; set; }
        int ContrastMinimum { get; }
        int ContrastMaximum { get; }
        int ContrastDefault { get; }
        int Contrast { get; set; }
        RgbEasyColorBalance ColourBalanceMinimum { get; }
        RgbEasyColorBalance ColourBalanceMaximum { get; }
        RgbEasyColorBalance ColourBalanceDefault { get; }
        RgbEasyColorBalance ColourBalance { get; set; }
        int BlackLevelMinimum { get; }
        int BlackLevelMaximum { get; }
        int BlackLevelDefault { get; }
        int BlackLevel { get; set; }
        int PhaseMinimum { get; }
        int PhaseMaximum { get; }
        int PhaseDefault { get; }
        int Phase { get; set; }
        int SaturationMinimum { get; }
        int SaturationMaximum { get; }
        int SaturationDefault { get; }
        int Saturation { get; set; }
        int HueMinimum { get; }
        int HueMaximum { get; }
        int HueDefault { get; }
        int Hue { get; set; }
        int VideoStandard { get; set; }
        void TestVideoStandard(int videoStandard);
        int FrameDroppingMinimum { get; }
        int FrameDroppingMaximum { get; }
        int FrameDroppingDefault { get; }
        int FrameDropping { get; set; }
        int FrameRate { get; }
        RgbEasyCropping CroppingMinimum { get; }
        RgbEasyCropping CroppingMaximum { get; }
        RgbEasyCropping CroppingDefault { get; }
        RgbEasyCropping Cropping { get; set; }
        void TestCropping(RgbEasyCropping cropping);
        bool IsCroppingEnabled { get; set; }
        DEINTERLACE Deinterlace { get; set; }
        void Pause();
        void Resume();
        CAPTURESTATE CaptureState { get; }
        int MessageDelay { get; set; }
        PIXELFORMAT PixelFormat { get; set; }
        void DetectInput();
        void Reset();
        int Input { get; set; }
        IntPtr Window { get; set; }
        void Start();
        void Stop();
    }
}