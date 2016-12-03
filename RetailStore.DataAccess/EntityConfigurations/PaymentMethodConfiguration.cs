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
    public class PaymentMethodConfiguration : EntityTypeConfiguration<PaymentMethod>
    {
        public PaymentMethodConfiguration()
        {
            Property(m => m.PaymentMethodID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(m => m.PaymentMethodID);


            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
