using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class ContactMethodValue : BaseEntity
    {
        public virtual Guid ContactID { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual int ContactMethodID { get; set; }
        public virtual ContactMethodType Type { get; set; }
        public virtual string Value { get; set; }
        
    }
}
