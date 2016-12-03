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
    public class ContactMethodTypeConfiguration : BaseEntityConfiguration<ContactMethodType>
    {
        public ContactMethodTypeConfiguration() : base()
        {
            Property(u => u.MethodID)
                .IsRequired()
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasKey(c => c.MethodID);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(
                             IndexAnnotation.AnnotationName,
                            new IndexAnnotation(
                                new IndexAttribute("IX_ContactMethodTypeName", 1) { IsUnique = true }));

        }
    }
}
