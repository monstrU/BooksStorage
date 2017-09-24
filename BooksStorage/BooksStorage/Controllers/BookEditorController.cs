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
         

            return View("Load", book);
        }

	
    }
}