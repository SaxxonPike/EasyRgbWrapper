using System.ComponentModel;

namespace EasyRgbWrapper.Lib
{
    // ReSharper disable MemberCanBePrivate.Global
    
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