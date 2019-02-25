using System.Collections.Generic;
using System.Linq;
using Datapath.RGBEasy;
using EasyRgbWrapper.Lib;

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
                    if (parameters.Width != null)
                        capture.CaptureWidth = parameters.Width.Value;
                    if (parameters.Height != null)
                        capture.CaptureHeight = parameters.Height.Value;
                    capture.Phase = parameters.Phase ?? capture.PhaseDefault;
                    capture.HorizontalScale = parameters.HScale ?? capture.HorizontalScaleDefault;
                    capture.HorizontalPosition = parameters.HPos ?? capture.HorizontalPositionDefault;
                    capture.VerticalPosition = parameters.VPos ?? capture.VerticalPositionDefault;
                    capture.PixelFormat = parameters.PixelFormat ?? PIXELFORMAT.RGB888;
                    return;
                }
            }
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