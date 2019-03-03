using WPF.Sample.DataLayer;

namespace WPF.Sample.AppLayer
{
  /// <summary>
  /// This class holds global data for this application
  /// </summary>
  public class AppSettings : ConfigurationSettings
  {
    #region Instance Property
    private static AppSettings _Instance;

    public static AppSettings Instance
    {
      get {
        if (_Instance == null) {
          _Instance = new AppSettings();
        }

        return _Instance;
      }
      set { _Instance = value; }
    }
    #endregion

    #region Private Properties
    private User _UserEntity = new User();
    private int _InfoMessageTimeout;
    private string _EmailDomain;
    #endregion

    #region Public Properties
    public User UserEntity
    {
      get { return _UserEntity; }
      set {
        _UserEntity = value;
        RaisePropertyChanged("UserEntity");
      }
    }

    public int InfoMessageTimeout
    {
      get { return _InfoMessageTimeout; }
      set {
        _InfoMessageTimeout = value;
        RaisePropertyChanged("InfoMessageTimeout");
      }
    }

    public string EmailDomain
    {
      get { return _EmailDomain; }
      set {
        _EmailDomain = value;
        RaisePropertyChanged("EmailDomain");
      }
    }
    #endregion

    #region LoadSettings Method
    public override void LoadSettings()
    {
      InfoMessageTimeout = GetSetting<int>("InfoMessageTimeout", 1200);
      EmailDomain = GetSetting<string>("EmailDomain", "");
    }
    #endregion
  }
}
