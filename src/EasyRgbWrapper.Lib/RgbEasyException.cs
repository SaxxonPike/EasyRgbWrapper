using System;
using Datapath.RGBEasy;

// ReSharper disable UnusedMember.Global

namespace EasyRgbWrapper.Lib
{
    public class RgbEasyException : Exception
    {
        public RGBERROR RgbError { get; }

        public RgbEasyException(RGBERROR rgbError) : base($"An RGBEasy error occurred: {rgbError}")
        {
            RgbError = rgbError;
        }

        public RgbEasyException(string message) : base(message)
        {
        }
    }
}