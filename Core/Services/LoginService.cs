using System;
using Core.Settings;
using Models.Domain;

namespace Core.Services
{
  public class LoginService
  {
    private readonly ISettingsStorage _settingsStorage;
    
    public User? AuthorizedUser { get; private set; }

    public bool CheckAuthorize()
    {
      var userId = _settingsStorage.GetString("UserId");

      if (string.IsNullOrEmpty(userId))
        return false;

      return true;
    }
    
    public bool Login(string login, string password)
    {
      AuthorizedUser = new User
      {
        Id = Guid.NewGuid(),
        Name = "Max"
      };
      SaveAuthorizedUser(AuthorizedUser);
      return true;
    }

    private void SaveAuthorizedUser(User user)
    {
      _settingsStorage.SetString("UserId", user.Id.ToString());
      _settingsStorage.SetString("UserName", user.Name);
    }

    public LoginService(ISettingsStorage settingsStorage)
    {
      _settingsStorage = settingsStorage;
    }
  }
}