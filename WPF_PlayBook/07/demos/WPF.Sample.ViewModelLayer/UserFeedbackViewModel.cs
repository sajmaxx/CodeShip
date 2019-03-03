using Common.Library;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using WPF.Sample.DataLayer;

namespace WPF.Sample.ViewModelLayer
{
  public class UserFeedbackViewModel : ViewModelBase
  {
    public UserFeedbackViewModel() : base()
    {
      DisplayStatusMessage("Submit User Feedback");
    }

    private UserFeedback _Entity = new UserFeedback();

    public UserFeedback Entity
    {
      get { return _Entity; }
      set {
        _Entity = value;
        RaisePropertyChanged("Entity");
      }
    }

    public bool Save()
    {
      bool ret = false;
      SampleDbContext db = null;

      try {
        db = new SampleDbContext();
        // Add user feedback to database
        db.UserFeedbacks.Add(Entity);
        db.SaveChanges();

        ret = true;
      }
      catch (DbEntityValidationException ex) {
        ValidationMessages = new
            ObservableCollection<ValidationMessage>(
                db.CreateValidationMessages(ex));
        IsValidationVisible = true;
      }
      catch (Exception ex) {
        PublishException(ex);
      }

      return ret;
    }

    public bool SendFeedback()
    {
      bool ret = false;

      // Save/Validate the data
      if (Save()) {
        // TODO: Send the Feedback Message here

        // Display Informational Message
        MessageBroker.Instance.SendMessage(
           MessageBrokerMessages.DISPLAY_TIMEOUT_INFO_MESSAGE_TITLE,
             "Feedback Message Sent.");

        ret = true;

        // Close the user feedback form
        Close(false);
      }

      return ret;
    }

  }
}
