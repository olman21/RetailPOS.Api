using RetailStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.DataAccess.EntityConfigurations
{
    public class BaseEntityConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public BaseEntityConfiguration() {
           HasRequired(e => e.CreatedBy)
               .WithMany()
               .HasForeignKey(e=>e.CreatedByID)
               .WillCascadeOnDelete(false);

            HasOptional(e => e.ModifiedBy)
                .WithMany()
                .HasForeignKey(e => e.ModifiedByID)
                .WillCascadeOnDelete(false);

            HasOptional(e => e.DeletedBy)
                .WithMany()
                .HasForeignKey(e => e.DeletedByID)
                .WillCascadeOnDelete(false);
        }
    }
}
