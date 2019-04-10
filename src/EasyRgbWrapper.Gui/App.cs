using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        public App(IRgbEasyContext context, ICaptureSwitcher captureSwitcher, ISettingsService settingsService)
        {
            _context = context;
            _captureSwitcher = captureSwitcher;
            _settingsService = settingsService;
        }

        public void Start(string[] args)
        {
            using (var formService = new FormService())
            {
                var inputs = _context.Inputs.ToList();
                var captures = new List<IRgbEasyCapture>();
                var controlForm = formService.CreateControlForm();

                _captureSwitcher.Load(_settingsService.LoadCaptureParameters());

                foreach (var input in inputs)
                {
                    var form = formService.CreateCaptureForm();

                    var capture = input.OpenCapture();
                    capture.ModeChanged += CaptureOnModeChanged;
                    form.Text = $"Vision - {capture.Input + 1}";
                    form.PerformLayout();
                    form.Visible = true;
                    UpdateFormGeometry(form, capture);
                    capture.Window = form.Handle;
                    captures.Add(capture);

                    form.GotFocus += (sender, eventArgs) => controlForm.Subject = capture;
                }

                controlForm.SaveClicked += (sender, e) =>
                {
                    var c = (IRgbEasyCapture) controlForm.Subject;
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
                            Phase = c.Phase
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

        private void UpdateFormGeometry(Control control, IRgbEasyCapture capture)
        {
            var info = capture.ModeInfo;
            if (info.State == CAPTURESTATE.CAPTURING)
            {
                _captureSwitcher.Switch(capture, info.TotalLines, info.LineRate, info.RefreshRate);
            }
            
            var height = capture.CaptureHeight;

            if (height < 600)
                height *= 2;

            var del = new Action(() => { control.ClientSize = new Size(height * 4 / 3, height); });

            if (control.InvokeRequired)
                control.Invoke(del);
            else
                del();
        }

        private void CaptureOnModeChanged(object sender, RgbEasyModeChangedEventArgs e)
        {
            Debug.WriteLine(
                $"Mode changed: totalLines={e.Info.TotalNumberOfLines} vRate={e.Info.LineRate} hRate={e.Info.RefreshRate}");
            Debug.WriteLine(
                $"Capture: hPos={e.Capture.HorizontalPosition} hScale={e.Capture.HorizontalScale} vPos={e.Capture.VerticalPosition}");
            Debug.WriteLine($"Capture: width={e.Capture.CaptureWidth} height={e.Capture.CaptureHeight}");

            var form = Control.FromHandle(e.Hwnd);
            UpdateFormGeometry(form, e.Capture);
        }
    }
}