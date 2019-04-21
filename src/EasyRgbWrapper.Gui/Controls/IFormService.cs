using System;
using System.Windows.Forms;
using EasyRgbWrapper.Gui.Logic;
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