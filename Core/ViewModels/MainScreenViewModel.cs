using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Core.ViewModels
{
  public class MainScreenViewModel : MvxViewModel
  {
    private string _title;

    public string Title
    {
      get => _title;
      set
      {
        _title = value;
        RaisePropertyChanged(() => Title);
      }
    }
    
    private string _bookFileFullPath;
    
    public string BookFileFullPath
    {
      get => _bookFileFullPath;
      set
      {
        _bookFileFullPath = value;
        RaisePropertyChanged(() => BookFileFullPath);
      }
    }
    
    public ICommand SelectFileCommand { get; private set; }

    private void OnSelectFile()
    {
      
    }
    
    public override async Task Initialize()
    {
      await base.Initialize();
      
      SelectFileCommand = new MvxCommand(OnSelectFile);
    }
  }
}