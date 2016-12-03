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
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasKey(u => u.UserID);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnAnnotation(
                             IndexAnnotation.AnnotationName,
                            new IndexAnnotation(
                                new IndexAttribute("IX_UserName", 1) { IsUnique = true }));

            Property(u => u.FirstName)
                .HasMaxLength(60);

            Property(u => u.LastName)
                .HasMaxLength(60);

        }
    }
}
