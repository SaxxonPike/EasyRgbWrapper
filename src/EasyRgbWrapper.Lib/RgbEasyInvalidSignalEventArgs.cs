using System;

namespace EasyRgbWrapper.Lib
{
    // ReSharper disable MemberCanBePrivate.Global

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

        /// <summary>
        /// If False, the default Invalid Signal handler will be executed after the event is concluded. 
        /// </summary>
        public bool PreventDefaultHandler { get; set; }
    }
}