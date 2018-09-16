using System;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    public class RgbEasyException : Exception
    {
        public RgbEasyException(RGBERROR error) : base($"An RGBEasy error occurred: {error}")
        {
        }

        public RgbEasyException(string message) : base(message)
        {
        }
    }
}