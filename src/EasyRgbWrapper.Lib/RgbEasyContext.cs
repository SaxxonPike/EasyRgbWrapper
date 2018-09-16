using System;
using System.Collections.Generic;
using System.Linq;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    public class RgbEasyContext : IRgbEasyContext
    {
        private readonly IntPtr _dll;
        
        public RgbEasyContext()
        {
            var error = RGB.Load(out var dll);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
            _dll = dll;
        }

        public RgbEasyContext(CAPTURECARD captureCard)
        {
            var error = RGB.LoadEx(out var dll, captureCard);
            if (error != RGBERROR.NO_ERROR)
                throw new RgbEasyException(error);
            _dll = dll;
        }

        public IList<IRgbEasyInput> Inputs
        {
            get
            {
                var error = RGB.GetNumberOfInputs(out var inputCount);
                if (error != RGBERROR.NO_ERROR)
                    throw new RgbEasyException(error);

                return Enumerable
                    .Range(0, (int) inputCount)
                    .Select(i => new RgbEasyInput(i))
                    .Cast<IRgbEasyInput>()
                    .ToList();
            }
        }
        
        public void Dispose()
        {
            if (_dll != IntPtr.Zero)
                RGB.Free(_dll);
        }
    }
}