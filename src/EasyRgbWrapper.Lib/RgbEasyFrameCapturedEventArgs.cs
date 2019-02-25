using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    // ReSharper disable MemberCanBePrivate.Global
    
    public class RgbEasyFrameCapturedEventArgs : EventArgs
    {
        public RgbEasyFrameCapturedEventArgs(IntPtr hwnd, IRgbEasyCapture capture, BITMAPINFOHEADER bitmapInfo, IntPtr bitmapBits,
            IntPtr userData)
        {
            Hwnd = hwnd;
            Capture = capture;
            BitmapInfo = bitmapInfo;
            BitmapBits = bitmapBits;
            UserData = userData;
        }

        public IntPtr Hwnd { get; }
        public IRgbEasyCapture Capture { get; }
        public BITMAPINFOHEADER BitmapInfo { get; }
        public IntPtr BitmapBits { get; }
        public IntPtr UserData { get; }
        
        /// <summary>
        /// If False, the default Frame Captured handler will be executed after the event is concluded. 
        /// </summary>
        public bool PreventDefaultHandler { get; set; }

        public Bitmap GetFrame()
        {
            var pixelFormat = Capture.PixelFormat;
            switch (pixelFormat)
            {
                case PIXELFORMAT.RGB24:
                    return new Bitmap(BitmapInfo.biWidth, BitmapInfo.biHeight, BitmapInfo.biWidth * 3,
                        PixelFormat.Format24bppRgb, BitmapBits);
                case PIXELFORMAT.RGB555:
                    return new Bitmap(BitmapInfo.biWidth, BitmapInfo.biHeight, BitmapInfo.biWidth * 2,
                        PixelFormat.Format16bppRgb555, BitmapBits);
                case PIXELFORMAT.RGB565:
                    return new Bitmap(BitmapInfo.biWidth, BitmapInfo.biHeight, BitmapInfo.biWidth * 2,
                        PixelFormat.Format16bppRgb565, BitmapBits);
                case PIXELFORMAT.RGB888:
                    return new Bitmap(BitmapInfo.biWidth, BitmapInfo.biHeight, BitmapInfo.biWidth * 4,
                        PixelFormat.Format32bppArgb, BitmapBits);
                default:
                    throw new RgbEasyException($"Can't get frame for pixel format {pixelFormat}");
            }
        }
    }
}