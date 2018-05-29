using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDetails
{
   public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }

    }
}
