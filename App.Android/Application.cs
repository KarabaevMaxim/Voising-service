using System;
using Android.App;
using Android.Runtime;
using Core.Android.Settings;
using Core.Services;
using LocalData;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace App.Android
{
  [Application]
  public class Application : MvxAndroidApplication<MvxAndroidSetup<Bootstrapper>, Bootstrapper>
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
    
    public Application(IntPtr javaReference, JniHandleOwnership transfer)
      : base(javaReference, transfer)
    {
    }
  }
}