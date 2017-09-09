using System.Web.Mvc;
using FacadeServices.Contracts.DataBases;
using FacadeServices.Contracts.Services;
using FacadeServices.Factories;
using FacadeServices.Interfaces.DataBases;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class ControllerBase : Controller
    {
        public IBooksService BooksService { get; set; }

        public ControllerBase(IBooksService booksService)
        {
            var dbFactory = new SqLiteConnectionFactory();
            var bookStorage = new BookStrogeDb(dbFactory);
            var memoryStrorage= new MemoryStorage();
            //BooksService= new BookService(memoryStrorage);
            BooksService = booksService;
        }
    }
}