using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EasyRgbWrapper.Gui.Controls
{
    public class FormService : IFormService
    {
        private readonly ISet<IDisposable> _forms = new HashSet<IDisposable>();

        public Form CreateCaptureForm()
        {
            var form = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog, 
                MinimizeBox = true, 
                MaximizeBox = false
            };

            _forms.Add(form);
            return form;
        }

        public void Dispose()
        {
            foreach (var form in _forms.Where(f => f != null).ToList())
                form.Dispose();
        }

        public IControlForm CreateControlForm()
        {
            var form = new ControlForm();
            _forms.Add(form);
            return form;
        }
    }
}