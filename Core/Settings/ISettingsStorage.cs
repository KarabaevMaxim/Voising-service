namespace Core.Settings
{
  /// <summary>
  /// Хранилище настроек ключ-значение.
  /// </summary>
  public interface ISettingsStorage
  {
    bool GetBool(string key);

    void SetBool(string key, bool value);
    
    string GetString(string key);

    void SetString(string key, string value);
  }
}