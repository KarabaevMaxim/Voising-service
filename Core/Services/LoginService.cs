using System;
using Models;
using Models.Domain;

namespace Core.Services
{
  public class LoginService
  {
    public User? AuthorizedUser { get; private set; }
    
    public bool Login(string login, string password)
    {
      AuthorizedUser = new User
      {
        Id = Guid.NewGuid(),
        Name = "Max"
      };
      return true;
    }
  }
}