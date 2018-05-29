using Autofac;
using Autofac.Integration.Mvc;
using ProductDetails.DataAccess;
using System.Data.Entity;
using System.Web.Mvc;

namespace ProductDetails
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType(typeof(ProductDBContext)).As<DbContext>();
            builder.RegisterType(typeof(ProductRepository)).As<IProductRepository>();
            //builder.RegisterType(typeof(AddressRepository)).As<IAddressRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}