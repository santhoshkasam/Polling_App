using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollingApp.Models;
using PollingApp.Models.Mapping;

namespace PollingApp.Repositories
{
  public class PollingAppContext : DbContext
  {
    static PollingAppContext()
    {
      Database.SetInitializer<PollingAppContext>(null);
    }
    public PollingAppContext()
      : base("name=PollingAppConnection")
    {
      AppRoles.AsNoTracking();
      TopicMasters.AsNoTracking();
    }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<TopicMaster> TopicMasters { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new AppRoleMap());
      modelBuilder.Configurations.Add(new TopicMasterMap());

    }
  }
}
