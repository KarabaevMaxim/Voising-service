using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Core.Services;
using Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Views;

namespace App.Android.Activities
{
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)] 
  public class MainActivity : MvxActivity<MainScreenViewModel>
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.main_screen);
      var btn = FindViewById<Button>(Resource.Id.btn);
      btn.Click += (sender, e) =>
      {
        var service = Mvx.IoCProvider.Resolve<FileStorageAdapter>();
        service.IsBookFile("");
        Mvx.IoCProvider.Resolve<IDialogService>().ShowMessageAsync(null, "Дратути");
      };
    }
  }
}