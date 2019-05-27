using Common.Library;
using System;
using System.Configuration;

namespace WPF.Sample.AppLayer
{
  /// <summary>
  /// This class holds global data for this application
  /// </summary>
  public class ConfigurationSettings : CommonBase
  {
    #region LoadSettings Method
    public virtual void LoadSettings()
    {
      // TODO: Load any common application settings here
    }
    #endregion

    #region GetSetting Method
    protected T GetSetting<T>(string key, object defaultValue)
    {
      T ret = default(T);
      string value;

      value = ConfigurationManager.AppSettings[key];
      if (string.IsNullOrEmpty(value)) {
        ret = (T)defaultValue;
      }
      else {
        ret = (T)Convert.ChangeType(value, typeof(T));
      }

      return ret;
    }
    #endregion
  }
}
