using System;
using System.ComponentModel;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class RgbEasyInput : IRgbEasyInput
    {
        private readonly int _index;

        internal RgbEasyInput(int index)
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
                return new RgbEasySignalType((int) width, (int) height, (int) refreshRate, signalType);
            }
        }

        public RgbEasyInputInfo Info
        {
            get
            {
                var info = new RGBINPUTINFO {Size = 48};
                var error = RGB.GetInputInfo(
                    (uint) _index, ref info);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);

                var driver = new RgbEasyDriverVersion(unchecked((int) info.Driver.Major),
                    unchecked((int) info.Driver.Minor), unchecked((int) info.Driver.Micro),
                    unchecked((int) info.Driver.Revision));
                var location = new RgbEasyInputLocation(unchecked((int) info.Location.Bus), unchecked((int) info.Location.Device), unchecked((int) info.Location.Function));

                return new RgbEasyInputInfo(driver, location, unchecked((int) info.Firmware),
                    unchecked((int) info.VHDL), unchecked((long) info.Identifier));
            }
        }

        public int Number => _index;

        public IRgbEasyCapture OpenCapture() => new RgbEasyCapture(_index);

        public override string ToString() => $"Input {_index}";
    }
}