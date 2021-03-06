using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace EasyRgbWrapper.Lib
{
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public struct RgbEasyDriverVersion
    {
        public RgbEasyDriverVersion(int major, int minor, int micro, int revision)
        {
            Major = major;
            Minor = minor;
            Micro = micro;
            Revision = revision;
        }
        
        public int Major { get; }
        public int Minor { get; }
        public int Micro { get; }
        public int Revision { get; }

        public override string ToString() => 
            $"{Major}.{Minor}.{Micro}.{Revision}";
    }
}