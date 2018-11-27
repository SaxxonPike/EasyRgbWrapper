namespace EasyRgbWrapper.Gui
{
    public interface IAppConfigService
    {
        AppConfig GetConfig();
        void SetConfig(AppConfig config);
    }
}