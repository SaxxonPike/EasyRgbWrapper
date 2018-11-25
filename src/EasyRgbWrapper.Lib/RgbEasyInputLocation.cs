namespace EasyRgbWrapper.Lib
{
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
    }
}