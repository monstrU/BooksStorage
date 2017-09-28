using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksStorage.Utils.Converters;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class AuthorsController : ControllerBase
    {
        public AuthorsController(IBooksService booksService): base(booksService)
        {
        }
        
        public ActionResult Index()
        {
            var dbPersons = BooksService.LoadPersons();
            var concerter = new PersonConverter();
            var authors = dbPersons.Select(concerter.Convert).ToList();
            return View("Index", authors);
        }

        public ActionResult PersonItem(int personId)
        {
            var personDb = BooksService.LoadPerson(personId);

            var converter = new PersonConverter();

            var person = converter.Convert(personDb);
            return View("DisplayTemplates/PersonItem", person);
        }
    }
}