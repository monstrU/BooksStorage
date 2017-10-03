using System;
using System.Web.Mvc;
using BooksStorage.Utils.Converters;
using BooksStorage.ViewModels;
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

            return View(!person.IsNewPerson ? "AddNewPerson" : "Load", person);
            
        }

	
    }
}