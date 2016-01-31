using System.Web.Mvc;

namespace BooksStorage.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Http404()
        {
            Response.StatusCode = 404;

            return View();
        }
    }
}