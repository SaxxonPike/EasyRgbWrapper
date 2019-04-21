using System;
using System.Collections.Generic;
using System.Linq;
using EasyRgbWrapper.Gui.Logic;
using EasyRgbWrapper.Lib;

namespace EasyRgbWrapper.Gui.Controls
{
    public class FormService : IFormService
    {
        private readonly ICaptureSwitcher _captureSwitcher;
        private readonly ISet<IDisposable> _forms = new HashSet<IDisposable>();
        private readonly IDictionary<int, IDisplayForm> _displayFormCaptures = new Dictionary<int, IDisplayForm>();

        public FormService(ICaptureSwitcher captureSwitcher)
        {
            _captureSwitcher = captureSwitcher;
        }

        public IDisplayForm CreateCaptureForm(IControlForm parentForm, IRgbEasyCapture capture)
        {
            var form = new DisplayForm(parentForm.Form, capture, _captureSwitcher);
            _forms.Add(form);
            _displayFormCaptures[capture.Input] = form;
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

        public IDisplayForm GetCaptureFormForInput(int input)
        {
            return _displayFormCaptures.ContainsKey(input)
                ? _displayFormCaptures[input]
                : null;
        }
    }
}