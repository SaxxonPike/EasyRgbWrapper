using System;
using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public interface IFormService : IDisposable
    {
        Form Create();
        Form GetPrimaryForm();
    }
}