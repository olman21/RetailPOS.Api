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
    public class ContactTypeConfiguration : BaseEntityConfiguration<ContactType>
    {
        public ContactTypeConfiguration() : base()
        {
            Property(u => u.TypeID)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(c => c.TypeID);
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(
                             IndexAnnotation.AnnotationName,
                            new IndexAnnotation(
                                new IndexAttribute("IX_ContactTypeName", 1) { IsUnique = true }));

        }
    }
}
