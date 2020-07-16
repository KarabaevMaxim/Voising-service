using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Core.Services;

namespace Core.Android.Services
{
  public class DialogService : IDialogService
  {
    private readonly Context _context;

    public Task ShowMessageAsync(string? title, string message)
    {
      return ShowSomeMessageInternalAsync(title, message);
    }

    public Task ShowWarningAsync(string? title, string message)
    {
      return ShowSomeMessageInternalAsync(title, message);
    }

    public Task ShowErrorAsync(string? title, string message)
    {
      return ShowSomeMessageInternalAsync(title, message);
    }
    
    private Task ShowSomeMessageInternalAsync(string? title, string message)
    {
      var resultTask = new TaskCompletionSource<bool>();
      AlertDialog.Builder builder = new AlertDialog.Builder(_context);
      var dialog = builder
        .SetTitle(title)
        .SetMessage(message)
        .SetPositiveButton("Ок", (sender, args) => resultTask.TrySetResult(true))
        .Show();

      return dialog == null 
        ? Task.FromResult(false) 
        : resultTask.Task;
    }

    public DialogService(Context context)
    {
      _context = context;
    }
  }
}