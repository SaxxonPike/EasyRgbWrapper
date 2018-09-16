using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public class FormService : IFormService
    {
        public Form Create()
        {
            return new Form();
        }
    }
}