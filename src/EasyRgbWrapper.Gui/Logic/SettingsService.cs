using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace EasyRgbWrapper.Gui.Logic
{
    public class SettingsService : ISettingsService
    {
        private string GetFileName(string name) => 
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);

        public IEnumerable<CaptureParameters> LoadCaptureParameters()
        {
            var fileName = GetFileName("capture.json");
            if (File.Exists(fileName))
            {
                var data = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<IEnumerable<CaptureParameters>>(data);
            }
            
            return Enumerable.Empty<CaptureParameters>();
        }

        public void SaveCaptureParameters(IEnumerable<CaptureParameters> parameters)
        {
            var fileName = GetFileName("capture.json");
            var data = JsonConvert.SerializeObject(parameters);
            File.WriteAllText(fileName, data);
        }
    }
}