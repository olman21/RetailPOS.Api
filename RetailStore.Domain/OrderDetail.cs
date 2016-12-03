using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class OrderDetail : BaseEntity
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public decimal Cost { get; set; }

        public decimal PreTaxPrice { get; set; }

        public decimal Price { get; set; }

        public decimal Qty { get; set; }

        public decimal PercentDiscount { get; set; }
        public decimal AmountDiscount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
