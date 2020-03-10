using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace EasyRgbWrapper.Lib
{
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public struct RgbEasyInputInfo
    {
        public RgbEasyInputInfo(RgbEasyDriverVersion driverVersion, RgbEasyInputLocation location, int firmware, int vhdl, long identifier)
        {
            DriverVersion = driverVersion;
            Location = location;
            Firmware = firmware;
            Vhdl = vhdl;
            Identifier = identifier;
        }
        
        public RgbEasyDriverVersion DriverVersion { get; }
        public RgbEasyInputLocation Location { get; }
        public int Firmware { get; }
        public int Vhdl { get; }
        public long Identifier { get; }

        public override string ToString()
        {
            return $"{Location} ({Identifier})";
        }
    }
}