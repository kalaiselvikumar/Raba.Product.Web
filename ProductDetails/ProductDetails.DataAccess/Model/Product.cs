using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductDetails.DataAccess
{
    public class Product
    {
        [Key]
       public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        //public virtual ICollection<Supplier> Suppliers { get; private set; }
        //public virtual ICollection<Category> Categories { get; private set; }
        public virtual Category category { get; set; }
        public virtual Supplier supplier { get; set; }

    }
}
