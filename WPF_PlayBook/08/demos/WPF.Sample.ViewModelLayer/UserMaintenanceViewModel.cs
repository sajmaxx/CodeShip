using Common.Library;

namespace WPF.Sample.ViewModelLayer
{
  public class UserMaintenanceViewModel : UserMaintenanceDetailViewModel
  {
    public UserMaintenanceViewModel() : base()
    {
      DisplayStatusMessage("Maintain Users");
    }
  }
}
