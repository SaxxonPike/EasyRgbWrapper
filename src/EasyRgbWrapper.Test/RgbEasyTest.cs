using System;
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
            using (var context = new RgbEasyContext())
            {
                var inputs = context.Inputs;

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