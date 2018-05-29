using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDetails.DataAccess
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
           public virtual Product Product { get; private set; }
     //   public ICollection<Product> Product { get; set; }
    }
}