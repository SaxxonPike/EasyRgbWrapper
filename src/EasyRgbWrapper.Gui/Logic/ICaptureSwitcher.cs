using System.Collections.Generic;
using EasyRgbWrapper.Lib;

namespace EasyRgbWrapper.Gui.Logic
{
    public interface ICaptureSwitcher
    {
        void Switch(IRgbEasyCapture capture, int lines, int vRate, int hRate);
        void Set(CaptureParameters parameters);
        void Clear(int lines, int vRate, int hRate);
        void Load(IEnumerable<CaptureParameters> parameters);
        IEnumerable<CaptureParameters> Save();
    }
}