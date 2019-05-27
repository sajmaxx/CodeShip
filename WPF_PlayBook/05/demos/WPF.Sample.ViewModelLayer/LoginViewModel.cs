using Common.Library;
using System;
using WPF.Sample.DataLayer;

namespace WPF.Sample.ViewModelLayer
{
  public class LoginViewModel : ViewModelBase
  {
    public LoginViewModel() : base()
    {
      DisplayStatusMessage("Login to Application");
      
      Entity = new User {
        UserName = "PShaffer"
      };
    }

    private User _Entity;

    public User Entity
    {
      get { return _Entity; }
      set {
        _Entity = value;
        RaisePropertyChanged("Entity");
      }
    }

    public bool Login()
    {
      bool ret = false;

      if (Validate()) {
        // Check Credentials in User Table
        if (ValidateCredentials()) {
          // Mark as logged in
          Entity.IsLoggedIn = true;

          // Send message that login was successful
          MessageBroker.Instance.SendMessage(
              MessageBrokerMessages.LOGIN_SUCCESS, Entity);

          // Close the user control
          Close(false);

          ret = true;
        }
      }

      return ret;
    }


    public bool Validate()
    {
      bool ret = true;

      return ret;
    }

    public bool ValidateCredentials()
    {
      bool ret = true;

      return ret;
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
