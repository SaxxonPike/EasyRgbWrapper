using System;
using Datapath.RGBEasy;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace EasyRgbWrapper.Lib
{
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