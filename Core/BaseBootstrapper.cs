using Core.Services;
using Core.Settings;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace Core
{
  public class BaseBootstrapper : MvxApplication
  {
    public override void Initialize()
    {
      Mvx.IoCProvider.ConstructAndRegisterSingleton<ILoginService, LoginService>();
      Mvx.IoCProvider.RegisterType<FileStorageAdapter>();
    }
  }
}