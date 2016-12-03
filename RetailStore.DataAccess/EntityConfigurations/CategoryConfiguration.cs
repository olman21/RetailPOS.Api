using RetailStore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.DataAccess.EntityConfigurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public CategoryConfiguration() : base()
        {

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(250);

            Property(u => u.CategoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(c => c.Products)
               .WithOptional(p => p.Category)
               .HasForeignKey(p => p.CategoryID);
            
        }
    }
}
