using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using Common.Library;

namespace WPF.Sample.DataLayer
{
  public partial class SampleDbContext : DbContext
  {
    public SampleDbContext() : base("name=Samples")
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserFeedback> UserFeedbacks { get; set; }

    public List<ValidationMessage> CreateValidationMessages(
    DbEntityValidationException ex)
    {
      List<ValidationMessage> ret = new List<ValidationMessage>();

      // Retrieve the error messages from EF
      foreach (DbValidationError error in ex.EntityValidationErrors
                     .SelectMany(x => x.ValidationErrors)) {
        ret.Add(new ValidationMessage {
          Message = error.ErrorMessage,
          PropertyName = error.PropertyName
        });
      }

      return ret;
    }
  }
}
