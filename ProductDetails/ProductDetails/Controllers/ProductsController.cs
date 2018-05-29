using Autofac;
using Kendo.DynamicLinq;
using ProductDetails.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Dynamic;

namespace ProductDetails.Controllers
{
    public class ProductsController : Controller
    {
        //   readonly DataAccess.ProductDBContext _dbcontext = new DataAccess.ProductDBContext();

        private readonly IProductRepository _IProductRepository;
        private readonly DbContext _dbContext;
        // GET: Products
        public ProductsController(IProductRepository productRepository, DbContext dbContext)
        {
            _dbContext = dbContext;
            _IProductRepository = productRepository;
        }

        //public ActionResult ProductDetails()
        //{
        //    try
        //    {
        //        var products = _IProductRepository.GetAll();
        //        var productsList =
        //            //products.Select(p => new Product
        //            //{
        //            //    ProductId = p.ProductId,
        //            //    Name = p.Name,
        //            //    UnitPrice = p.UnitPrice,
        //            //    UnitsInStock = p.UnitsInStock,
        //            //    Discontinued = p.Discontinued
        //            //});

        //            (from p in products
        //             select new ProductDetailsViewModel()
        //             {
        //                 ProductId = p.ProductId,
        //                 Name = p.Name,
        //                 UnitPrice = p.UnitPrice,
        //                 UnitsInStock = p.UnitsInStock,
        //                 Discontinued = p.Discontinued,
        //                 //SupplierName = p.supplier.Name,
        //                 //CategoryName = p.category.Name
        //             }).ToList();
        //        return View("ProductDetails", productsList);
        //        //var products = _dbcontext.Products.Select(p => new DataAccess.Product
        //        //{
        //        //    ProductId = p.ProductId,
        //        //    Name = p.Name,
        //        //    UnitPrice = p.UnitPrice,
        //        //    UnitsInStock = p.UnitsInStock,
        //        //    Discontinued = p.Discontinued,
        //        //    supplier = new Supplier
        //        //    {
        //        //        SupplierId = p.supplier.SupplierId,
        //        //        Name = p.supplier.Name
        //        //    },
        //        //    category = new Category
        //        //    {
        //        //        CategoryId = p.category.CategoryId,
        //        //        Name = p.category.Name
        //        //    }
        //        //});
        //        //  return View(products);
        //    }


        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //}

        // [HttpPost]
        //public ActionResult ProductDetails(int take, int skip, IEnumerable<Sort> sort, Kendo.DynamicLinq.Filter filter)
        //{
        //    try
        //    {
        //        var products = _IProductRepository.GetAll();
        //        var productsList =
        //             (from p in products
        //             select new ProductDetailsViewModel()
        //             {
        //                 ProductId = p.ProductId,
        //                 Name = p.Name,
        //                 UnitPrice = p.UnitPrice,
        //                 UnitsInStock = p.UnitsInStock,
        //                 Discontinued = p.Discontinued,
        //                 //SupplierName = p.supplier.Name,
        //                 //CategoryName = p.category.Name
        //             }).ToDataSourceResult(take, skip, sort, filter);
        //        return Json(productsList);
        //       }

        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        // }
        public ActionResult ProductDetails()
        {
            return View();
        }
        public JsonResult GetProductDetails([DataSourceRequest] Kendo.Mvc.UI.DataSourceRequest request)
      //      public JsonResult GetProductDetails(int take, int skip, IEnumerable<Kendo.DynamicLinq.Sort> sort, Kendo.DynamicLinq.Filter filter)
        {
            try
            {
                //dynamic BCVM = new ExpandoObject();
                //BCVM.products = _IProductRepository.GetAll().ToDataSourceResult(request);
                //return Json(BCVM.products,JsonRequestBehavior.AllowGet);
                var products = _IProductRepository.GetAll();
                var productsList =
                     (from p in products
                      select new ProductDetailsViewModel()
                      {
                          ProductId = p.ProductId,
                          Name = p.Name,
                          UnitPrice = p.UnitPrice,
                          UnitsInStock = p.UnitsInStock,
                          Discontinued = p.Discontinued,
                          SupplierName = p.supplier.SupplierName,
                          CategoryName = p.category.CategoryName
                      }).ToDataSourceResult(request);
                //        }).ToDataSourceResult(take, skip, sort, filter);
                return Json(productsList, JsonRequestBehavior.AllowGet);
            }

            catch (Exception e)
            {
                throw e;
            }

        }


     }
}