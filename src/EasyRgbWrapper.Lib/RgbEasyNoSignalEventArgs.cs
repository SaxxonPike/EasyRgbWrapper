using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace EasyRgbWrapper.Lib
{
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
        
        /// <summary>
        /// If False, the default No Signal handler will be executed after the event is concluded. 
        /// </summary>
        public bool PreventDefaultHandler { get; set; }
    }
}