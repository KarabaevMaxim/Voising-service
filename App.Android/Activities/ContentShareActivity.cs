using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Support.V7.App;
using Core.Services;
using Models;
using MvvmCross;

namespace App.Android.Activities
{
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
  [IntentFilter(
    new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault },
    DataSchemes = new[] { "content", "file" }, DataHosts = new[] { "*" }, DataMimeTypes = new[] { "*/*" },
    DataPathPatterns = new[] { @".*\\.pdf", @".*\\.epub", @".*\\.fb2", @".*\\.txt" })]
  public class ContentShareActivity : AppCompatActivity
  {
    protected override async void OnResume()
    {
      base.OnResume();
      
      if (IsFinishing)
        return;
      
      if (Intent.Action.Equals(Intent.ActionView, StringComparison.OrdinalIgnoreCase))
      {
        var bookFile = await GetBookFile();
        await Mvx.IoCProvider.Resolve<IDialogService>().ShowMessageAsync(bookFile.FileName, $"{bookFile.FullFileName}");
        Finish();
      }
    }

    private async Task<BookFile?> GetBookFile()
    {
      var uri = Intent.Data;

      if (uri == null)
        return null;

      if (!uri.Scheme.Equals("file", StringComparison.OrdinalIgnoreCase) &&
          !uri.Scheme.Equals("content", StringComparison.OrdinalIgnoreCase))
        return null;

      var fileAdapter = Mvx.IoCProvider.Resolve<FileStorageAdapter>();
      var fileName = Path.GetFileName(uri.Path);

      if (!fileAdapter.IsBookFile(fileName))
        return null;

      await using var inputStream = ContentResolver.OpenInputStream(uri);
      var bytes = await fileAdapter.GetBytesFromStream(inputStream);

      return new BookFile
      {
        Bytes = bytes,
        FileName = fileName,
        FileExtension = Path.GetExtension(fileName),
        FullFileName = uri.Path
      };
    }
  }
}