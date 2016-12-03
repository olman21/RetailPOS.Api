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
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public ProductConfiguration() : base()
        {

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(500);

            Property(u => u.Description)
                .HasMaxLength(1000);

            Property(p => p.BarCode)
                .HasMaxLength(250)
                .HasColumnAnnotation(
                             IndexAnnotation.AnnotationName,
                            new IndexAnnotation(
                                new IndexAttribute("IX_Product_BarCode", 1) { IsUnique = true }));

            Property(u => u.Lot)
                .HasMaxLength(300);

            Property(u => u.Price)
                .IsRequired()
                .HasPrecision(19, 4);

            Property(u => u.PreTaxPrice)
                .IsRequired()
                .HasPrecision(19, 4);

            Property(u => u.Cost)
                .IsRequired()
                .HasPrecision(19, 4);

            HasOptional(p => p.MeasureUnit)
                .WithMany()
                .HasForeignKey(p => p.MeasureID);
            


        }
    }
}
