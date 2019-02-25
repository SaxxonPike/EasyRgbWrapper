using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
// // ReSharper disable All

namespace Datapath.RGBEasy
{
   public enum CAPTURECARD
   {
      DGC103 = 0,
      DGC133 = 1,
   }

   public enum RGBDEVICETYPE
   {
      DEVICETYPE133 = 133,
      DEVICETYPE139 = 139,
      DEVICETYPE144 = 144,
      DEVICETYPE150 = 150,
      DEVICETYPE151 = 151,
      DEVICETYPE139S = 1139,
      DEVICETYPE150S = 1150,
      DEVICETYPE151S = 1151,
      DEVICETYPE153 = 153,
      DEVICETYPE154 = 154,
      DEVICETYPE159 = 159,
      DEVICETYPE161 = 161,
      DEVICETYPE165 = 165,
      DEVICETYPE167 = 167,
      DEVICETYPE168 = 168,
      DEVICETYPE179 = 179,
      DEVICETYPE182 = 182,
      DEVICETYPE184 = 184,
      DEVICETYPE186 = 186,
      DEVICETYPE199 = 199,
      DEVICETYPE200 = 200,
      DEVICETYPE201 = 201,
      DEVICETYPE204 = 204,
      DEVICETYPE205 = 205,
      DEVICETYPE211 = 211
   }

   public enum CAPTURESTATE
   {
      CAPTURING = 0,
      NOSIGNAL = 1,
      INVALIDSIGNAL = 2,
      PAUSED = 3,
      ERROR = 4,
   }

   public enum PIXELGAMUT
   {
      PIXELGAMUT709 = 0,
      PIXELGAMUT601 = 1,
      PIXELGAMUT2020 = 2
   }

   public enum PIXELRANGE
   {
      FULL = 0,
      LIMITED = 1
   }

   public enum PIXELFORMAT
   {
      AUTO = 0,
      RGB555 = 1,
      RGB565 = 2,
      RGB888 = 3,
      GREY = 4,
      RGB24 = 5,
      YUY2 = 6,
      YVYU = 7,
      UYVY = 8,
      NV12 = 9,
      YV12 = 10,
      RGB10 = 11,
      Y410 = 12
   }

   public enum DEINTERLACE
   {
      WEAVE = 0,
      BOB = 1,
      FIELD_0 = 2,
      FIELD_1 = 3,
   }

   public enum ANALOG_INPUT_TYPE
   {
      VGA = 0,
      VIDEO = 1,
   }

   public enum DIGITAL_INPUT_TYPE
   {
      DVI = 0,
      SDI = 1,
      DISPLAYPORT = 2
   }

   public enum VGA_INPUT_FLAGS
   {
      VGA5WIRE = 0,
      VGA4WIRE = 1,
      SOG_SOY = 2
   }

   public enum SDI_INPUT_FLAGS
   {
      SD = 0,
      HD = 1,
      HD_DL = 2,
      SDI3GA = 3,
      SDI3GB = 4,
      SDI3GB_DS = 5,
      SDI3GB_STEREO = 6
   }

   public enum DISPLAYPORT_INPUT_FLAGS
   {
      STEREO_FS = 1
   }

   public enum SIGNALTYPE
   {
      NOSIGNAL = 0,
      VGA = 1,
      DVI = 2,
      COMPONENT = 3,
      COMPOSITE = 4,
      SVIDEO = 5,
      OUTOFRANGE = 6,
      SDI = 7,
      DLDVI = 8,
      DISPLAYPORT = 9
   }

   public enum BUFFERTYPE
   {
      MAPPED = 0,
      DIRECTGMA = 1,
      GPUDIRECT = 2
   }

   public enum OSD_TYPE
   {
      OSD_TYPE_DISABLED = 0,
      OSD_TYPE_TEXT = 1,
   }

   public enum OSD_ALIGNMENT
   {
      OSD_HOR_LEFT = 0,
      OSD_HOR_CENTRE = 1,
      OSD_HOR_RIGHT = 2,

      OSD_VER_TOP = 0,
      OSD_VER_CENTRE = 1,
      OSD_VER_BOTTOM = 2,
   }

   public enum ROTATIONANGLE
   {
      ROTATIONANGLE_0 = 0,
      ROTATIONANGLE_90 = 1,
      ROTATIONANGLE_180 = 2,
      ROTATIONANGLE_270 = 3,   
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct RGBDRIVERVER
   {
      public uint Major;
      public uint Minor;
      public uint Micro;
      public uint Revision;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct RGBLOCATION
   {
      public uint Bus;
      public uint Device;
      public uint Function;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct RGBINPUTINFO
   {
      public uint Size;
      public RGBDRIVERVER Driver;
      public RGBLOCATION Location;
      public uint Firmware;
      public uint VHDL;
      public ulong Identifier;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct RGBMODECHANGEDINFO
   {
      public uint Size;
      public uint RefreshRate;
      public uint LineRate;
      public uint TotalNumberOfLines;
      public int BInterlaced;
      public int BDVI;
      public ANALOG_INPUT_TYPE AnalogType;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct RGBMODEINFO
   {
      public uint Size;
      public CAPTURESTATE State;
      public uint RefreshRate;
      public uint LineRate;
      public uint TotalNumberOfLines;
      public int BInterlaced;
      public int BDVI;
      public ANALOG_INPUT_TYPE AnalogType;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct RGBQUAD
   {
      public byte rgbBlue;
      public byte rgbGreen;
      public byte rgbRed;
      private byte rgbReserved;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct BITMAPINFOHEADER
   {
      public uint biSize;
      public int biWidth;
      public int biHeight;
      public ushort biPlanes;
      public ushort biBitCount;
      public uint biCompression;
      public uint biSizeImage;
      public int biXPelsPerMeter;
      public int biYPelsPerMeter;
      public uint biClrUsed;
      public uint biClrImportant;
   }

   [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto, Pack = 1)]
   public class LOGFONT
   {
      public const int LF_FACESIZE = 32;
      public int lfHeight;
      public int lfWidth;
      public int lfEscapement;
      public int lfOrientation;
      public int lfWeight;
      public byte lfItalic;
      public byte lfUnderline;
      public byte lfStrikeOut;
      public byte lfCharSet;
      public byte lfOutPrecision;
      public byte lfClipPrecision;
      public byte lfQuality;
      public byte lfPitchAndFamily;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
      public string lfFaceName;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public class COLORREF
   {
      public byte red, green, blue;
      private byte unused;

      public COLORREF(byte r, byte g, byte b)
      {
         red = r;
         green = g;
         blue = b;
         unused = 0;
      }

      public uint ToUint()
      {
         return (uint)blue << 16 | (uint)green << 8 | (uint)red;
      }
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct BITMAPINFO
   {
      public BITMAPINFOHEADER bmiHeader;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
      public RGBQUAD[] bmiColors;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct SIGNEDVALUE
   {
      public int BChanged;
      public int Value;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct UNSIGNEDVALUE
   {
      public int BChanged;
      public uint Value;
   }

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct RGBVALUECHANGEDINFO
   {
      public uint Size;
      public SIGNEDVALUE HorPosition;
      public UNSIGNEDVALUE HorScale;
      public UNSIGNEDVALUE VerPosition;
      public SIGNEDVALUE CaptureWidth;
      public UNSIGNEDVALUE CaptureHeight;
      public SIGNEDVALUE Brightness;
      public SIGNEDVALUE Contrast;
      public SIGNEDVALUE BlackLevel;
      public SIGNEDVALUE Phase;
      public UNSIGNEDVALUE RedGain;
      public UNSIGNEDVALUE GreenGain;
      public UNSIGNEDVALUE BlueGain;
      public UNSIGNEDVALUE RedOffset;
      public UNSIGNEDVALUE GreenOffset;
      public UNSIGNEDVALUE BlueOffset;
      public UNSIGNEDVALUE Saturation;
      public UNSIGNEDVALUE Hue;
      public UNSIGNEDVALUE VideoStandard;
   }

   public delegate void RGBFRAMECAPTUREDFN(IntPtr hWnd, IntPtr hRGB, ref BITMAPINFOHEADER bitmapInfo, IntPtr bitmapBits, IntPtr userData);

   public delegate void RGBMODECHANGEDFN(IntPtr hWnd, IntPtr hRGB, ref RGBMODECHANGEDINFO modeChangedInfo, IntPtr userData);

   public delegate void RGBNOSIGNALFN(IntPtr hWnd, IntPtr hRGB, IntPtr userData);

   public delegate void RGBDRAWNOSIGNALFN(IntPtr hWnd, IntPtr hRGB, IntPtr hDC, IntPtr userData);

   public delegate void RGBINVALIDSIGNALFN(IntPtr hWnd, IntPtr hRGB, uint horClock, uint verClock, IntPtr userData);

   public delegate void RGBDRAWINVALIDSIGNALFN(IntPtr hWnd, IntPtr hRGB, IntPtr hDC, uint horClock, uint verClock, IntPtr userData);

   public delegate void RGBERRORFND(IntPtr hWnd, IntPtr hRGB, uint error, IntPtr userData, ref IntPtr reserved);

   public delegate void RGBVALUECHANGEDFN(IntPtr hWnd, IntPtr hRGB, ref RGBVALUECHANGEDINFO valueChangedInfo, IntPtr userData);

   public class RGB
   {
      public static RGBERROR Load(out IntPtr hRGBDLL)
      {
         return NativeMethods.RGBLoad(out hRGBDLL);
      }

      public static RGBERROR LoadEx(out IntPtr hRGBDLL, CAPTURECARD captureCard)
      {
         return NativeMethods.RGBLoadEx(out hRGBDLL, captureCard);
      }

      public static RGBERROR Free(IntPtr hRGBDLL)
      {
         return NativeMethods.RGBFree(hRGBDLL);
      }

      public static RGBERROR GetCaptureCard(out CAPTURECARD captureCard)
      {
         return NativeMethods.RGBGetCaptureCard(out captureCard);
      }

      public static RGBERROR GetNumberOfInputs(out uint NumberOfInputs)
      {
         return NativeMethods.RGBGetNumberOfInputs(out NumberOfInputs);
      }

      public static RGBERROR GetInputInfo(uint uInput, [In, Out] ref RGBINPUTINFO inputInfo)
      {
         return NativeMethods.RGBGetInputInfo(uInput, ref inputInfo);
      }

      public static RGBERROR OpenInput(uint uInput, out IntPtr hRGB)
      {
         return NativeMethods.RGBOpenInput(uInput, out hRGB);
      }

      public static RGBERROR CloseInput(IntPtr hRGB)
      {
         return NativeMethods.RGBCloseInput(hRGB);
      }

      public static RGBERROR CloseInputs(IntPtr phRGBArray, uint numberOfInputs)
      {
         return NativeMethods.RGBCloseInputs(phRGBArray, numberOfInputs);
      }

      public static RGBERROR DetectInput(IntPtr hRGB)
      {
         return NativeMethods.RGBDetectInput(hRGB);
      }

      public static RGBERROR SetInput(IntPtr hRGB, uint input)
      {
         return NativeMethods.RGBSetInput(hRGB, input);
      }

      public static RGBERROR GetInput(IntPtr hRGB, out uint input)
      {
         return NativeMethods.RGBGetInput(hRGB, out input);
      }

      public static RGBERROR SetWindow(IntPtr hRGB, IntPtr hWnd)
      {
         return NativeMethods.RGBSetWindow(hRGB, hWnd);
      }

      public static RGBERROR GetWindow(IntPtr hRGB, out IntPtr hWnd)
      {
         return NativeMethods.RGBGetWindow(hRGB, out hWnd);
      }

      public static RGBERROR ResetCapture(IntPtr hRGB)
      {
         return NativeMethods.RGBResetCapture(hRGB);
      }

      public static RGBERROR GetHorPositionMinimum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetHorPositionMinimum(hRGB, out value);
      }

      public static RGBERROR GetHorPositionMaximum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetHorPositionMaximum(hRGB, out value);
      }

      public static RGBERROR GetHorPositionDefault(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetHorPositionDefault(hRGB, out value);
      }

      public static RGBERROR GetHorPosition(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetHorPosition(hRGB, out value);
      }

      public static RGBERROR SetHorPosition(IntPtr hRGB, int value)
      {
         return NativeMethods.RGBSetHorPosition(hRGB, value);
      }

      public static RGBERROR GetHorScaleMinimum(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetHorScaleMinimum(hRGB, out value);
      }

      public static RGBERROR GetHorScaleMaximum(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetHorScaleMaximum(hRGB, out value);
      }

      public static RGBERROR GetHorScaleDefault(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetHorScaleDefault(hRGB, out value);
      }

      public static RGBERROR GetHorScale(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetHorScale(hRGB, out value);
      }

      public static RGBERROR SetHorScale(IntPtr hRGB, uint value)
      {
         return NativeMethods.RGBSetHorScale(hRGB, value);
      }

      public static RGBERROR GetCaptureWidthMinimum(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetCaptureWidthMinimum(hRGB, out value);
      }

      public static RGBERROR GetCaptureWidthMaximum(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetCaptureWidthMaximum(hRGB, out value);
      }

      public static RGBERROR GetCaptureWidthDefault(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetCaptureWidthDefault(hRGB, out value);
      }

      public static RGBERROR GetCaptureWidth(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetCaptureWidth(hRGB, out value);
      }

      public static RGBERROR TestCaptureWidth(IntPtr hRGB, uint value)
      {
         return NativeMethods.RGBTestCaptureWidth(hRGB, value);
      }

      public static RGBERROR SetCaptureWidth(IntPtr hRGB, uint value)
      {
         return NativeMethods.RGBSetCaptureWidth(hRGB, value);
      }

      public static RGBERROR GetVerPositionMinimum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetVerPositionMinimum(hRGB, out value);
      }

      public static RGBERROR GetVerPositionMaximum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetVerPositionMaximum(hRGB, out value);
      }

      public static RGBERROR GetVerPositionDefault(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetVerPositionDefault(hRGB, out value);
      }

      public static RGBERROR GetVerPosition(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetVerPosition(hRGB, out value);
      }

      public static RGBERROR SetVerPosition(IntPtr hRGB, int value)
      {
         return NativeMethods.RGBSetVerPosition(hRGB, value);
      }

      public static RGBERROR GetCaptureHeightMinimum(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetCaptureHeightMinimum(hRGB, out value);
      }

      public static RGBERROR GetCaptureHeightMaximum(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetCaptureHeightMaximum(hRGB, out value);
      }

      public static RGBERROR GetCaptureHeightDefault(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetCaptureHeightDefault(hRGB, out value);
      }

      public static RGBERROR GetCaptureHeight(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetCaptureHeight(hRGB, out value);
      }

      public static RGBERROR SetCaptureHeight(IntPtr hRGB, uint value)
      {
         return NativeMethods.RGBSetCaptureHeight(hRGB, value);
      }

      public static RGBERROR GetBrightnessMinimum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetBrightnessMinimum(hRGB, out value);
      }

      public static RGBERROR GetBrightnessMaximum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetBrightnessMaximum(hRGB, out value);
      }

      public static RGBERROR GetBrightnessDefault(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetBrightnessDefault(hRGB, out value);
      }

      public static RGBERROR GetBrightness(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetBrightness(hRGB, out value);
      }

      public static RGBERROR SetBrightness(IntPtr hRGB, int value)
      {
         return NativeMethods.RGBSetBrightness(hRGB, value);
      }

      public static RGBERROR GetContrastMinimum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetContrastMinimum(hRGB, out value);
      }

      public static RGBERROR GetContrastMaximum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetContrastMaximum(hRGB, out value);
      }

      public static RGBERROR GetContrastDefault(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetContrastDefault(hRGB, out value);
      }

      public static RGBERROR GetContrast(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetContrast(hRGB, out value);
      }

      public static RGBERROR SetContrast(IntPtr hRGB, int value)
      {
         return NativeMethods.RGBSetContrast(hRGB, value);
      }

      public static RGBERROR GetBlackLevelMinimum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetBlackLevelMinimum(hRGB, out value);
      }

      public static RGBERROR GetBlackLevelMaximum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetBlackLevelMaximum(hRGB, out value);
      }

      public static RGBERROR GetBlackLevelDefault(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetBlackLevelDefault(hRGB, out value);
      }

      public static RGBERROR GetBlackLevel(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetBlackLevel(hRGB, out value);
      }

      public static RGBERROR SetBlackLevel(IntPtr hRGB, int value)
      {
         return NativeMethods.RGBSetBlackLevel(hRGB, value);
      }

      public static RGBERROR GetPhaseMinimum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetPhaseMinimum(hRGB, out value);
      }

      public static RGBERROR GetPhaseMaximum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetPhaseMaximum(hRGB, out value);
      }

      public static RGBERROR GetPhaseDefault(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetPhaseDefault(hRGB, out value);
      }

      public static RGBERROR GetPhase(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetPhase(hRGB, out value);
      }

      public static RGBERROR SetPhase(IntPtr hRGB, int value)
      {
         return NativeMethods.RGBSetPhase(hRGB, value);
      }

      public static RGBERROR GetFrameDroppingMinimum(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetFrameDroppingMinimum(hRGB, out value);
      }

      public static RGBERROR GetFrameDroppingMaximum(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetFrameDroppingMaximum(hRGB, out value);
      }

      public static RGBERROR GetFrameDroppingDefault(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetFrameDroppingDefault(hRGB, out value);
      }

      public static RGBERROR GetFrameDropping(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetFrameDropping(hRGB, out value);
      }

      public static RGBERROR SetFrameDropping(IntPtr hRGB, uint value)
      {
         return NativeMethods.RGBSetFrameDropping(hRGB, value);
      }

      public static RGBERROR GetFrameRate(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetFrameRate(hRGB, out value);
      }

      public static RGBERROR IsCroppingEnabled(IntPtr hRGB, out uint enabled)
      {
         return NativeMethods.RGBIsCroppingEnabled(hRGB, out enabled);
      }

      public static RGBERROR EnableCropping(IntPtr hRGB, uint enable)
      {
         return NativeMethods.RGBEnableCropping(hRGB, enable);
      }

      public static RGBERROR GetCroppingMinimum(IntPtr hRGB, out int top, out int left, out uint width, out uint height)
      {
         return NativeMethods.RGBGetCroppingMinimum(hRGB, out top, out left, out width, out height);
      }

      public static RGBERROR GetCroppingMaximum(IntPtr hRGB, out int top, out int left, out uint width, out uint height)
      {
         return NativeMethods.RGBGetCroppingMaximum(hRGB, out top, out left, out width, out height);
      }

      public static RGBERROR GetCroppingDefault(IntPtr hRGB, out int top, out int left, out uint width, out uint height)
      {
         return NativeMethods.RGBGetCroppingDefault(hRGB, out top, out left, out width, out height);
      }

      public static RGBERROR GetCropping(IntPtr hRGB, out int top, out int left, out uint width, out uint height)
      {
         return NativeMethods.RGBGetCropping(hRGB, out top, out left, out width, out height);
      }

      public static RGBERROR TestCropping(IntPtr hRGB, int top, int left, uint width, uint height)
      {
         return NativeMethods.RGBTestCropping(hRGB, top, left, width, height);
      }

      public static RGBERROR SetCropping(IntPtr hRGB, int top, int left, uint width, uint height)
      {
         return NativeMethods.RGBSetCropping(hRGB, top, left, width, height);
      }

      public static RGBERROR PauseCapture(IntPtr hRGB)
      {
         return NativeMethods.RGBPauseCapture(hRGB);
      }

      public static RGBERROR ResumeCapture(IntPtr hRGB)
      {
         return NativeMethods.RGBResumeCapture(hRGB);
      }

      public static RGBERROR GetCaptureState(IntPtr hRGB, out CAPTURESTATE captureState)
      {
         return NativeMethods.RGBGetCaptureState(hRGB, out captureState);
      }

      public static RGBERROR GetMessageDelay(IntPtr hRGB, out int showMessages, out uint delay)
      {
         return NativeMethods.RGBGetMessageDelay(hRGB, out showMessages, out delay);
      }

      public static RGBERROR SetMessageDelay(IntPtr hRGB, int showMessages, uint delay)
      {
         return NativeMethods.RGBSetMessageDelay(hRGB, showMessages, delay);
      }

      public static RGBERROR GetPixelformat(IntPtr hRGB, out PIXELFORMAT pixelFormat)
      {
         return NativeMethods.RGBGetPixelFormat(hRGB, out pixelFormat);
      }

      public static RGBERROR SetPixelformat(IntPtr hRGB, PIXELFORMAT pixelFormat)
      {
         return NativeMethods.RGBSetPixelFormat(hRGB, pixelFormat);
      }

      public static RGBERROR SaveCurrentFrame(IntPtr hRGB, string fileName)
      {
         return NativeMethods.RGBSaveCurrentFrameW(hRGB, fileName);
      }

      public static RGBERROR IsDirectDMASupported(out int supported)
      {
         return NativeMethods.RGBIsDirectDMASupported(out supported);
      }

      public static RGBERROR GetDMADirect(IntPtr hRGB, out int direct)
      {
         return NativeMethods.RGBGetDMADirect(hRGB, out direct);
      }

      public static RGBERROR SetDMADirect(IntPtr hRGB, int direct)
      {
         return NativeMethods.RGBSetDMADirect(hRGB, direct);
      }

      public static RGBERROR GetDownScaling(IntPtr hRGB, out int fastScaling)
      {
         return NativeMethods.RGBGetDownScaling(hRGB, out fastScaling);
      }

      public static RGBERROR SetDownScaling(IntPtr hRGB, int fastScaling)
      {
         return NativeMethods.RGBSetDownScaling(hRGB, fastScaling);
      }

      public static RGBERROR SetFrameCapturedFn(IntPtr hRGB, RGBFRAMECAPTUREDFN pFn, IntPtr userData)
      {
         return NativeMethods.RGBSetFrameCapturedFn(hRGB, pFn, userData);
      }

      public static RGBERROR DrawFrame(IntPtr hRGB)
      {
         return NativeMethods.RGBDrawFrame(hRGB);
      }

      public static RGBERROR SaveBitmap(IntPtr hRGB, IntPtr bitmapInfo, IntPtr bitmapBits, string filename)
      {
         return NativeMethods.RGBSaveBitmapW(hRGB, bitmapInfo, bitmapBits, filename);
      }

      public static RGBERROR SetModeChangedFn(IntPtr hRGB, RGBMODECHANGEDFN pFn, IntPtr userData)
      {
         return NativeMethods.RGBSetModeChangedFn(hRGB, pFn, userData);
      }

      public static RGBERROR SetNoSignalFn(IntPtr hRGB, RGBNOSIGNALFN pFn, IntPtr userData)
      {
         return NativeMethods.RGBSetNoSignalFn(hRGB, pFn, userData);
      }

      public static RGBERROR NoSignal(IntPtr hRGB)
      {
         return NativeMethods.RGBNoSignal(hRGB);
      }

      public static RGBERROR SetDrawNoSignalFn(IntPtr hRGB, RGBDRAWNOSIGNALFN pFn, IntPtr userData)
      {
         return NativeMethods.RGBSetDrawNoSignalFn(hRGB, pFn, userData);
      }

      public static RGBERROR SetInvalidSignalFn(IntPtr hRGB, RGBINVALIDSIGNALFN pFn, IntPtr userData)
      {
         return NativeMethods.RGBSetInvalidSignalFn(hRGB, pFn, userData);
      }

      public static RGBERROR InvalidSignal(IntPtr hRGB, uint horClock, uint verClock)
      {
         return NativeMethods.RGBInvalidSignal(hRGB, horClock, verClock);
      }

      public static RGBERROR SetDrawInvalidSignalFn(IntPtr hRGB, RGBDRAWINVALIDSIGNALFN pFn, IntPtr userData)
      {
         return NativeMethods.RGBSetDrawInvalidSignalFn(hRGB, pFn, userData);
      }

      public static RGBERROR SetErrorFn(IntPtr hRGB, RGBERRORFND pFn, IntPtr userData)
      {
         return NativeMethods.RGBSetErrorFn(hRGB, pFn, userData);
      }

      public static RGBERROR SetValueChangedFn(IntPtr hRGB, RGBVALUECHANGEDFN pFn, IntPtr userData)
      {
         return NativeMethods.RGBSetValueChangedFn(hRGB, pFn, userData);
      }

      public static RGBERROR StartCapture(IntPtr hRGB)
      {
         return NativeMethods.RGBStartCapture(hRGB);
      }

      public static RGBERROR StopCapture(IntPtr hRGB)
      {
         return NativeMethods.RGBStopCapture(hRGB);
      }

      public static RGBERROR GetColourBalanceMinimum(IntPtr hRGB, out int brightnessRed, out int brightnessGreen, out int brightnessBlue, out int contrastRed, out int contrastGreen, out int contrastBlue)
      {
         return NativeMethods.RGBGetColourBalanceMinimum(hRGB, out brightnessRed, out brightnessGreen, out brightnessBlue, out contrastRed, out contrastGreen, out contrastBlue);
      }

      public static RGBERROR GetColourBalanceMaximum(IntPtr hRGB, out int brightnessRed, out int brightnessGreen, out int brightnessBlue, out int contrastRed, out int contrastGreen, out int contrastBlue)
      {
         return NativeMethods.RGBGetColourBalanceMaximum(hRGB, out brightnessRed, out brightnessGreen, out brightnessBlue, out contrastRed, out contrastGreen, out contrastBlue);
      }

      public static RGBERROR GetColourBalanceDefault(IntPtr hRGB, out int brightnessRed, out int brightnessGreen, out int brightnessBlue, out int contrastRed, out int contrastGreen, out int contrastBlue)
      {
         return NativeMethods.RGBGetColourBalanceDefault(hRGB, out brightnessRed, out brightnessGreen, out brightnessBlue, out contrastRed, out contrastGreen, out contrastBlue);
      }

      public static RGBERROR GetColourBalance(IntPtr hRGB, out int brightnessRed, out int brightnessGreen, out int brightnessBlue, out int contrastRed, out int contrastGreen, out int contrastBlue)
      {
         return NativeMethods.RGBGetColourBalance(hRGB, out brightnessRed, out brightnessGreen, out brightnessBlue, out contrastRed, out contrastGreen, out contrastBlue);
      }

      public static RGBERROR SetColourBalance(IntPtr hRGB, int brightnessRed, int brightnessGreen, int brightnessBlue, int contrastRed, int contrastGreen, int contrastBlue)
      {
         return NativeMethods.RGBSetColourBalance(hRGB, brightnessRed, brightnessGreen, brightnessBlue, contrastRed, contrastGreen, contrastBlue);
      }

      public static RGBERROR GetModeInfo(IntPtr hRGB, out RGBMODEINFO modeInfo)
      {
         modeInfo = new RGBMODEINFO
         {
            Size = 32
         };
         return NativeMethods.RGBGetModeInfo(hRGB, ref modeInfo);
      }

      public static RGBERROR SetOutputSize(IntPtr hRGB, uint width, uint height)
      {
         return NativeMethods.RGBSetOutputSize(hRGB, width, height);
      }

      public static RGBERROR GetOutputSize(IntPtr hRGB, out uint width, out uint height)
      {
         return NativeMethods.RGBGetOutputSize(hRGB, out width, out height);
      }

      public static RGBERROR UseOutputBuffers(IntPtr hRGB, int enable)
      {
         return NativeMethods.RGBUseOutputBuffers(hRGB, enable);
      }

      public static RGBERROR ChainOutputBuffer(IntPtr hRGB, IntPtr bitmapInfo, IntPtr bitmapBits)
      {
         return NativeMethods.RGBChainOutputBuffer(hRGB, bitmapInfo, bitmapBits);
      }

      public static RGBERROR SetDeinterlace(IntPtr hRGB, DEINTERLACE value)
      {
         return NativeMethods.RGBSetDeinterlace(hRGB, value);
      }

      public static RGBERROR GetDeinterlace(IntPtr hRGB, out DEINTERLACE value)
      {
         return NativeMethods.RGBGetDeinterlace(hRGB, out value);
      }

      public static RGBERROR IsYUVSupported(out int value)
      {
         return NativeMethods.RGBIsYUVSupported(out value);
      }

      public static RGBERROR IsDeinterlaceSupported(out int value)
      {
         return NativeMethods.RGBIsDeinterlaceSupported(out value);
      }

      public static RGBERROR GetVideoStandard(IntPtr hRGB, out uint value)
      {
         return NativeMethods.RGBGetVideoStandard(hRGB, out value);
      }

      public static RGBERROR TestVideoStandard(IntPtr hRGB, uint value)
      {
         return NativeMethods.RGBTestVideoStandard(hRGB, value);
      }

      public static RGBERROR SetVideoStandard(IntPtr hRGB, uint value)
      {
         return NativeMethods.RGBSetVideoStandard(hRGB, value);
      }

      public static RGBERROR GetSaturationMinimum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetSaturationMinimum(hRGB, out value);
      }

      public static RGBERROR GetSaturationMaximum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetSaturationMaximum(hRGB, out value);
      }

      public static RGBERROR GetSaturationDefault(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetSaturationDefault(hRGB, out value);
      }

      public static RGBERROR GetSaturation(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetSaturation(hRGB, out value);
      }

      public static RGBERROR SetSaturation(IntPtr hRGB, int value)
      {
         return NativeMethods.RGBSetSaturation(hRGB, value);
      }

      public static RGBERROR GetHueMinimum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetHueMinimum(hRGB, out value);
      }

      public static RGBERROR GetHueMaximum(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetHueMaximum(hRGB, out value);
      }

      public static RGBERROR GetHueDefault(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetHueDefault(hRGB, out value);
      }

      public static RGBERROR GetHue(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBGetHue(hRGB, out value);
      }

      public static RGBERROR SetHue(IntPtr hRGB, int value)
      {
         return NativeMethods.RGBSetHue(hRGB, value);
      }

      public static RGBERROR GetInputSignalType(uint uInput, out SIGNALTYPE signalType, out uint captureWidth, out uint captureHeight, out uint refreshRate)
      {
          return NativeMethods.RGBGetInputSignalType(uInput, out signalType, out captureWidth, out captureHeight, out refreshRate);
      }

      public static RGBERROR InputIsVGASupported(uint uInput, out int value)
      {
         return NativeMethods.RGBInputIsVGASupported(uInput, out value);
      }

      public static RGBERROR InputIsDVISupported(uint uInput, out int value)
      {
         return NativeMethods.RGBInputIsDVISupported(uInput, out value);
      }

      public static RGBERROR InputIsComponentSupported(uint uInput, out int value)
      {
         return NativeMethods.RGBInputIsComponentSupported(uInput, out value);
      }

      public static RGBERROR InputIsCompositeSupported(uint uInput, out int value)
      {
         return NativeMethods.RGBInputIsCompositeSupported(uInput, out value);
      }

      public static RGBERROR InputIsSVideoSupported(uint uInput, out int value)
      {
         return NativeMethods.RGBInputIsSVideoSupported(uInput, out value);
      }

      public static RGBERROR SetNoSignalText(string text)
      {
         return NativeMethods.RGBSetNoSignalTextW(text);
      }

      public static RGBERROR SetInvalidSignalText(string text)
      {
         return NativeMethods.RGBSetInvalidSignalTextW(text);
      }

      public static RGBERROR CreateOSD(out IntPtr hOSD)
      {
         return NativeMethods.RGBCreateOSD(out hOSD);
      }

      public static RGBERROR DeleteOSD(IntPtr hOSD)
      {
         return NativeMethods.RGBDeleteOSD(hOSD);
      }

      public static RGBERROR AttachOSD(IntPtr hRGB, IntPtr hOSD)
      {
         return NativeMethods.RGBAttachOSD(hRGB, hOSD);
      }

      public static RGBERROR DetachOSD(IntPtr hRGB, IntPtr hOSD)
      {
         return NativeMethods.RGBDetachOSD(hRGB, hOSD);
      }

      public static RGBERROR GetFirstOSD(IntPtr hRGB, out IntPtr hOSD)
      {
         return NativeMethods.RGBGetFirstOSD(hRGB, out hOSD);
      }

      public static RGBERROR GetNextOSD(IntPtr hRGB, IntPtr hOSD, out IntPtr hOSDNext)
      {
         return NativeMethods.RGBGetNextOSD(hRGB, hOSD, out hOSDNext);
      }

      public static RGBERROR GetOSDType(IntPtr hOSD, out OSD_TYPE type)
      {
         return NativeMethods.RGBGetOSDType(hOSD, out type);
      }

      public static RGBERROR SetOSDType(IntPtr hOSD, OSD_TYPE type)
      {
         return NativeMethods.RGBSetOSDType(hOSD, type);
      }

      public static RGBERROR GetOSDScaling(IntPtr hOSD, out int fixedSize)
      {
         return NativeMethods.RGBGetOSDScaling(hOSD, out fixedSize);
      }

      public static RGBERROR SetOSDScaling(IntPtr hOSD, int fixedSize)
      {
         return NativeMethods.RGBSetOSDScaling(hOSD, fixedSize);
      }

      public static RGBERROR GetOSDBackground(IntPtr hOSD, out COLORREF background, out int transparent)
      {
         return NativeMethods.RGBGetOSDBackground(hOSD, out background, out transparent);
      }

      public static RGBERROR SetOSDBackground(IntPtr hOSD, COLORREF background, int transparent)
      {
         return NativeMethods.RGBSetOSDBackground(hOSD, background.ToUint(), transparent);
      }

      public static RGBERROR GetOSDTextLength(IntPtr hOSD, out uint count)
      {
         return NativeMethods.RGBGetOSDTextLength(hOSD, out count);
      }

      public static RGBERROR GetOSDText(IntPtr hOSD, out string text, out uint count)
      {
         return NativeMethods.RGBGetOSDTextW(hOSD, out text, out count);
      }

      public static RGBERROR SetOSDText(IntPtr hOSD, string text)
      {
         return NativeMethods.RGBSetOSDTextW(hOSD, text);
      }

      public static RGBERROR GetOSDWrapping(IntPtr hOSD, out int wrapText)
      {
         return NativeMethods.RGBGetOSDWrapping(hOSD, out wrapText);
      }

      public static RGBERROR SetOSDWrapping(IntPtr hOSD, int wrapText)
      {
         return NativeMethods.RGBSetOSDWrapping(hOSD, wrapText);
      }

      public static RGBERROR GetOSDFont(IntPtr hOSD, LOGFONT font, COLORREF foreground)
      {
         return NativeMethods.RGBGetOSDFontW(hOSD, font, foreground);
      }

      public static RGBERROR SetOSDFont(IntPtr hOSD, LOGFONT font, COLORREF foreground)
      {
         return NativeMethods.RGBSetOSDFontW(hOSD, font, foreground.ToUint());
      }

      public static RGBERROR GetOSDMargins(IntPtr hOSD, out int top, out int left, out int bottom, out int right)
      {
         return NativeMethods.RGBGetOSDMargins(hOSD, out top, out left, out bottom, out right);
      }

      public static RGBERROR SetOSDMargins(IntPtr hOSD, int top, int left, int bottom, int right)
      {
         return NativeMethods.RGBSetOSDMargins(hOSD, top, left, bottom, right);
      }

      public static RGBERROR GetOSDAlignment(IntPtr hOSD, out OSD_ALIGNMENT horizontal, out OSD_ALIGNMENT vertical)
      {
         return NativeMethods.RGBGetOSDAlignment(hOSD, out horizontal, out vertical);
      }

      public static RGBERROR SetOSDAlignment(IntPtr hOSD, OSD_ALIGNMENT horizontal, OSD_ALIGNMENT vertical)
      {
         return NativeMethods.RGBSetOSDAlignment(hOSD, horizontal, vertical);
      }

      public static RGBERROR IsOSDAccelerated(out int value)
      {
         return NativeMethods.RGBIsOSDAccelerated(out value);
      }

      public static RGBERROR GetKeyColour(IntPtr hOSD, out COLORREF keyColour)
      {
         return NativeMethods.RGBGetKeyColour(hOSD, out keyColour);
      }

      public static RGBERROR SetKeyColour(IntPtr hOSD, COLORREF keyColour)
      {
         return NativeMethods.RGBSetKeyColour(hOSD, keyColour);
      }

      public static RGBERROR GetRotation(IntPtr hRGB, out ROTATIONANGLE rotationAngle)
      {
         return NativeMethods.RGBGetRotation(hRGB, out rotationAngle);
      }

      public static RGBERROR SetRotation(IntPtr hRGB, ROTATIONANGLE rotationAngle)
      {
         return NativeMethods.RGBSetRotation(hRGB, rotationAngle);
      }

      public static RGBERROR IsRotationSupported(IntPtr hRGB, out int value)
      {
         return NativeMethods.RGBIsRotationSupported(hRGB, out value);
      }
   }

   internal static class NativeMethods
   {
      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBLoad(out IntPtr hRGBDLL);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBLoadEx(out IntPtr hRGBDLL, CAPTURECARD captureCard);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBFree(IntPtr hRGBDLL);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureCard(out CAPTURECARD captureCard);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetNumberOfInputs(out uint NumberOfInputs);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetInputInfo(uint uInput, [In, Out] ref RGBINPUTINFO inputInfo);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBOpenInput(uint uInput, out IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBCloseInput(IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBCloseInputs(IntPtr phRGBArray, uint uInputs);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBDetectInput(IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetInput(IntPtr hRGB, uint uInput);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetInput(IntPtr hRGB, out uint uInput);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetWindow(IntPtr hRGB, IntPtr hWnd);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetWindow(IntPtr hRGB, out IntPtr hWnd);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBResetCapture(IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHorPositionMinimum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHorPositionMaximum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHorPositionDefault(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHorPosition(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetHorPosition(IntPtr hRGB, int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHorScaleMinimum(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHorScaleMaximum(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHorScaleDefault(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHorScale(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetHorScale(IntPtr hRGB, uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureWidthMinimum(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureWidthMaximum(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureWidthDefault(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureWidth(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBTestCaptureWidth(IntPtr hRGB, uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetCaptureWidth(IntPtr hRGB, uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetVerPositionMinimum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetVerPositionMaximum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetVerPositionDefault(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetVerPosition(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetVerPosition(IntPtr hRGB, int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureHeightMinimum(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureHeightMaximum(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureHeightDefault(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureHeight(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetCaptureHeight(IntPtr hRGB, uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetBrightnessMinimum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetBrightnessMaximum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetBrightnessDefault(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetBrightness(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetBrightness(IntPtr hRGB, int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetContrastMinimum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetContrastMaximum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetContrastDefault(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetContrast(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetContrast(IntPtr hRGB, int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetBlackLevelMinimum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetBlackLevelMaximum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetBlackLevelDefault(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetBlackLevel(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetBlackLevel(IntPtr hRGB, int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetPhaseMinimum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetPhaseMaximum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetPhaseDefault(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetPhase(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetPhase(IntPtr hRGB, int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetFrameDroppingMinimum(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetFrameDroppingMaximum(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetFrameDroppingDefault(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetFrameDropping(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetFrameDropping(IntPtr hRGB, uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetFrameRate(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBIsCroppingEnabled(IntPtr hRGB, out uint bEnabled);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBEnableCropping(IntPtr hRGB, uint bEnable);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCroppingMinimum(IntPtr hRGB, out int top, out int left, out uint width, out uint height);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCroppingMaximum(IntPtr hRGB, out int top, out int left, out uint width, out uint height);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCroppingDefault(IntPtr hRGB, out int top, out int left, out uint width, out uint height);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCropping(IntPtr hRGB, out int top, out int left, out uint width, out uint height);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBTestCropping(IntPtr hRGB, int top, int left, uint width, uint height);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetCropping(IntPtr hRGB, int top, int left, uint width, uint height);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBPauseCapture(IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBResumeCapture(IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetCaptureState(IntPtr hRGB, out CAPTURESTATE captureState);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetMessageDelay(IntPtr hRGB, out int bShowMessages, out uint delay);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetMessageDelay(IntPtr hRGB, int bShowMessages, uint delay);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetPixelFormat(IntPtr hRGB, out PIXELFORMAT value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetPixelFormat(IntPtr hRGB, PIXELFORMAT value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Unicode)]
      internal static extern RGBERROR RGBSaveCurrentFrameW(IntPtr hRGB, string fileName);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBIsDirectDMASupported(out int bIsSupported);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetDMADirect(IntPtr hRGB, out int bDMADirect);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetDMADirect(IntPtr hRGB, int bDMADirect);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetDownScaling(IntPtr hRGB, out int fastScaling);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetDownScaling(IntPtr hRGB, int fastScaling);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetFrameCapturedFn(IntPtr hRGB, RGBFRAMECAPTUREDFN pFrameCapturedFn, IntPtr userData);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBDrawFrame(IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Unicode)]
      internal static extern RGBERROR RGBSaveBitmapW(IntPtr hRGB, IntPtr bitmapInfo, IntPtr bitmapBits, string filename);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetModeChangedFn(IntPtr hRGB, RGBMODECHANGEDFN pModeChangedFn, IntPtr userData);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetNoSignalFn(IntPtr hRGB, RGBNOSIGNALFN pNoSignalFn, IntPtr userData);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBNoSignal(IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetDrawNoSignalFn(IntPtr hRGB, RGBDRAWNOSIGNALFN pDrawFn, IntPtr userData);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetInvalidSignalFn(IntPtr hRGB, RGBINVALIDSIGNALFN pInvalidSignalFn, IntPtr userData);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBInvalidSignal(IntPtr hRGB, uint horClock, uint verClock);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetDrawInvalidSignalFn(IntPtr hRGB, RGBDRAWINVALIDSIGNALFN pDrawFn, IntPtr userData);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetErrorFn(IntPtr hRGB, RGBERRORFND pErrorFn, IntPtr userData);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetValueChangedFn(IntPtr hRGB, RGBVALUECHANGEDFN pValueChangedFn, IntPtr userData);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBStartCapture(IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBStopCapture(IntPtr hRGB);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetColourBalanceMinimum(IntPtr hRGB, out int brightnessRed, out int brightnessGreen, out int brightnessBlue, out int contrastRed, out int contrastGreen, out int contrastBlue);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetColourBalanceMaximum(IntPtr hRGB, out int brightnessRed, out int brightnessGreen, out int brightnessBlue, out int contrastRed, out int contrastGreen, out int contrastBlue);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetColourBalanceDefault(IntPtr hRGB, out int brightnessRed, out int brightnessGreen, out int brightnessBlue, out int contrastRed, out int contrastGreen, out int contrastBlue);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetColourBalance(IntPtr hRGB, out int brightnessRed, out int brightnessGreen, out int brightnessBlue, out int contrastRed, out int contrastGreen, out int contrastBlue);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetColourBalance(IntPtr hRGB, int brightnessRed, int brightnessGreen, int brightnessBlue, int contrastRed, int contrastGreen, int contrastBlue);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetModeInfo(IntPtr hRGB, [In, Out] ref RGBMODEINFO modeInfo);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetOutputSize(IntPtr hRGB, uint width, uint Height);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOutputSize(IntPtr hRGB, out uint width, out uint Height);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBUseOutputBuffers(IntPtr hRGB, int enable);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBChainOutputBuffer(IntPtr hRGB, IntPtr bitmapInfo, IntPtr bitmapBits);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetDeinterlace(IntPtr hRGB, DEINTERLACE value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetDeinterlace(IntPtr hRGB, out DEINTERLACE value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBIsYUVSupported(out int supported);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBIsDeinterlaceSupported(out int supported);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetVideoStandard(IntPtr hRGB, out uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBTestVideoStandard(IntPtr hRGB, uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetVideoStandard(IntPtr hRGB, uint value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetSaturationMinimum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetSaturationMaximum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetSaturationDefault(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetSaturation(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetSaturation(IntPtr hRGB, int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHueMinimum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHueMaximum(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHueDefault(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetHue(IntPtr hRGB, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetHue(IntPtr hRGB, int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetInputSignalType(uint uInput, out SIGNALTYPE signalType, out uint captureWidth, out uint captureHeight, out uint refreshRate);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBInputIsVGASupported(uint uInput, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBInputIsDVISupported(uint uInput, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBInputIsComponentSupported(uint uInput, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBInputIsCompositeSupported(uint uInput, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBInputIsSVideoSupported(uint uInput, out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetNoSignalTextW(string text);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetInvalidSignalTextW(string text);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBCreateOSD(out IntPtr hOSD);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBDeleteOSD(IntPtr hOSD);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBAttachOSD(IntPtr hRGB, IntPtr hOSD);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBDetachOSD(IntPtr hRGB, IntPtr hOSD);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetFirstOSD(IntPtr hRGB, out IntPtr hOSD);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetNextOSD(IntPtr hRGB, IntPtr hOSD, out IntPtr hOSDNext);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOSDType(IntPtr hOSD, out OSD_TYPE type);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetOSDType(IntPtr hOSD, OSD_TYPE type);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOSDScaling(IntPtr hOSD, out int fixedSize);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetOSDScaling(IntPtr hOSD, int fixedSize);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOSDBackground(IntPtr hOSD, out COLORREF background, out int transparent);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetOSDBackground(IntPtr hOSD, uint background, int transparent);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOSDTextLength(IntPtr hOSD, out uint count);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOSDTextW(IntPtr hOSD, out string text, out uint count);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetOSDTextW(IntPtr hOSD, string text);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOSDWrapping(IntPtr hOSD, out int wrapText);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetOSDWrapping(IntPtr hOSD, int wrapText);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOSDFontW(IntPtr hOSD, [In, Out] LOGFONT font, COLORREF foreground);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetOSDFontW(IntPtr hOSD, [In, MarshalAs(UnmanagedType.LPStruct)] LOGFONT font, uint foreground);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOSDMargins(IntPtr hOSD, out int top, out int left, out int bottom, out int right);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetOSDMargins(IntPtr hOSD, int top, int left, int bottom, int right);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetOSDAlignment(IntPtr hOSD, out OSD_ALIGNMENT horizontal, out OSD_ALIGNMENT vertical);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetOSDAlignment(IntPtr hOSD, OSD_ALIGNMENT horizontal, OSD_ALIGNMENT vertical);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBIsOSDAccelerated(out int value);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetKeyColour(IntPtr hOSD, out COLORREF keyColour);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetKeyColour(IntPtr hOSD, COLORREF keyColour);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBGetRotation(IntPtr hRGB, out ROTATIONANGLE rotationAngle);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBSetRotation(IntPtr hRGB, ROTATIONANGLE rotationAngle);

      [DllImport("rgbeasy.dll", CharSet = CharSet.Auto)]
      internal static extern RGBERROR RGBIsRotationSupported(IntPtr hRGB, out int value);
   }

   public enum RGBERROR
   {
      // RGBERROR.H
      NO_ERROR = 0,
      DRIVER_NOT_FOUND = 0x00010000,
      UNABLE_TO_LOAD_DRIVER = 0x00010001,
      HARDWARE_NOT_FOUND = 0x00010002,
      INVALID_INDEX = 0x00010003,
      DEVICE_IN_USE = 0x00010004,
      INVALID_HRGBCAPTURE = 0x00010005,
      INVALID_POINTER = 0x00010006,
      INVALID_SIZE = 0x00010007,
      INVALID_FLAGS = 0x00010008,
      INVALID_DEVICE = 0x00010009,
      INVALID_INPUT = 0x0001000A,
      INVALID_FORMAT = 0x0001000D,
      INVALID_VDIF_CLOCKS = 0x0001000E,
      INVALID_PHASE = 0x00010011,
      INVALID_BRIGHTNESS = 0x00010013,
      INVALID_CONTRAST = 0x00010014,
      INVALID_BLACKLEVEL = 0x00010015,
      INVALID_SAMPLERATE = 0x00010016,
      INVALID_PIXEL_FORMAT = 0x00010017,
      INVALID_HWND = 0x00010018,
      INSUFFICIENT_RESOURCES = 0x00010019,
      INSUFFICIENT_BUFFERS = 0x0001001A,
      INSUFFICIENT_MEMORY = 0x0001001B,
      SIGNAL_NOT_DETECTED = 0x0001001C,
      INVALID_SYNCEDGE = 0x0001001D,
      OLD_FIRMWARE = 0x0001001E,
      HWND_AND_FRAMECAPTUREDFN = 0x0001001F,
      HSCALED_OUT_OF_RANGE = 0x00010020,
      VSCALED_OUT_OF_RANGE = 0x00010021,
      SCALING_NOT_SUPPORTED = 0x00010022,
      BUFFER_TOO_SMALL = 0x00010023,
      HSCALE_NOT_WORD_DIVISIBLE = 0x00010024,
      HSCALE_NOT_DWORD_DIVISIBLE = 0x00010025,
      HORADDRTIME_NOT_WORD_DIVISIBLE = 0x00010026,
      HORADDRTIME_NOT_DWORD_DIVISIBLE = 0x00010027,
      VERSION_MISMATCH = 0x00010028,
      ACC_REALLOCATE_BUFFERS = 0x00010029,
      BUFFER_NOT_VALID = 0x0001002A,
      BUFFERS_STILL_ALLOCATED = 0x0001002B,
      NO_NOTIFICATION_SET = 0x0001002C,
      CAPTURE_DISABLED = 0x0001002D,
      INVALID_PIXELFORMAT = 0x0001002E,
      ILLEGAL_CALL = 0x0001002F,
      CAPTURE_OUTSTANDING = 0x00010030,
      MODE_NOT_FOUND = 0x00010031,
      CANNOT_DETECT = 0x00010032,
      NO_MODE_DATABASE = 0x00010033,
      CANT_DELETE_MODE = 0x00010034,
      MUTEX_FAILURE = 0x00010035,
      THREAD_FAILURE = 0x00010036,
      NO_COMPLETION = 0x00010037,
      INSUFFICIENT_RESOURCES_HALLOC = 0x00010038,
      INSUFFICIENT_RESOURCES_RGBLIST = 0x00010039,
      DEVICE_NOT_READY = 0x0001003a,
      HORADDRTIME_NOT_QWORD_DIVISIBLE = 0x0001003b,
      HSCALE_NOT_QWORD_DIVISIBLE = 0x0001003c,
      AOI_NOT_QWORD_ALIGNED = 0x0001003d,
      AOI_NOT_DWORD_ALIGNED = 0x0001003e,
      INVALID_HTIMINGS = 0x0001003f,
      INVALID_PITCH = 0x00010040,
      INVALID_PIXELCOUNT = 0x00010041,
      FLASH_ONLY = 0x00010042,
      CPU_CODE_LOAD_FAILED = 0x00010043,
      IRQ_LINE_FAILED = 0x00010044,
      CPU_CODE_LOAD_ERROR = 0x00010045,
      CPU_STARTUP_UNSIGNALLED = 0x00010046,
      HW_INTEGRITY_VIOLATION = 0x00010047,
      MEMORY_TEST_FAILED = 0x00010048,
      PCI_BUS_FAILURE = 0x00010049,
      CPU_NO_HANDSHAKE = 0x0001004a,
      INVALID_VTIMINGS = 0x0001004b,
      INVALID_ENVIRONMENT = 0x0001004c,
      FILE_NOT_FOUND = 0x0001004d,
      INVALID_GAIN = 0x0001004e,
      INVALID_OFFSET = 0x0001004f,
      CANT_ADJUST_DVI = 0x00010050,
      INCOMPATIBLE_INTERFACE = 0x00010051,
      FLASH_INPROGRESS = 0x00010052,
      INVALID_SATURATION = 0x00010053,
      INVALID_HUE = 0x00010054,
      INVALID_VIDEOSTANDARD = 0x00010055,
      INVALID_DEINTERLACE = 0x00010056,
      ROTATION_NOT_SUPPORTED = 0x00010057,
      INVALID_ROTATION_ANGLE = 0x00010058,
      INVALID_EDID = 0x0001005C,
      EDID_NOT_SUPPORTED = 0x00010059,
      EDID_VERIFY = 0x0001005D,
      EDID_I2C_STUCK = 0x0001005E,
      EDID_I2C_NOACK = 0x0001005E,

      // RGB.H
      UNKNOWN = 0x01160000,
      OUTOFRANGE = 0x01160001,
      INVALIDINPUT = 0x01160002,
      WINDOWINUSE = 0x01160003,
      OSDATTACHED = 0x01160004,
      DETECTVIDEOMODE = 0x01160005,
      INVALIDBUFFER = 0x01160006,
      INVALIDHANDLE = 0x01160007,
      UNSUPPORTED = 0x01160008,
      INVALIDOSD = 0x01160009,
      INVALIDDATA = 0x0116000A,
      AUDIOINPUT = 0x0116000B,

      API_ERROR_UNABLE_TO_OPEN_KEY = 0x00050000,
      API_ERROR_UNABLE_TO_READ_VALUE = 0x00050001,
      API_ERROR_UNABLE_TO_LOAD_DLL = 0x00050002,
      API_ERROR_INCOMPATIBLE_API = 0x00050003,

   }
}
