using System.ComponentModel;

namespace EasyRgbWrapper.Lib
{
    // ReSharper disable MemberCanBePrivate.Global
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public struct RgbEasyColorBalance
    {
        public RgbEasyColorBalance(int brightnessRed, int brightnessGreen, int brightnessBlue, int contrastRed,
            int contrastGreen, int contrastBlue)
        {
            BrightnessRed = brightnessRed;
            BrightnessGreen = brightnessGreen;
            BrightnessBlue = brightnessBlue;
            ContrastRed = contrastRed;
            ContrastGreen = contrastGreen;
            ContrastBlue = contrastBlue;
        }

        public int BrightnessRed { get; }
        public int BrightnessGreen { get; }
        public int BrightnessBlue { get; }
        public int ContrastRed { get; }
        public int ContrastGreen { get; }
        public int ContrastBlue { get; }

        public override string ToString() => 
            $"Brightness: {BrightnessRed}, {BrightnessGreen}, {BrightnessBlue}; " +
            $"Contrast: {ContrastRed}, {ContrastGreen}, {ContrastBlue}";
    }
}