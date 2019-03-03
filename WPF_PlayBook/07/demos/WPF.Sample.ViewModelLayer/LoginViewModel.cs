using Common.Library;
using System;
using WPF.Sample.DataLayer;
using System.Linq;

namespace WPF.Sample.ViewModelLayer
{
  public class LoginViewModel : ViewModelBase
  {
    #region Constructor
    public LoginViewModel() : base()
    {
      DisplayStatusMessage("Login to Application");

      Entity = new User {
        UserName = "PShaffer"
      };
    }
    #endregion

    #region Properties
    private User _Entity;

    public User Entity
    {
      get { return _Entity; }
      set {
        _Entity = value;
        RaisePropertyChanged("Entity");
      }
    }
    #endregion

    #region Login Method
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
    #endregion

    #region Validate Method
    public bool Validate()
    {
      bool ret = false;

      Entity.IsLoggedIn = false;
      ValidationMessages.Clear();
      if (string.IsNullOrEmpty(Entity.UserName)) {
        AddValidationMessage("UserName", "User Name Must Be Filled In");
      }
      if (string.IsNullOrEmpty(Entity.Password)) {
        AddValidationMessage("Password", "Password Must Be Filled In");
      }

      ret = (ValidationMessages.Count == 0);

      return ret;
    }
    #endregion

    #region ValidateCredentials Method
    public bool ValidateCredentials()
    {
      bool ret = false;
      SampleDbContext db = null;

      try {
        db = new SampleDbContext();

        if (db.Users.Where(u => u.UserName == Entity.UserName)
                    .Count() > 0) {          
          ret = true;
        }
        else {
          AddValidationMessage("LoginFailed",
                          "Invalid User Name and/or Password.");
        }
      }
      catch (Exception ex) {
        PublishException(ex);
      }

      return ret;
    }
    #endregion

    #region Close Method
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
    #endregion
  }
}
