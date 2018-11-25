using System.Collections.Generic;
using System.Linq;
using Datapath.RGBEasy;

namespace EasyRgbWrapper.Lib
{
    public static class RgbEasyContextExtensions
    {
        public static IList<IRgbEasyInput> GetConnectedInputs(this IRgbEasyContext context) => 
            context.Inputs.Where(i => i.Signal.Type != SIGNALTYPE.NOSIGNAL).ToList();
    }
}