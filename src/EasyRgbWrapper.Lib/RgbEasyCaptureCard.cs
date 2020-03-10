using System.ComponentModel;
using Datapath.RGBEasy;

// ReSharper disable UnusedMember.Global

namespace EasyRgbWrapper.Lib
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class RgbEasyCaptureCard : IRgbEasyCaptureCard
    {
        internal RgbEasyCaptureCard()
        {
        }
        
        public int InputCount
        {
            get
            {
                var error = RGB.GetNumberOfInputs(out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return (int) result;
            }
        }

        public bool IsDirectDmaSupported
        {
            get
            {
                var error = RGB.IsDirectDMASupported(out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
        }
        
        public bool IsDeinterlaceSupported
        {
            get
            {
                var error = RGB.IsDeinterlaceSupported(out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
        }
        
        public bool IsYuvSupported
        {
            get
            {
                var error = RGB.IsYUVSupported(out var result);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);
                return result != 0;
            }
        }

    }
}