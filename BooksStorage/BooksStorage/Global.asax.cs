using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FacadeServices.Contracts.DataBases;
using FacadeServices.Contracts.Services;
using FacadeServices.Interfaces.DataBases;
using FacadeServices.Interfaces.Services;

namespace BooksStorage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);



            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            DependencyResolverInit();
        }
            
        private static void DependencyResolverInit()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new MemoryStorage()).As<IMemoryStorage>().SingleInstance();
            builder.Register(c => new BookService(c.Resolve<IMemoryStorage>()))
                .As<IBooksService>()
                .InstancePerRequest();


            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterFilterProvider();
            
            var container = builder.Build();

            // Create the depenedency resolver.
            var resolver = new AutofacDependencyResolver(container);

            
            // Configure MVC controler with the dependency resolver.
            DependencyResolver.SetResolver(resolver);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);



            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }

        
    }
}
