using System;
using System.Collections.Generic;

namespace EasyRgbWrapper.Lib
{
    public interface IRgbEasyContext : IDisposable
    {
        IList<IRgbEasyInput> Inputs { get; }
    }
}