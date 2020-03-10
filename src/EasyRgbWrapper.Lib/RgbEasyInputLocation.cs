using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace EasyRgbWrapper.Lib
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public struct RgbEasyInputLocation
    {
        public RgbEasyInputLocation(int bus, int device, int function)
        {
            Bus = bus;
            Device = device;
            Function = function;
        }
        
        public int Bus { get; }
        public int Device { get; }
        public int Function { get; }

        public override string ToString() => 
            $"Bus {Bus}, Device {Device}, Function {Function}";
    }
}