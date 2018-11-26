using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public interface IControlForm
    {
        object Subject { get; set; }
        Form Form { get; }
    }
}