using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace EasyRgbWrapper.Lib
{
    public interface IRgbEasyContext : IDisposable
    {
        IList<IRgbEasyInput> Inputs { get; }
    }
}