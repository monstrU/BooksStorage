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

                IList<PersonModel> persons = BooksService.LoadPersons();
                var personConverter = new PersonConverter();

                var blPersons = persons.Select(personConverter.Convert).ToList();
                foreach (var person in blPersons)
                {
                    person.IsSelected = book.Authors.Any(a => a.PersonId == person.PersonId);
                }

                book.FullAuthorsList = blPersons;
            }
         

            return View("Load", book);
        }

	
    }
}