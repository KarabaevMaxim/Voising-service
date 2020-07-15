using Models;

namespace Core.Services
{
  public class LoginService
  {
    public User? AuthorizedUser { get; private set; }
    
    public bool Login(string login, string password)
    {
      AuthorizedUser = new User("Max");
      return true;
    }
  }
}