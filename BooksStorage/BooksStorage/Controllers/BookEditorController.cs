using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel;

namespace BooksStorage.Controllers
{
    public class BookEditorController : Controller
    {
		public ActionResult LoadOne()
		{
			return View("Load", new BookViewModel());
		}

		// GET: BookEditor
		public ActionResult Load(BookViewModel book)
        {
            return View("Load", book);
        }
    }
}