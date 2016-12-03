using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class Category : BaseEntity
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public int? ParentCategoryID { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
