using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class Contact : BaseEntity
    {
        public Guid ContactID { get; set; }
        public Guid PersonID { get; set; }
        public Person Person { get; set; }
        public int TypeID { get; set; }
        public ContactType Type { get; set; }

        public virtual ICollection<ContactMethodValue> ContactMethods { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
