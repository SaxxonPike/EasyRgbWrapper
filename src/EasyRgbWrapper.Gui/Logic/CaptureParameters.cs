using Datapath.RGBEasy;
using Newtonsoft.Json;

namespace EasyRgbWrapper.Gui.Logic
{
    [JsonObject]
    public struct CaptureParameters
    {
        // Input
        [JsonRequired]
        public int Lines { get; set; }
        [JsonRequired]
        public int VRate { get; set; }
        [JsonRequired]
        public int HRate { get; set; }
        
        // Output
        public int? HPos { get; set; }
        public int? HScale { get; set; }
        public int? VPos { get; set; }
        public int? Phase { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public PIXELFORMAT? PixelFormat { get; set; } 
    }
}