namespace EasyRgbWrapper.Lib
{
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
    }
}