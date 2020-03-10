namespace EasyRgbWrapper.Gui.Controls
{
    public class DialogFactory : IDialogFactory
    {
        public IFileDialog GetOpen()
        {
            return new OpenFileDialog();
        }

        public IFileDialog GetSave()
        {
            return new SaveFileDialog();
        }
    }
}