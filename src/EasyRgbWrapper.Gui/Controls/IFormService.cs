using System;
using EasyRgbWrapper.Lib;

namespace EasyRgbWrapper.Gui.Controls
{
    public interface IFormService : IDisposable
    {
        IDisplayForm CreateCaptureForm(IControlForm parentForm, IRgbEasyCapture capture);
        IControlForm CreateControlForm();
        IDisplayForm GetCaptureFormForInput(int input);
    }
}