using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class Product : BaseEntity
    {
        public Guid ProductID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public decimal PreTaxPrice { get; set; }

        public decimal Price { get; set; }

        public decimal Qty { get; set; }

        public decimal? DefaultPercentDiscount { get; set; }

        public int? MeasureID { get; set; }

        public virtual MeasureUnit MeasureUnit { get; set; }

        public string BarCode { get; set; }

        public int? CategoryID { get; set; }

        public string Lot { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
