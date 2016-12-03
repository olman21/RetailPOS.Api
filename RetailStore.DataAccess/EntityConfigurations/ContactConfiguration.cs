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
    public class ContactConfiguration : BaseEntityConfiguration<Contact>
    {
        public ContactConfiguration() : base()
        {

            HasRequired(c => c.Person)
                 .WithMany()
                 .HasForeignKey(c => c.PersonID);

            HasRequired(c => c.Type)
                .WithMany(t => t.Contacts)
                .HasForeignKey(c => c.TypeID);
        }
    }
}
