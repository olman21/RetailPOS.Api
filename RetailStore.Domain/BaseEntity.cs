using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public abstract class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public int CreatedByID { get; set; }

        public User CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedByID { get; set; }
        
        public User ModifiedBy { get; set; }

        public virtual bool IsDeleted { get; set; }

        public int? DeletedByID { get; set; }

        public User DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}
