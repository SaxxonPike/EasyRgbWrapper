using System;
using System.ComponentModel;
using System.Drawing;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class RgbEasyCapture : IRgbEasyCapture
    {
        private readonly IntPtr _handle;

        private readonly int _inputIndex;
        private bool _disposed;
        private readonly object _handlerLock = new object();

        internal RgbEasyCapture(int inputIndex)
        {
            _inputIndex = inputIndex;
            var error = RGB.OpenInput((uint) inputIndex, out var handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);

            error = RGB.SetErrorFn(handle, HandleUnrecoverableError, IntPtr.Zero);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);

            error = RGB.SetModeChangedFn(handle, OnModeChanged, IntPtr.Zero);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);

//            error = RGB.SetFrameCapturedFn(handle, OnFrameCaptured, IntPtr.Zero);
//            if (error != RGBERROR.NO_ERROR)
//                throw new RgbEasyException(error);

            error = RGB.SetInvalidSignalFn(handle, OnInvalidSignal, IntPtr.Zero);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);

            error = RGB.SetNoSignalFn(handle, OnNoSignal, IntPtr.Zero);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);

//            error = RGB.SetValueChangedFn(handle, OnValueChanged, IntPtr.Zero);
//            if (error != RGBERROR.NO_ERROR)
//                throw new RgbEasyException(error);

            _handle = handle;
        }

        public event EventHandler<RgbEasyFrameCapturedEventArgs> FrameCaptured;
        public event EventHandler<RgbEasyModeChangedEventArgs> ModeChanged;
        public event EventHandler<RgbEasyNoSignalEventArgs> NoSignal;
        public event EventHandler<RgbEasyInvalidSignalEventArgs> InvalidSignal;
        public event EventHandler<RgbEasyValueChangedEventArgs> ValueChanged;

        public void DefaultFrameCapturedHandler()
        {
            var error = RGB.DrawFrame(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public int HorizontalScaleMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetHorScale(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetHorScale(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int HorizontalPositionMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetHorPosition(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetHorPosition(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int VerticalPositionMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetVerPosition(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetVerPosition(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int CaptureWidthMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetCaptureWidth(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetCaptureWidth(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int CaptureHeightMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetCaptureHeight(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetCaptureHeight(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int BrightnessMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetBrightness(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetBrightness(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int ContrastMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetContrast(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetContrast(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public RgbEasyColorBalance ColourBalanceMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetColourBalance(_handle, out var brightnessRed, out var brightnessGreen,
                    out var brightnessBlue, out var contrastRed, out var contrastGreen, out var contrastBlue);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyColorBalance(brightnessRed, brightnessGreen, brightnessBlue, contrastRed,
                    contrastGreen, contrastBlue);
            }
            set
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetBlackLevel(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetBlackLevel(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int PhaseMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetPhase(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetPhase(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int SaturationMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetSaturation(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetSaturation(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int HueMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetHue(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetHue(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int VideoStandard
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetVideoStandard(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetVideoStandard(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void TestVideoStandard(int videoStandard)
        {
            AssertNotDisposed();
            var error = RGB.TestVideoStandard(_handle, (uint) videoStandard);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public int FrameDroppingMinimum
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetFrameDropping(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetFrameDropping(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public int FrameRate
        {
            get
            {
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
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
                AssertNotDisposed();
                var error = RGB.GetCropping(_handle, out var top, out var left, out var width, out var height);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyCropping(top, left, (int) width, (int) height);
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetCropping(_handle, value.Top, value.Left, (uint) value.Width, (uint) value.Height);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void TestCropping(RgbEasyCropping cropping)
        {
            AssertNotDisposed();
            var error = RGB.TestCropping(_handle, cropping.Top, cropping.Left, (uint) cropping.Width,
                (uint) cropping.Height);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public bool IsCroppingEnabled
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.IsCroppingEnabled(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.EnableCropping(_handle, (uint) (value ? 1 : 0));
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public DEINTERLACE Deinterlace
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetDeinterlace(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetDeinterlace(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void Pause()
        {
            AssertNotDisposed();
            var error = RGB.PauseCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public void Resume()
        {
            AssertNotDisposed();
            var error = RGB.ResumeCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public CAPTURESTATE CaptureState
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetCaptureState(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
        }

        /// <summary>
        ///     TODO:
        ///     Document this better -
        ///     Use negative values to disable messages
        /// </summary>

        public int MessageDelay
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetMessageDelay(_handle, out var enabled, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return enabled > 0 ? (int) result : -1;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetMessageDelay(_handle, value >= 0 ? 1 : 0, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public PIXELFORMAT PixelFormat
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetPixelformat(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetPixelformat(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void SaveCurrentFrame(string fileName)
        {
            AssertNotDisposed();
            var error = RGB.SaveCurrentFrame(_handle, fileName);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public bool EnableDirectDma
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetDMADirect(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetDMADirect(_handle, value ? 1 : 0);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void DrawDefaultFrame()
        {
            AssertNotDisposed();
            var error = RGB.DrawFrame(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        // TODO: RGBSaveBitmap

        public void DrawDefaultNoSignal()
        {
            AssertNotDisposed();
            var error = RGB.NoSignal(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public void DrawDefaultInvalidSignal(int horClock, int verClock)
        {
            AssertNotDisposed();
            var error = RGB.InvalidSignal(_handle, (uint) horClock, (uint) verClock);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public RgbEasyModeInfo ModeInfo
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetModeInfo(_handle, out var modeInfo);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasyModeInfo(modeInfo.State, (int) modeInfo.RefreshRate, (int) modeInfo.LineRate,
                    (int) modeInfo.TotalNumberOfLines, modeInfo.BInterlaced != 0, modeInfo.BDVI != 0,
                    modeInfo.AnalogType);
            }
        }

        public bool FastDownScaling
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetDownScaling(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetDownScaling(_handle, value ? 1 : 0);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void DetectInput()
        {
            AssertNotDisposed();
            var error = RGB.DetectInput(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public void Reset()
        {
            AssertNotDisposed();
            var error = RGB.ResetCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public int Input
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetInput(_handle, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetInput(_handle, (uint) value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public IntPtr Window
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetWindow(_handle, out var hwnd);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return hwnd;
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetWindow(_handle, value);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void Start()
        {
            AssertNotDisposed();
            var error = RGB.StartCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public void Stop()
        {
            AssertNotDisposed();
            var error = RGB.StopCapture(_handle);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
        }

        public Size OutputSize
        {
            get
            {
                AssertNotDisposed();
                var error = RGB.GetOutputSize(_handle, out var width, out var height);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new Size((int) width, (int) height);
            }
            set
            {
                AssertNotDisposed();
                var error = RGB.SetOutputSize(_handle, (uint) value.Width, (uint) value.Height);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public bool UseOutputBuffers
        {
            set
            {
                AssertNotDisposed();
                var error = RGB.UseOutputBuffers(_handle, value ? 1 : 0);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        public void Dispose()
        {
            if (!_disposed && _handle != IntPtr.Zero)
            {
                _disposed = true;
                RGB.StopCapture(_handle);
                RGB.SetFrameCapturedFn(_handle, null, IntPtr.Zero);
                RGB.CloseInput(_handle);
            }
        }

        ~RgbEasyCapture()
        {
            Dispose();
        }

        /// <summary>
        ///     Handles unrecoverable errors from RGBEasy. Per the docs:
        ///     It is the applications responsibility to close the capture using RGBCloseInput when the Error
        ///     callback function is executed.
        /// </summary>
        private void HandleUnrecoverableError(IntPtr hWnd, IntPtr hRgb, uint error, IntPtr userData,
            ref IntPtr reserved)
        {
            try
            {
                throw new RgbEasyException((RGBERROR) error);
            }
            finally
            {
                Dispose();
            }
        }

        private void OnModeChanged(IntPtr hWnd, IntPtr hRgb, ref RGBMODECHANGEDINFO modeChangedInfo, IntPtr userData)
        {
            lock (_handlerLock)
            {
                var e = new RgbEasyModeChangedEventArgs(hWnd, this, modeChangedInfo, userData);
                ModeChanged?.Invoke(this, e);                
            }
        }

        private void OnFrameCaptured(IntPtr hWnd, IntPtr hRgb, ref BITMAPINFOHEADER bitmapInfo, IntPtr bitmapBits,
            IntPtr userData)
        {
            lock (_handlerLock)
            {
                var e = new RgbEasyFrameCapturedEventArgs(hWnd, this, bitmapInfo, bitmapBits, userData);
                FrameCaptured?.Invoke(this, e);

                if (e.PreventDefaultHandler)
                    return;

                DefaultFrameCapturedHandler();                
            }
        }

        private void OnNoSignal(IntPtr hWnd, IntPtr hRgb, IntPtr userData)
        {
            lock (_handlerLock)
            {
                var e = new RgbEasyNoSignalEventArgs(hWnd, this, userData);
                NoSignal?.Invoke(this, e);

                if (e.PreventDefaultHandler)
                    return;

                var error = RGB.NoSignal(_handle);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        private void OnInvalidSignal(IntPtr hWnd, IntPtr hRgb, uint horClock, uint verClock, IntPtr userData)
        {
            lock (_handlerLock)
            {
                var e = new RgbEasyInvalidSignalEventArgs(hWnd, this, (int) horClock, (int) verClock, userData);
                InvalidSignal?.Invoke(this, e);

                if (e.PreventDefaultHandler)
                    return;

                var error = RGB.InvalidSignal(_handle, horClock, verClock);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
            }
        }

        private void OnValueChanged(IntPtr hWnd, IntPtr hRgb, ref RGBVALUECHANGEDINFO valueChangedInfo,
            IntPtr userData)
        {
            lock (_handlerLock)
            {
                var e = new RgbEasyValueChangedEventArgs(hWnd, this, valueChangedInfo, userData);
                ValueChanged?.Invoke(this, e);
            }
        }

        private void AssertNotDisposed()
        {
            if (_disposed)
                throw new Exception("A disposed capture cannot be used.");
        }

        public override string ToString()
        {
            return $"Input Capture {_inputIndex}";
        }
    }
}