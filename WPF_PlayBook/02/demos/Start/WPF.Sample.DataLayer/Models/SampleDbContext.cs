using System.Data.Entity;

namespace WPF.Sample.DataLayer
{
  public partial class SampleDbContext : DbContext
  {
    public SampleDbContext() : base("name=Samples")
    {
    }

    public virtual DbSet<User> Users { get; set; }
  }
}
