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

    public class RgbEasyNoSignalEventArgs : EventArgs
    {
        public RgbEasyNoSignalEventArgs(IntPtr hwnd, IRgbEasyCapture capture, IntPtr userData)
        {
            Hwnd = hwnd;
            Capture = capture;
            UserData = userData;
        }

        public IntPtr Hwnd { get; }
        public IRgbEasyCapture Capture { get; }
        public IntPtr UserData { get; }
    }
    
    public class RgbEasyInvalidSignalEventArgs : EventArgs
    {
        public RgbEasyInvalidSignalEventArgs(IntPtr hwnd, IRgbEasyCapture capture, int horClock, int verClock,
            IntPtr userData)
        {
            Hwnd = hwnd;
            Capture = capture;
            UserData = userData;
            HorizontalClock = horClock;
            VerticalClock = verClock;
        }

        public IntPtr Hwnd { get; }
        public IRgbEasyCapture Capture { get; }
        public IntPtr UserData { get; }
        public int HorizontalClock { get; }
        public int VerticalClock { get; }
    }    
}