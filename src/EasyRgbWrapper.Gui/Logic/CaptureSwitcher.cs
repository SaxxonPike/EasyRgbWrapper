using System.Collections.Generic;
using System.Linq;
using Datapath.RGBEasy;
using EasyRgbWrapper.Lib;
using Newtonsoft.Json;

namespace EasyRgbWrapper.Gui.Logic
{
    public class CaptureSwitcher : ICaptureSwitcher
    {
        private readonly List<CaptureParameters> _parameters = new List<CaptureParameters>();

        public void Load(IEnumerable<CaptureParameters> parameters)
        {
            _parameters.AddRange(parameters);
        }

        public void Switch(IRgbEasyCapture capture, int lines, int vRate, int hRate)
        {
            foreach (var parameters in _parameters)
            {
                if (parameters.Lines == lines && parameters.VRate == vRate && parameters.HRate == hRate)
                {
                    capture.CaptureWidth = GetValue(parameters.Width, 
                        capture.CaptureWidthMinimum, capture.CaptureWidthMaximum, 
                        capture.CaptureWidthDefault);
                    
                    capture.CaptureHeight = GetValue(parameters.Height, 
                        capture.CaptureHeightMinimum, capture.CaptureHeightMaximum, 
                        capture.CaptureHeightDefault);

                    capture.Phase = GetValue(parameters.Phase,
                        capture.PhaseMinimum, capture.PhaseMaximum, 
                        capture.PhaseDefault);

                    capture.HorizontalScale = GetValue(parameters.HScale,
                        capture.HorizontalScaleMinimum, capture.HorizontalScaleMaximum, 
                        capture.HorizontalScaleDefault);

                    capture.HorizontalPosition = GetValue(parameters.HPos,
                        capture.HorizontalPositionMinimum, capture.HorizontalPositionMaximum, 
                        capture.HorizontalPositionDefault);
                    
                    capture.VerticalPosition = GetValue(parameters.VPos,
                        capture.VerticalPositionMinimum, capture.VerticalPositionMaximum, 
                        capture.VerticalPositionDefault);
                    
                    capture.PixelFormat = parameters.PixelFormat ?? PIXELFORMAT.RGB888;
                    
                    return;
                }
            }
        }

        private int GetValue(int? value, int minimum, int maximum, int def)
        {
            if (value == null)
                return def;
            if (value < minimum)
                value = minimum;
            if (value > maximum)
                value = maximum;
            return value.Value;
        }

        public void Set(CaptureParameters parameters)
        {
            Clear(parameters.Lines, parameters.VRate, parameters.HRate);
            _parameters.Add(parameters);
        }

        public void Clear(int lines, int vRate, int hRate)
        {
            foreach (var parameters in _parameters)
            {
                if (lines == parameters.Lines && 
                    vRate == parameters.VRate &&
                    hRate == parameters.HRate)
                {
                    _parameters.Remove(parameters);
                    break;
                }
            }
        }

        public IEnumerable<CaptureParameters> Save()
        {
            return _parameters.ToList();
        }
    }
}