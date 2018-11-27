using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EasyRgbWrapper.Gui
{
    public class AppConfigService : IAppConfigService
    {
        private string GetConfigPath()
        {
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            return Path.Combine(path, "config.json");
        }
        
        public AppConfig GetConfig()
        {
            var file = GetConfigPath();
            return !File.Exists(file) 
                ? new AppConfig() 
                : JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(file));
        }

        public void SetConfig(AppConfig config)
        {
            var file = GetConfigPath();
            File.WriteAllText(file, JsonConvert.SerializeObject(config));
        }
    }
}