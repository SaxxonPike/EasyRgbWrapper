using System;
using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public interface IDisplayForm
    {
        event KeyEventHandler KeyDown;
        event EventHandler GotFocus;
        bool Visible { get; set; }
        IntPtr Handle { get; }
        int Scale { get; set; }
    }
}