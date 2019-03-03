using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Library;

namespace WPF.Sample.DataLayer
{
  [Table("UserFeedback")]
  public class UserFeedback : CommonBase
  {
    #region Private Variables
    private int _UserFeedbackId;
    private string _Name = string.Empty;
    private string _EmailAddress = string.Empty;
    private string _PhoneExtension = string.Empty;
    private string _Message = string.Empty;
    #endregion

    #region Public Properties
    [Required]
    [Key]
    public int UserFeedbackId
    {
      get { return _UserFeedbackId; }
      set {
        _UserFeedbackId = value;
        RaisePropertyChanged("UserFeedbackId");
      }
    }

    [Required(ErrorMessage = "User Name must be filled in.")]
    public string Name
    {
      get { return _Name; }
      set {
        _Name = value;
        RaisePropertyChanged("Name");
      }
    }

    [Required(ErrorMessage = "Email Address must be filled in.")]
    public string EmailAddress
    {
      get { return _EmailAddress; }
      set {
        _EmailAddress = value;
        RaisePropertyChanged("EmailAddress");
      }
    }

    public string PhoneExtension
    {
      get { return _PhoneExtension; }
      set {
        _PhoneExtension = value;
        RaisePropertyChanged("PhoneExtension");
      }
    }

    [Required(ErrorMessage = "Feedback Message must be filled in.")]
    public string Message
    {
      get { return _Message; }
      set {
        _Message = value;
        RaisePropertyChanged("Message");
      }
    }
    #endregion
  }
}