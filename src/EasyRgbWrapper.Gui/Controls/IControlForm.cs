using System;
using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public interface IControlForm
    {
        event EventHandler SaveClicked; 
        
        object Subject { get; set; }
        Form Form { get; }
        void Update();
    }
}