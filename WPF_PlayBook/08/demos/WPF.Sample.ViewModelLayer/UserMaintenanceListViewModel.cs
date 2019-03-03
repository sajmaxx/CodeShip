using System;
using System.Collections.ObjectModel;
using Common.Library;
using WPF.Sample.DataLayer;

namespace WPF.Sample.ViewModelLayer
{
  public class UserMaintenanceListViewModel : ViewModelAddEditDeleteBase
  {
    private ObservableCollection<User> _Users = new ObservableCollection<User>();

    public ObservableCollection<User> Users
    {
      get { return _Users; }
      set {
        _Users = value;
        RaisePropertyChanged("Users");
      }
    }

    public virtual void LoadUsers()
    {
      SampleDbContext db = null;

      try {
        db = new SampleDbContext();

        Users = new ObservableCollection<User>(db.Users);
      }
      catch (Exception ex) {
        System.Diagnostics.Debug.WriteLine(ex.ToString());
      }
    }
  }
}
