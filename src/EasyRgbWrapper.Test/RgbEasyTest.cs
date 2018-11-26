using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using EasyRgbWrapper.Gui.Controls;
using EasyRgbWrapper.Lib;
using NUnit.Framework;

namespace EasyRgbWrapper.Test
{
    [TestFixture]
    public class RgbEasyTest
    {
        [Test]
        public void Test1()
        {
            using (var formService = new FormService())
            using (var context = new RgbEasyContext())
            {
                var inputs = context.Inputs;
                var form = formService.CreateCaptureForm();
                form.Size = new Size(640, 480);
                form.Show();

                foreach (var input in inputs)
                {
                    Console.WriteLine($"{input.Number} " +
                                      $"VGA={input.IsVgaSupported} " +
                                      $"Component={input.IsComponentSupported} " +
                                      $"Composite={input.IsCompositeSupported} " +
                                      $"DVI={input.IsDviSupported} " +
                                      $"Svideo={input.IsSvideoSupported} " +
                                      $"Signal={input.Signal.Type}");
                }
            }
        }
    }
}