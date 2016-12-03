using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class Order : BaseEntity
    {
        public int OrderID { get; set; }
        public Guid ClientID { get; set; }
        public virtual Contact Client { get; set; }
        public decimal CostPrice { get; set; }
        public decimal PretaxPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods{ get; set; }
        public int TypeID { get; set; }
        public virtual OrderType Type { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PercentDiscount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public string CardNumber { get; set; }
        public virtual ICollection<OrderDetail> Details  { get; set; }
    }
}
