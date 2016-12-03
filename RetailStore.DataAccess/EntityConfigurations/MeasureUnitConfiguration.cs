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
    public class MeasureUnitConfiguration : EntityTypeConfiguration<MeasureUnit>
    {
        public MeasureUnitConfiguration()
        {
            Property(m => m.MeasureID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(m => m.MeasureID);


            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(80);

            Property(u => u.Symbol)
                .HasMaxLength(10);
        }
    }
}
