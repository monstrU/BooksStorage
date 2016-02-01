using System.Web.Mvc;
using FacadeServices;
using FacadeServices.Factories;
using FacadeServices.Interfaces;

namespace BooksStorage.Controllers
{
    public class HomeController : Controller
    {
        public IBookStorageService DataService { get; set; }
        public IDataProvider DataProvider { get; set; }

        public HomeController()
        {
            var dbFactory = new SqLiteConnectionFactory();
            DataProvider = new DataProvider(dbFactory);
            DataService = new BookStorageService(DataProvider);
            DataService.InitSqDb();
        }
        public ActionResult Index()
        {
            var books= DataService.LoadBooks();
            return View();
        }
    }
}