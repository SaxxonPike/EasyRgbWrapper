using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Datapath.RGBEasy;
using EasyRgbWrapper.Gui.Controls;
using EasyRgbWrapper.Gui.Logic;
using EasyRgbWrapper.Lib;

namespace EasyRgbWrapper.Gui
{
    public class App : IApp
    {
        private readonly IRgbEasyContext _context;
        private readonly ICaptureSwitcher _captureSwitcher;
        private readonly ISettingsService _settingsService;
        private readonly IFormService _formService;

        public App(IRgbEasyContext context, ICaptureSwitcher captureSwitcher, ISettingsService settingsService, IFormService formService)
        {
            _context = context;
            _captureSwitcher = captureSwitcher;
            _settingsService = settingsService;
            _formService = formService;
        }

        public void Start(string[] args)
        {
            var inputs = _context.Inputs.ToList();
            var captures = new List<IRgbEasyCapture>();
            var controlForm = _formService.CreateControlForm();

            _captureSwitcher.Load(_settingsService.LoadCaptureParameters());

            foreach (var input in inputs)
            {
                var capture = input.OpenCapture();
                var form = _formService.CreateCaptureForm(controlForm, capture);
                captures.Add(capture);
                form.GotFocus += (sender, eventArgs) => controlForm.Subject = capture;
                form.Visible = true;
                capture.ModeChanged += (sender, eventArgs) => controlForm.Update();
            }

            controlForm.SaveClicked += (sender, e) =>
            {
                var c = (IRgbEasyCapture) controlForm.Subject;
                var captureForm = _formService.GetCaptureFormForInput(c.Input);
                var mode = c.ModeInfo;
                if (mode.State == CAPTURESTATE.CAPTURING)
                {
                    _captureSwitcher.Set(new CaptureParameters
                    {
                        Lines = mode.TotalLines,
                        HRate = mode.RefreshRate,
                        VRate = mode.LineRate,

                        Height = c.CaptureHeight,
                        Width = c.CaptureWidth,
                        HPos = c.HorizontalPosition,
                        HScale = c.HorizontalScale,
                        VPos = c.VerticalPosition,
                        Phase = c.Phase,
                        Scale = captureForm.Scale,
                        Brightness = c.Brightness,
                        Contrast = c.Contrast
                    });

                    _settingsService.SaveCaptureParameters(_captureSwitcher.Save());
                }
            };

            try
            {
                Application.Run(controlForm.Form);
            }
            finally
            {
                foreach (var capture in captures)
                    capture?.Dispose();
            }
        }
    }
}