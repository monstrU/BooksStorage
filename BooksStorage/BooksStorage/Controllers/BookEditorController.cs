using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
            BookEditViewModel book;
            if (!bookId.HasValue)
            {
                book = new BookEditViewModel();
            }
            else
            {
                var bookDb = BooksService.LoadBook(bookId.GetValueOrDefault());
                IList<PersonModel> persons = BooksService.LoadPersons();
                var converter= new BooksEditConverter(Constants.BookUrlsFolder, persons);
                book = converter.Convert(bookDb);
                
            }


            return View("Load", book);
        }

	
    }
}