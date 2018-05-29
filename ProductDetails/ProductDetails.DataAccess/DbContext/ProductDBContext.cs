using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProductDetails.DataAccess
{
    public class ProductDBContext: DbContext
    {
        public ProductDBContext() : base("name=ProductDBContext")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new UniDBInitializer<ProductDBContext>());
            base.OnModelCreating(modelBuilder);
        }

        private class UniDBInitializer<T>: DropCreateDatabaseAlways<ProductDBContext>
        {
            protected override void Seed(ProductDBContext context)
            {

                var productList = new List<Product>();
                productList.Add(new Product()

                //  Product p1= new Product()

                {
                    ProductId = 1,
                    Name = "Lenova s series",
                    UnitPrice = 400,
                    UnitsInStock = 20,
                    Discontinued = false,
                });
                productList.Add(new Product()
                {
                    ProductId = 2,
                    Name = "Samsung s8",
                    UnitPrice = 300,
                    UnitsInStock = 10,
                    Discontinued = false
                });
                // context.tblProduct.Add(productList);
                productList.ForEach(s => context.Products.Add(s));
                context.SaveChanges();

                var supplierList = new List<Supplier>();
                supplierList.Add(new Supplier()
                {
                    SupplierId = 1,
                    SupplierName = "Walmart",
                    ProductId = 1
                });
                supplierList.Add(new Supplier()
                {
                    SupplierId = 2,
                    SupplierName = "Target",
                    ProductId = 2
                });

                foreach (Supplier e in supplierList)
                {
                    var supplierListinDatabase = context.Suppliers.Where(
                        s => s.ProductId == e.ProductId).SingleOrDefault();
                    if (supplierListinDatabase == null)
                    {
                        context.Suppliers.Add(e);
                    }
                }
                context.SaveChanges();
                base.Seed(context);


                //supplierList.ForEach(s => context.Suppliers.Add(s));
                //context.SaveChanges();

                var categoryList = new List<Category>();
                categoryList.Add(new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Laptop",
                    ProductId = 1
                });
                categoryList.Add(new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Mobile",
                    ProductId = 2
                });

                //categoryList.ForEach(s => context.Categories.Add(s));
                //context.SaveChanges();
                //base.Seed(context);

                foreach (Category e in categoryList)
                {
                    var categoryListinDatabase = context.Categories.Where(
                        s => s.ProductId == e.ProductId).SingleOrDefault();
                    if (categoryListinDatabase == null)
                    {
                        context.Categories.Add(e);
                    }
                }
                context.SaveChanges();
                base.Seed(context);

            }
        }
       
    }
}
