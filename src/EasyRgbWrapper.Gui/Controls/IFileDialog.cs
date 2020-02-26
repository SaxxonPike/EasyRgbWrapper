using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public interface IFileDialog
    {
        DialogResult Show();
        string FileName { get; set; }
        string Filters { get; set; }
    }
}