using System.Web.Mvc;
using FacadeServices.Contracts.DataBases;
using FacadeServices.Interfaces.DataBases;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class ControllerBase : Controller
    {
        public IBooksService BooksService { get; set; }

        public ControllerBase(IBooksService booksService)
        {
            BooksService = booksService;
        }
    }
}