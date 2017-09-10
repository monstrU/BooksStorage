using System;
using System.Linq;
using System.Web.Mvc;
using BooksStorage.Utils;
using BooksStorage.Utils.Converters;
using DomainModel;
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
            var dalBooks = BooksService.LoadBooks();

            var converter = new BooksConverter(Constants.BookUrlsFolder);
            
            var books = dalBooks.Select(converter.Convert).ToList();
            return View("Index", books);
        }

        public ActionResult Load(Nullable<int> bookId)
        {
            var bookDb = BooksService.LoadBook(bookId.GetValueOrDefault());
            var converter = new BooksConverter(Constants.BookUrlsFolder);
            var book = converter.Convert(bookDb);
            return View("Load", book);
        }

        [HttpPost]
        public ActionResult SaveBook(BookViewModel book)
        {
            return View("Load", book);
        }

    }
}