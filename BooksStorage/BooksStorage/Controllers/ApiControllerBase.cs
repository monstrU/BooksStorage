using System.Net;
using System.Web.Http;
using BooksStorage.Utils;

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