using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EasyRgbWrapper.Gui.Controls;
using EasyRgbWrapper.Lib;

namespace EasyRgbWrapper.Gui
{
    public class App : IApp
    {
        private readonly IRgbEasyContext _context;

        public App(IRgbEasyContext context)
        {
            _context = context;
        }
        
        public void Start(string[] args)
        {
            using (var formService = new FormService())
            {
                var inputs = _context.Inputs.ToList();
                var captures = new List<IRgbEasyCapture>();
                var controlForm = formService.CreateControlForm();
                
                foreach (var input in inputs)
                {
                    var form = formService.CreateCaptureForm();
                    
                    var capture = input.OpenCapture();
                    capture.ModeChanged += CaptureOnModeChanged;
                    capture.EnableModeChangedEvent = true;
                    form.Text = $"ligma input {capture.Input}";
                    form.PerformLayout();
                    form.Visible = true;
                    SetFormSizeByCaptureSize(form, capture);
                    capture.Window = form.Handle;
                    captures.Add(capture);

                    form.GotFocus += (sender, eventArgs) => controlForm.Subject = capture;
                }
                
                Application.Run(controlForm.Form);                    

                foreach (var capture in captures)
                    capture?.Dispose();
            }            
        }
        
        private static void SetFormSizeByCaptureSize(Control control, IRgbEasyCapture capture)
        {
            var height = capture.CaptureHeight;

            if (height < 600)
                height *= 2;
            
            var del = new Action(() =>
            {
                control.ClientSize = new Size(height * 4 / 3, height);
            });

            if (control.InvokeRequired)
                control.Invoke(del);
            else
                del();
        }

        private static void CaptureOnModeChanged(object sender, RgbEasyModeChangedEventArgs e)
        {
            Debug.WriteLine(
                $"Mode changed: totalLines={e.Info.TotalNumberOfLines} vRate={e.Info.LineRate} hRate={e.Info.RefreshRate}");
            Debug.WriteLine(
                $"Capture: hPos={e.Capture.HorizontalPosition} hScale={e.Capture.HorizontalScale} vPos={e.Capture.VerticalPosition}");
            Debug.WriteLine($"Capture: width={e.Capture.CaptureWidth} height={e.Capture.CaptureHeight}");
            var form = Control.FromHandle(e.Hwnd);
            SetFormSizeByCaptureSize(form, e.Capture);
        }        
    }
}