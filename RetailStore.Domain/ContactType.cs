using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class ContactType : BaseEntity
    {
        public int TypeID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
