using Common.Library;
using System.Timers;
using WPF.Sample.DataLayer;

namespace WPF.Sample.ViewModelLayer
{
  public class MainWindowViewModel : ViewModelBase
  {
    #region Private Variables
    private const int SECONDS = 500;
    private Timer _InfoMessageTimer = null;
    private int _InfoMessageTimeout;
    private User _UserEntity = new User();

    private string _LoginMenuHeader = "Login";
    private string _StatusMessage;
    private bool _IsInfoMessageVisible = true;
    private string _InfoMessage = string.Empty;
    private string _InfoMessageTitle = string.Empty;
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

    public bool IsInfoMessageVisible
    {
      get { return _IsInfoMessageVisible; }
      set {
        _IsInfoMessageVisible = value;
        RaisePropertyChanged("IsInfoMessageVisible");
      }
    }

    public string InfoMessage
    {
      get { return _InfoMessage; }
      set {
        _InfoMessage = value;
        RaisePropertyChanged("InfoMessage");
      }
    }

    public string InfoMessageTitle
    {
      get { return _InfoMessageTitle; }
      set {
        _InfoMessageTitle = value;
        RaisePropertyChanged("InfoMessageTitle");
      }
    }

    public string LoginMenuHeader
    {
      get { return _LoginMenuHeader; }
      set {
        _LoginMenuHeader = value;
        RaisePropertyChanged("LoginMenuHeader");
      }
    }

    public string StatusMessage
    {
      get { return _StatusMessage; }
      set {
        _StatusMessage = value;
        RaisePropertyChanged("StatusMessage");
      }
    }
    #endregion
    public virtual void CreateInfoMessageTimer()
    {
      if (_InfoMessageTimer == null) {
        // Create informational message timer
        _InfoMessageTimer = new Timer(_InfoMessageTimeout);
        // Connect to an Elapsed event
        _InfoMessageTimer.Elapsed += _MessageTimer_Elapsed;
      }
      _InfoMessageTimer.AutoReset = false;
      _InfoMessageTimer.Enabled = true;
      IsInfoMessageVisible = true;
    }
    private void _MessageTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
      IsInfoMessageVisible = false;
    }


    public void LoadStateCodes()
    {
      // TODO: Write code to load state codes here
      System.Threading.Thread.Sleep(SECONDS);
    }

    public void LoadCountryCodes()
    {
      // TODO: Write code to load country codes here
      System.Threading.Thread.Sleep(SECONDS);
    }

    public void LoadEmployeeTypes()
    {
      // TODO: Write code to load employee types here
      System.Threading.Thread.Sleep(SECONDS);
    }

    public void ClearInfoMessages()
    {
      InfoMessage = string.Empty;
      InfoMessageTitle = string.Empty;
      IsInfoMessageVisible = false;
    }
  }
}
