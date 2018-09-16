using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public class FormService : IFormService
    {
        private readonly ISet<Form> _forms = new HashSet<Form>();
        
        public Form Create()
        {
            var form = new Form();
            _forms.Add(form);
            return form;
        }

        public void Dispose()
        {
            foreach (var form in _forms.Where(f => f != null && !f.IsDisposed).ToList())
                 form.Dispose();
        }
    }
}