using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BooksStorage.Utils;
using BooksStorage.Utils.Converters;
using BooksStorage.ViewModels;
using DomainModel;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class BookEditorController : ControllerBase
    {
        public BookEditorController(IBooksService booksService): base(booksService)
        {
        }

        public ActionResult Load(Nullable<int> bookId)
        {
            BookViewModel book;
            if (!bookId.HasValue)
            {
                book = new BookViewModel();
            }
            else
            {
                var bookDb = BooksService.LoadBook(bookId.GetValueOrDefault());
                var converter= new BooksConverter(Constants.BookUrlsFolder);
                book = converter.Convert(bookDb);
            }
            var list = new Dictionary<string, string> {{"aa", "aaaa"}};

            return View("Load", book);
        }

		//[HttpPost]
		public ActionResult Save(HttpPostedFileBase file)
		{
		    var files = Request.Files;
            var converter = new BooksConverter(Constants.BookUrlsFolder);
            //var dalBooks = DataService.LoadBooks();
            //var books = dalBooks.Select(converter.Convert).ToList();
            return View("Load", new BookViewModel());
        }
    }
}