using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDetails.DataAccess
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
    }
}
