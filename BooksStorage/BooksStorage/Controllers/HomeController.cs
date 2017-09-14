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

        public ActionResult BookItem(int bookId)
        {
            var dalBook = BooksService.LoadBook(bookId);

            var converter = new BooksConverter(Constants.BookUrlsFolder);

            var books = converter.Convert(dalBook);
            return View("DisplayTemplates/BookItem", books);
        }
    }
}