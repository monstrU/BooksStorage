using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksStorage.Utils;
using BooksStorage.Utils.Converters;
using DomainModel;
using FacadeServices;
using FacadeServices.Factories;
using FacadeServices.Interfaces;

namespace BooksStorage.Controllers
{
    public class BookEditorController : Controller
    {
        public IBookStorageService DataService { get; set; }
        public IDataProvider DataProvider { get; set; }

        public BookEditorController()
        {
            var dbFactory = new SqLiteConnectionFactory();
            DataProvider = new DataProvider(dbFactory);
            DataService = new BookStorageService(DataProvider);
        }

        public ActionResult LoadOne()
		{
			return View("Load", new BookViewModel());
		}

		// GET: BookEditor
		public ActionResult Save(BookViewModel book)
        {
            
            var converter = new BooksConverter(Constants.BookUrlsFolder);
            var dalBooks = DataService.LoadBooks();
            var books = dalBooks.Select(converter.Convert).ToList();
            return View("Load", book);
        }
    }
}