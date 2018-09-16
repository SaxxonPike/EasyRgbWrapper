using System;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    public class RgbEasyCapture : IRgbEasyCapture
    {
        public event EventHandler<RgbEasyFrameCapturedEventArgs> FrameCaptured;
        public event EventHandler<RgbEasyModeChangedEventArgs> ModeChanged;

        private readonly IntPtr _handle;

        public RgbEasyCapture(int inputIndex)
        {
            var error = RGB.OpenInput((uint) inputIndex, out var handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
            _handle = handle;
        }

        private void OnModeChanged(IntPtr hwnd, IntPtr hrgb, ref RGBMODECHANGEDINFO modechangedinfo, IntPtr userdata) => 
            ModeChanged?.Invoke(this, 
                new RgbEasyModeChangedEventArgs(hwnd, this, modechangedinfo, userdata));

        private void OnFrameCaptured(IntPtr hwnd, IntPtr hrgb, ref BITMAPINFOHEADER bitmapinfo, IntPtr bitmapbits, IntPtr userdata) =>
            FrameCaptured?.Invoke(this, 
                new RgbEasyFrameCapturedEventArgs(hwnd, this, bitmapinfo, bitmapbits, userdata));

        public bool EnableFrameCapturedEvent
        {
            set
            {
                var error = RGB.SetFrameCapturedFn(_handle, value ? OnFrameCaptured : (RGBFRAMECAPTUREDFN)null, IntPtr.Zero);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public bool EnableModeChangedEvent
        {
            set
            {
                var error = RGB.SetModeChangedFn(_handle, value ? OnModeChanged : (RGBMODECHANGEDFN)null, IntPtr.Zero);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int HorizontalScaleMinimum
        {
            get
            {
                var error = RGB.GetHorScaleMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int HorizontalScaleMaximum
        {
            get
            {
                var error = RGB.GetHorScaleMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int HorizontalScaleDefault
        {
            get
            {
                var error = RGB.GetHorScaleDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int HorizontalScale
        {
            get
            {
                var error = RGB.GetHorScale(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                var error = RGB.SetHorScale(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int HorizontalPositionMinimum
        {
            get
            {
                var error = RGB.GetHorPositionMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int HorizontalPositionMaximum
        {
            get
            {
                var error = RGB.GetHorPositionMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int HorizontalPositionDefault
        {
            get
            {
                var error = RGB.GetHorPositionDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int HorizontalPosition
        {
            get
            {
                var error = RGB.GetHorPosition(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetHorPosition(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int VerticalPositionMinimum
        {
            get
            {
                var error = RGB.GetVerPositionMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int VerticalPositionMaximum
        {
            get
            {
                var error = RGB.GetVerPositionMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int VerticalPositionDefault
        {
            get
            {
                var error = RGB.GetVerPositionDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int VerticalPosition
        {
            get
            {
                var error = RGB.GetVerPosition(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetVerPosition(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int CaptureWidthMinimum
        {
            get
            {
                var error = RGB.GetCaptureWidthMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int CaptureWidthMaximum
        {
            get
            {
                var error = RGB.GetCaptureWidthMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int CaptureWidthDefault
        {
            get
            {
                var error = RGB.GetCaptureWidthDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int CaptureWidth
        {
            get
            {
                var error = RGB.GetCaptureWidth(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                var error = RGB.SetCaptureWidth(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int CaptureHeightMinimum
        {
            get
            {
                var error = RGB.GetCaptureHeightMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int CaptureHeightMaximum
        {
            get
            {
                var error = RGB.GetCaptureHeightMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int CaptureHeightDefault
        {
            get
            {
                var error = RGB.GetCaptureHeightDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int CaptureHeight
        {
            get
            {
                var error = RGB.GetCaptureHeight(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                var error = RGB.SetCaptureHeight(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int BrightnessMinimum
        {
            get
            {
                var error = RGB.GetBrightnessMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int BrightnessMaximum
        {
            get
            {
                var error = RGB.GetBrightnessMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int BrightnessDefault
        {
            get
            {
                var error = RGB.GetBrightnessDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int Brightness
        {
            get
            {
                var error = RGB.GetBrightness(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetBrightness(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int ContrastMinimum
        {
            get
            {
                var error = RGB.GetContrastMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int ContrastMaximum
        {
            get
            {
                var error = RGB.GetContrastMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int ContrastDefault
        {
            get
            {
                var error = RGB.GetContrastDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int Contrast
        {
            get
            {
                var error = RGB.GetContrast(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetContrast(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public RgbEasyColorBalance ColourBalanceMinimum
        {
            get
            {
                var error = RGB.GetColourBalanceMinimum(_handle, out var brightnessRed, out var brightnessGreen,
                    out var brightnessBlue, out var contrastRed, out var contrastGreen, out var contrastBlue);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyColorBalance(brightnessRed, brightnessGreen, brightnessBlue, contrastRed,
                    contrastGreen, contrastBlue);
            }
        }

        public RgbEasyColorBalance ColourBalanceMaximum
        {
            get
            {
                var error = RGB.GetColourBalanceMaximum(_handle, out var brightnessRed, out var brightnessGreen,
                    out var brightnessBlue, out var contrastRed, out var contrastGreen, out var contrastBlue);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyColorBalance(brightnessRed, brightnessGreen, brightnessBlue, contrastRed,
                    contrastGreen, contrastBlue);
            }
        }

        public RgbEasyColorBalance ColourBalanceDefault
        {
            get
            {
                var error = RGB.GetColourBalanceDefault(_handle, out var brightnessRed, out var brightnessGreen,
                    out var brightnessBlue, out var contrastRed, out var contrastGreen, out var contrastBlue);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyColorBalance(brightnessRed, brightnessGreen, brightnessBlue, contrastRed,
                    contrastGreen, contrastBlue);
            }
        }

        public RgbEasyColorBalance ColourBalance
        {
            get
            {
                var error = RGB.GetColourBalance(_handle, out var brightnessRed, out var brightnessGreen,
                    out var brightnessBlue, out var contrastRed, out var contrastGreen, out var contrastBlue);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyColorBalance(brightnessRed, brightnessGreen, brightnessBlue, contrastRed,
                    contrastGreen, contrastBlue);
            }
            set
            {
                var error = RGB.SetColourBalance(_handle, value.BrightnessRed, value.BrightnessGreen,
                    value.BrightnessBlue, value.ContrastRed, value.ContrastGreen, value.ContrastBlue);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int BlackLevelMinimum
        {
            get
            {
                var error = RGB.GetBlackLevelMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int BlackLevelMaximum
        {
            get
            {
                var error = RGB.GetBlackLevelMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int BlackLevelDefault
        {
            get
            {
                var error = RGB.GetBlackLevelDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int BlackLevel
        {
            get
            {
                var error = RGB.GetBlackLevel(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetBlackLevel(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int PhaseMinimum
        {
            get
            {
                var error = RGB.GetPhaseMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int PhaseMaximum
        {
            get
            {
                var error = RGB.GetPhaseMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int PhaseDefault
        {
            get
            {
                var error = RGB.GetPhaseDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int Phase
        {
            get
            {
                var error = RGB.GetPhase(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetPhase(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int SaturationMinimum
        {
            get
            {
                var error = RGB.GetSaturationMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int SaturationMaximum
        {
            get
            {
                var error = RGB.GetSaturationMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int SaturationDefault
        {
            get
            {
                var error = RGB.GetSaturationDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int Saturation
        {
            get
            {
                var error = RGB.GetSaturation(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetSaturation(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int HueMinimum
        {
            get
            {
                var error = RGB.GetHueMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int HueMaximum
        {
            get
            {
                var error = RGB.GetHueMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int HueDefault
        {
            get
            {
                var error = RGB.GetHueDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        public int Hue
        {
            get
            {
                var error = RGB.GetHue(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetHue(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int VideoStandard
        {
            get
            {
                var error = RGB.GetVideoStandard(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                var error = RGB.SetVideoStandard(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void TestVideoStandard(int videoStandard)
        {
            var error = RGB.TestVideoStandard(_handle, (uint) videoStandard);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public int FrameDroppingMinimum
        {
            get
            {
                var error = RGB.GetFrameDroppingMinimum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int FrameDroppingMaximum
        {
            get
            {
                var error = RGB.GetFrameDroppingMaximum(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int FrameDroppingDefault
        {
            get
            {
                var error = RGB.GetFrameDroppingDefault(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public int FrameDropping
        {
            get
            {
                var error = RGB.GetFrameDropping(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                var error = RGB.SetFrameDropping(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int FrameRate
        {
            get
            {
                var error = RGB.GetFrameRate(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public RgbEasyCropping CroppingMinimum
        {
            get
            {
                var error = RGB.GetCroppingMinimum(_handle, out var top, out var left, out var width, out var height);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyCropping(top, left, (int) width, (int) height);
            }
        }

        public RgbEasyCropping CroppingMaximum
        {
            get
            {
                var error = RGB.GetCroppingMaximum(_handle, out var top, out var left, out var width, out var height);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyCropping(top, left, (int) width, (int) height);
            }
        }

        public RgbEasyCropping CroppingDefault
        {
            get
            {
                var error = RGB.GetCroppingDefault(_handle, out var top, out var left, out var width, out var height);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyCropping(top, left, (int) width, (int) height);
            }
        }

        public RgbEasyCropping Cropping
        {
            get
            {
                var error = RGB.GetCropping(_handle, out var top, out var left, out var width, out var height);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyCropping(top, left, (int) width, (int) height);
            }
            set
            {
                var error = RGB.SetCropping(_handle, value.Top, value.Left, (uint) value.Width, (uint) value.Height);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void TestCropping(RgbEasyCropping cropping)
        {
            var error = RGB.TestCropping(_handle, cropping.Top, cropping.Left, (uint) cropping.Width,
                (uint) cropping.Height);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public bool IsCroppingEnabled
        {
            get
            {
                var error = RGB.IsCroppingEnabled(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
            set
            {
                var error = RGB.EnableCropping(_handle, (uint) (value ? 1 : 0));
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public DEINTERLACE Deinterlace
        {
            get
            {
                var error = RGB.GetDeinterlace(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetDeinterlace(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void Pause()
        {
            var error = RGB.PauseCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public void Resume()
        {
            var error = RGB.ResumeCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public CAPTURESTATE CaptureState
        {
            get
            {
                var error = RGB.GetCaptureState(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        /// <summary>
        /// TODO:
        /// Document this better -
        /// Use negative values to disable messages
        /// </summary>
        public int MessageDelay
        {
            get
            {
                var error = RGB.GetMessageDelay(_handle, out var enabled, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return enabled > 0 ? (int) result : -1;
            }
            set
            {
                var error = RGB.SetMessageDelay(_handle, value >= 0 ? 1 : 0, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public PIXELFORMAT PixelFormat
        {
            get
            {
                var error = RGB.GetPixelformat(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                var error = RGB.SetPixelformat(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        // TODO: next item is RGBSaveCurrentFrame

        public void DetectInput()
        {
            var error = RGB.DetectInput(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public void Reset()
        {
            var error = RGB.ResetCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public int Input
        {
            get
            {
                var error = RGB.GetInput(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                var error = RGB.SetInput(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public IntPtr Window
        {
            get
            {
                var error = RGB.GetWindow(_handle, out var hwnd);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return hwnd;
            }
            set
            {
                var error = RGB.SetWindow(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void Start()
        {
            var error = RGB.StartCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public void Stop()
        {
            var error = RGB.StopCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }


        public void Dispose()
        {
            if (_handle != IntPtr.Zero)
            {
                RGB.StopCapture(_handle);
                RGB.SetFrameCapturedFn(_handle, null, IntPtr.Zero);
                RGB.CloseInput(_handle);
            }
        }
    }
}