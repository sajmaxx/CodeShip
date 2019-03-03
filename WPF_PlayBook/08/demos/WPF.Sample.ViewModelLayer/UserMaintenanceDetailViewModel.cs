using WPF.Sample.DataLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Common.Library;

namespace WPF.Sample.ViewModelLayer
{
  public class UserMaintenanceDetailViewModel : UserMaintenanceListViewModel
  {
    private User _Entity = new User();
    private User _OriginalEntity = new User();

    public User Entity
    {
      get { return _Entity; }
      set {
        _Entity = value;
        RaisePropertyChanged("Entity");
      }
    }

    public override void LoadUsers()
    {
      // Load all users
      base.LoadUsers();

      // Set default user
      if (Users.Count > 0) {
        Entity = Users[0];
      }
    }

    public override void BeginEdit(bool isAddMode = false)
    {
      // Create a copy in case user wants undo their changes
      base.Clone<User>(Entity, _OriginalEntity);

      if (isAddMode) {
        Entity = new User();
      }

      base.BeginEdit(isAddMode);
    }

    public override void CancelEdit()
    {
      base.CancelEdit();

      // Clone Original to Entity object 
      // so each RaisePropertyChanged event fires
      base.Clone<User>(_OriginalEntity, Entity);
    }

    public override bool Save()
    {
      bool ret = false;
      SampleDbContext db = null;

      try {
        db = new SampleDbContext();
        if (IsAddMode) {
          // Generate a random password
          Entity.Password = StringHelper.CreateRandomString(16);
          // Add new user to EF Users collection
          db.Users.Add(Entity);
        }
        else {
          db.Entry(Entity).State = EntityState.Modified;
        }
        db.SaveChanges();

        ret = true;

        // Set Original Entity equal to changed entity
        _OriginalEntity = Entity;

        // If new entity, add to view model Users collection
        if (IsAddMode) {
          Users.Add(Entity);

          // TODO: Send user name and password to user
        }

        // Set mode back to normal display
        CancelEdit();
      }
      catch (DbEntityValidationException ex) {
        ValidationMessages = new ObservableCollection<ValidationMessage>
               (db.CreateValidationMessages(ex));
        IsValidationVisible = true;
      }
      catch (Exception ex) {
        PublishException(ex);
      }

      return ret;
    }

    public override bool Delete()
    {
      bool ret = false;
      int index = 0;
      SampleDbContext db = null;
      User entity;

      try {
        db = new SampleDbContext();
        // Find entity in EF Users collection
        entity = db.Users.Find(Entity.UserId);
        if (entity != null) {
          // Find index where this entity is located
          index = db.Users.ToList().IndexOf(entity);
          // Remove entity from EF collection
          db.Users.Remove(entity);
          // Save changes to database
          db.SaveChanges();

          ret = true;

          // Remove from view model collection
          Users.Remove(Entity);
          // Calculate the selected entity after deleting
          if (Users.Count > 0) {
            index++;
            if (index > Users.Count) {
              index = Users.Count - 1;
            }
            Entity = Users[index];
          }
          else {
            Entity = null;
          }
        }
      }
      catch (Exception ex) {
        PublishException(ex);
      }

      return ret;
    }

  }
}
