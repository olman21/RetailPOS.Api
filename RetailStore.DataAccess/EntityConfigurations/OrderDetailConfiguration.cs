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
    public class OrderDetailConfiguration : BaseEntityConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration() : base()
        {
            Property(u => u.OrderDetailID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(o => o.OrderDetailID);

            HasRequired(o => o.Order)
                  .WithMany(c => c.Details)
                  .HasForeignKey(o => o.OrderID);

            HasRequired(o => o.Product)
                .WithMany(p=>p.OrderDetails)
                .HasForeignKey(o => o.ProductID);

            Property(u => u.PreTaxPrice)
               .IsRequired()
               .HasPrecision(19, 4);

            Property(u => u.Price)
               .IsRequired()
               .HasPrecision(19, 4);

            Property(u => u.TotalPrice)
               .IsRequired()
               .HasPrecision(19, 4);

            Property(u => u.PercentDiscount)
               .HasPrecision(18, 2);

            Property(u => u.AmountDiscount)
               .HasPrecision(19, 4);

            Property(u => u.Cost)
               .HasPrecision(19, 4);


        }
    }
}
