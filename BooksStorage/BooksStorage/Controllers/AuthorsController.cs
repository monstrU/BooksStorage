using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class AuthorsController : ControllerBase
    {
        public AuthorsController(IBooksService booksService): base(booksService)
        {
        }
        // GET: Autors
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}