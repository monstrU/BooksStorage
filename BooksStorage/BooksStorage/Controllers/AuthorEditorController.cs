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
    public class AuthorEditorController : ControllerBase
    {
        public AuthorEditorController(IBooksService booksService): base(booksService)
        {
        }

        public ActionResult Load(Nullable<int> personId)
        {
            PersonViewModel person;
            if (!personId.HasValue)
            {
                person = new PersonViewModel();
            }
            else
            {
                var personDb = BooksService.LoadPerson(personId.GetValueOrDefault());
                var converter= new PersonConverter();
                person = converter.Convert(personDb);
                
            }


            return View("Load", person);
        }

	
    }
}