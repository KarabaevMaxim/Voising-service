using Core.Android.Settings;
using Core.Services;
using LocalData;

namespace App.Android
{
  public class Application : global::Android.App.Application
  {
    public override void OnCreate()
    {
      base.OnCreate();
      
      var migrationService = new MigrationService();
      migrationService.Migrate();

      var settingsStorage = new SettingsStorage(this);
      var loginService = new LoginService(settingsStorage); // todo должен быть синглтоном
    }

    public override void OnLowMemory()
    {
      base.OnLowMemory();
    }

    public override void OnTerminate()
    {
      base.OnTerminate();
    }
  }
}