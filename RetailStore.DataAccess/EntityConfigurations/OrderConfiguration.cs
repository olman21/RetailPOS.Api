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
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public OrderConfiguration() : base()
        {
            Property(u => u.OrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(o => o.OrderID);

            HasRequired(o => o.Client)
                  .WithMany(c => c.Orders)
                  .HasForeignKey(o => o.ClientID);

            HasMany(o => o.PaymentMethods)
                .WithMany();

            HasRequired(o => o.Type)
                .WithMany()
                .HasForeignKey(o => o.TypeID);

            Property(u => u.CostPrice)
               .IsRequired()
               .HasPrecision(19, 4);

            Property(u => u.PretaxPrice)
               .IsRequired()
               .HasPrecision(19, 4);

            Property(u => u.TotalPrice)
               .IsRequired()
               .HasPrecision(19, 4);

            Property(u => u.PercentDiscount)
               .HasPrecision(18, 2);

            Property(u => u.TotalDiscount)
               .HasPrecision(19, 4);

            Property(o => o.CardNumber)
                .HasMaxLength(25);

        }
    }
}
