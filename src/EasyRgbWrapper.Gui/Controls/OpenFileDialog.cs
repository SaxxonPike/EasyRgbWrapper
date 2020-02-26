using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public class OpenFileDialog : IFileDialog
    {
        private readonly System.Windows.Forms.OpenFileDialog _fd;

        public OpenFileDialog()
        {
            _fd = new System.Windows.Forms.OpenFileDialog();
        }
        
        public DialogResult Show()
        {
            return _fd.ShowDialog();
        }

        public string FileName
        {
            get => _fd.FileName;
            set => _fd.FileName = value;
        }

        public string Filters
        {
            get => _fd.Filter;
            set => _fd.Filter = value;
        }
    }
}