using Core;
using Core.Android.Services;
using Core.Android.Settings;
using Core.Services;
using Core.Settings;
using MvvmCross;
using MvvmCross.IoC;

namespace App.Android
{
  public class Bootstrapper : BaseBootstrapper
  {
    public override void Initialize()
    {
      base.Initialize();
      
      Mvx.IoCProvider.ConstructAndRegisterSingleton<ISettingsStorage, SettingsStorage>(Application.Context);
      Mvx.IoCProvider.ConstructAndRegisterSingleton<IDialogService, DialogService>(Application.Context);
    }
  }
}