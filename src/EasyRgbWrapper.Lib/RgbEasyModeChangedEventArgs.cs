using System;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    public class RgbEasyModeChangedEventArgs : EventArgs
    {
        public RgbEasyModeChangedEventArgs(IntPtr hwnd, IRgbEasyCapture capture, RGBMODECHANGEDINFO info,
            IntPtr userData)
        {
            Hwnd = hwnd;
            Capture = capture;
            Info = info;
            UserData = userData;
        }

        public IntPtr Hwnd { get; }
        public IRgbEasyCapture Capture { get; }
        public RGBMODECHANGEDINFO Info { get; }
        public IntPtr UserData { get; }
    }
}