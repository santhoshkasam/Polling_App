using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Mapping
{
    public class CategoryTopicMappingMap : EntityTypeConfiguration<CategoryTopicMapping>
    {
        public CategoryTopicMappingMap()
        {
            ToTable("CategoryTopicMapping", "dbo");
            Property(t => t.CategoryTopicMappingId).HasColumnName("CategoryTopicMappingId");
            Property(t => t.TopicId).HasColumnName("TopicId");
            Property(t => t.CategoryId).HasColumnName("CategoryId");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
        }
    }
}