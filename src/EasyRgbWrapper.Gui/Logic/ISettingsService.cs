using System.Collections.Generic;

namespace EasyRgbWrapper.Gui.Logic
{
    public interface ISettingsService
    {
        IEnumerable<CaptureParameters> LoadCaptureParameters();
        void SaveCaptureParameters(IEnumerable<CaptureParameters> parameters);
    }
}