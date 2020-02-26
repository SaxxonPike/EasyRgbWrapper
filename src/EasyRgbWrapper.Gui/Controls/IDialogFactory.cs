namespace EasyRgbWrapper.Gui.Controls
{
    public interface IDialogFactory
    {
        IFileDialog GetOpen();
        IFileDialog GetSave();
    }
}