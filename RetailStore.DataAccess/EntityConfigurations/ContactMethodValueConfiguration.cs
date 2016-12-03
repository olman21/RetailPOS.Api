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
    public class ContactMethodValueConfiguration : BaseEntityConfiguration<ContactMethodValue>
    {
        public ContactMethodValueConfiguration() : base()
        {

            HasRequired(c => c.Contact)
                 .WithMany(c => c.ContactMethods)
                 .HasForeignKey(c=>c.ContactID);

            HasKey(c => new { c.ContactID, c.ContactMethodID });
            HasRequired(c => c.Type)
                 .WithMany()
                 .HasForeignKey(c => c.ContactMethodID);

            Property(c => c.Value)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
