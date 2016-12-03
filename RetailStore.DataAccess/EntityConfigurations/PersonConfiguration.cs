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
    public class PersonConfiguration : BaseEntityConfiguration<Person>
    {
        public PersonConfiguration() : base()
        {

            Property(u => u.Address)
                .HasMaxLength(500);

            Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(80);

            Property(p => p.LastName)
                .HasMaxLength(80);

            Property(u => u.DNI)
                .HasMaxLength(100);

        }
    }
}
