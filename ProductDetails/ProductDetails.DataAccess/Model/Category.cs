using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDetails.DataAccess
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
          public virtual Product Product { get; private set; }

      //  public ICollection<Product> Product { get; set; }

    }
}