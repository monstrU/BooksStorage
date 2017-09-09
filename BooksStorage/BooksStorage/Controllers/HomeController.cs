using System.Linq;
using System.Web.Mvc;
using BooksStorage.Utils;
using BooksStorage.Utils.Converters;
using FacadeServices;
using FacadeServices.Contracts.DataBases;
using FacadeServices.Contracts.Services;
using FacadeServices.Factories;
using FacadeServices.Interfaces;
using FacadeServices.Interfaces.DataBases;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class HomeController : Controller
    {
        public IBookStorageService DataService { get; set; }
        public IDataProvider DataProvider { get; set; }

        public IBookStorageDb BookStorage { get; set; }

        public IBooksService BooksService { get; set; }

        public HomeController()
        {
            var dbFactory = new SqLiteConnectionFactory();
            DataProvider = new DataProvider(dbFactory);
            DataService = new BookStorageService(DataProvider);
            DataService.InitSqDb();

            BookStorage = new BookStrogeDb(dbFactory);
            BooksService= new BookService(BookStorage);
        }
        public ActionResult Index()
        {
            //var dalBooks= DataService.LoadBooks();
            var dalBooks = BooksService.LoadBooks();

            var converter = new BooksConverter(Constants.BookUrlsFolder);
            
            var books = dalBooks.Select(converter.Convert).ToList();
            return View("Index", books);
        }
    }
}