using System;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    // ReSharper disable MemberCanBePrivate.Global

    public class RgbEasyValueChangedEventArgs : EventArgs
    {
        public RgbEasyValueChangedEventArgs(IntPtr hwnd, IRgbEasyCapture capture, RGBVALUECHANGEDINFO info,
            IntPtr userData)
        {
            Hwnd = hwnd;
            Capture = capture;
            Info = info;
            UserData = userData;
        }

        public IntPtr Hwnd { get; }
        public IRgbEasyCapture Capture { get; }
        public RGBVALUECHANGEDINFO Info { get; }
        public IntPtr UserData { get; }
    }
}