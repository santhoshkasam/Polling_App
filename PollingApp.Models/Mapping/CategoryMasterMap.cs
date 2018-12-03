using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PollingApp.Models.Mapping
{
    public class CategoryMasterMap : EntityTypeConfiguration<CategoryMaster>
    {
        public CategoryMasterMap()
        {
            ToTable("CategoryMaster");
            Property(t => t.CategoryId).HasColumnName("CategoryId");
            Property(t => t.CategoryCode).HasColumnName("CategoryCode");
            Property(t => t.CategoryName).HasColumnName("CategoryName");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
        }
    }
}