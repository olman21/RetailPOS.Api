using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class Person : BaseEntity
    {
        public Guid PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DNI { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}
