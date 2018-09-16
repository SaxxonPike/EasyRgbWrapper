using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EasyRgbWrapper.Gui.Controls;
using EasyRgbWrapper.Lib;

namespace EasyRgbWrapper.Gui
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            using (var formService = new FormService())
            using (var form = formService.Create())
            using (var context = new RgbEasyContext())
            {
                var input = context.ConnectedInputs.First();
                using (var capture = context.ConnectedInputs.First().OpenCapture())
                {
                    capture.ModeChanged += CaptureOnModeChanged;
                    capture.EnableModeChangedEvent = true;
                    capture.CaptureWidth = 640;
                    capture.HorizontalScale = 800;
                    capture.HorizontalPosition = 142;
                    form.ClientSize = new Size(1024, 768);
                    var picBox = new PictureBox {Dock = DockStyle.Fill};
                    form.Controls.Add(picBox);
                    form.Text = $"ligma version negative 2";
                    form.PerformLayout();
                    capture.Window = picBox.Handle;
                    //capture.Start();

                    Application.Run(form);                
                }
            }
        }

        private static void CaptureOnModeChanged(object sender, RgbEasyModeChangedEventArgs e)
        {
            Debug.WriteLine($"Mode changed: totalLines={e.Info.TotalNumberOfLines} vRate={e.Info.LineRate} hRate{e.Info.RefreshRate}");
        }
    }
}