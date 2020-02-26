using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public class SaveFileDialog : IFileDialog
    {
        private readonly System.Windows.Forms.SaveFileDialog _fd;

        public SaveFileDialog()
        {
            _fd = new System.Windows.Forms.SaveFileDialog();
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