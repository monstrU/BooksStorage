using System.Linq;
using System.Web.Mvc;
using BooksStorage.Utils;
using BooksStorage.Utils.Converters;
using FacadeServices;
using FacadeServices.Factories;
using FacadeServices.Interfaces;
using FacadeServices.Interfaces.DataBases;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController(IBooksService booksService): base(booksService)
        {
        }
        public ActionResult Index()
        {
            //var bookDb = BooksService.LoadBook(2);

            var dalBooks = BooksService.LoadBooks();

            var converter = new BooksConverter(Constants.BookUrlsFolder);
            
            var books = dalBooks.Select(converter.Convert).ToList();
            return View("Index", books);
        }
    }
}