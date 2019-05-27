using Common.Library;

namespace WPF.Sample.ViewModelLayer
{
  public class LoginViewModel : ViewModelBase
  {
    public LoginViewModel() : base()
    {
      DisplayStatusMessage("Login to Application");      
    }

    public override void Close(bool wasCancelled = true)
    {
      if (wasCancelled) {
        // Display Informational Message
        MessageBroker.Instance.SendMessage(
            MessageBrokerMessages.DISPLAY_TIMEOUT_INFO_MESSAGE_TITLE,
               "User NOT Logged In.");
      }

      base.Close(wasCancelled);
    }
  }
}
