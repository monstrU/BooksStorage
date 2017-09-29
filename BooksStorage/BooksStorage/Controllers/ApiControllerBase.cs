using System.Net;
using System.Web.Http;
using BooksStorage.Utils;
using BooksStorage.Utils.Interfaces;

namespace BooksStorage.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected IHttpActionResult CreateResult(IOperationResult result)
        {
            IHttpActionResult httpResult;
            if (result.IsSuccess)
                httpResult = Ok(result);
            else
                httpResult = Content(HttpStatusCode.InternalServerError, result);
            return httpResult;
        }
    }
}