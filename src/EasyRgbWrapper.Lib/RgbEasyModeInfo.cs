using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    public struct RgbEasyModeInfo
    {
        public RgbEasyModeInfo(CAPTURESTATE captureState, int refreshRate, int lineRate, int totalLines,
            bool isInterlaced, bool isDvi, ANALOG_INPUT_TYPE analogInputType)
        {
            State = captureState;
            RefreshRate = refreshRate;
            LineRate = lineRate;
            TotalLines = totalLines;
            IsInterlaced = isInterlaced;
            IsDvi = isDvi;
            AnalogInputType = analogInputType;
        }

        public ANALOG_INPUT_TYPE AnalogInputType { get; }
        public bool IsDvi { get; }
        public bool IsInterlaced { get; }
        public int TotalLines { get; }
        public int LineRate { get; }
        public CAPTURESTATE State { get; }
        public int RefreshRate { get; }
    }
}