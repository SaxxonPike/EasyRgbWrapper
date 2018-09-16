using System;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    public class RgbEasyInput : IRgbEasyInput
    {
        private readonly int _index;

        public RgbEasyInput(int index)
        {
            _index = index;
        }

        public bool IsVgaSupported
        {
            get
            {
                var error = RGB.InputIsVGASupported((uint) _index, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
        }
        
        public bool IsDviSupported
        {
            get
            {
                var error = RGB.InputIsDVISupported((uint) _index, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
        }
        
        public bool IsComponentSupported
        {
            get
            {
                var error = RGB.InputIsComponentSupported((uint) _index, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
        }
        
        public bool IsCompositeSupported
        {
            get
            {
                var error = RGB.InputIsCompositeSupported((uint) _index, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
        }
        
        public bool IsSvideoSupported
        {
            get
            {
                var error = RGB.InputIsSVideoSupported((uint) _index, out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
        }

        public RgbEasySignalType Signal
        {
            get
            {
                var error = RGB.GetInputSignalType(
                    (uint) _index, out var signalType, out var width, out var height, out var refreshRate);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return new RgbEasySignalType((int)width, (int)height, (int)refreshRate, signalType);
            }
        }

        public int Number => _index;

        public IRgbEasyCapture OpenCapture() => new RgbEasyCapture(_index);
    }
}