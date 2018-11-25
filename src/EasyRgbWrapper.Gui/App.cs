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
                var forms = new List<Form>();
                
                foreach (var input in inputs)
                {
                    var form = formService.Create();
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.MinimizeBox = true;
                    form.MaximizeBox = false;
                    var capture = input.OpenCapture();
                    capture.ModeChanged += CaptureOnModeChanged;
                    capture.EnableModeChangedEvent = true;
                    form.Text = $"ligma input {capture.Input}";
                    form.PerformLayout();
                    SetFormSizeByCaptureSize(form, capture);
                    capture.Window = form.Handle;
                    forms.Add(form);
                }

                if (forms.Count > 0)
                {
                    foreach (var form in forms)
                        form.Visible = true;
                    
                    Application.Run(formService.GetPrimaryForm());                    
                }

                foreach (var form in forms)
                {
                    if (!form.IsDisposed)
                        form.Dispose();
                }
            }            
        }
        
        private static void SetFormSizeByCaptureSize(Control control, IRgbEasyCapture capture)
        {
            var del = new Action(() =>
            {
                control.ClientSize = new Size(capture.CaptureHeight * 4 / 3, capture.CaptureHeight);
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