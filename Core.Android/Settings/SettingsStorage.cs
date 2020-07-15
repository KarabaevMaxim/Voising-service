using Android.Content;
using Core.Settings;

namespace Core.Android.Settings
{
  public class SettingsStorage : ISettingsStorage
  {
    private const string PrefsName = "Voicing";
    
    private readonly ISharedPreferences _prefs;
    
    public bool GetBool(string key)
    {
      return _prefs.GetBoolean(key, false);
    }

    public void SetBool(string key, bool value)
    {
      _prefs.Edit().PutBoolean(key, value);
    }

    public string GetString(string key)
    {
      return _prefs.GetString(key, string.Empty);
    }

    public void SetString(string key, string value)
    {
      _prefs.Edit().PutString(key, value);
    }
    
    public SettingsStorage(Context context)
    {
      _prefs = context.GetSharedPreferences(PrefsName, FileCreationMode.Private);
    }
  }
}