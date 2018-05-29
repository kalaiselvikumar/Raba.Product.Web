using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDetails.DataAccess
{
    public class ProductRepository:IProductRepository
    {
        protected DbContext _entities;
        protected readonly IDbSet<Product> _dbset;

        public ProductRepository(DbContext dbContext)
        {
            _entities = dbContext;
            _dbset = _entities.Set<Product>();
        }
        public IQueryable<Product> GetAll()
        {

          var products= _dbset.Include("Supplier").Include("Category").OrderBy(p => p.ProductId);

            var test = _dbset.Include(a => a.supplier).Include(a => a.category).ToList();
            return products;
         //   return _dbset.OrderBy(p=>p.ProductId);
        }
    }
}
