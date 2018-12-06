using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Mapping
{
  public class PollingMap : EntityTypeConfiguration<Polling>
  {
    public PollingMap()
    {
      ToTable("Polling");
      Property(t => t.PollingId).HasColumnName("PollingId");
      Property(t => t.TopicOptionMappingId).HasColumnName("TopicOptionMappingId");
      Property(t => t.Comments).HasColumnName("Comments");
      Property(t => t.SubmittedDate).HasColumnName("SubmittedDate");
      Property(t => t.AppUserId).HasColumnName("AppUserId");
      Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
    }
  }
}
