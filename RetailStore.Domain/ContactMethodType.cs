using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class ContactMethodType : BaseEntity
    {
        public int MethodID { get; set; }
        public string Name { get; set; }
    }
}
