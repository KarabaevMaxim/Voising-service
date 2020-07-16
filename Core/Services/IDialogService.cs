using System.Threading.Tasks;

namespace Core.Services
{
  public interface IDialogService
  {
    Task ShowMessageAsync(string? title, string message);
    
    Task ShowWarningAsync(string? title, string message);
    
    Task ShowErrorAsync(string? title, string message);  
  }
}