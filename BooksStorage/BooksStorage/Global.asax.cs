using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FacadeServices;
using FacadeServices.Factories;

namespace BooksStorage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitDataBase();
        }

        private static void InitDataBase()
        {
            var dbFactory = new SqLiteConnectionFactory();
            var DataProvider = new DataProvider(dbFactory);
            var DataService = new BookStorageService(DataProvider);
            DataService.InitSqDb();

        }
    }
}
