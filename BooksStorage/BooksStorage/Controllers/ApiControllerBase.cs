using System.Linq;
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

        protected IOperationResult CreateErrorResult()
        {
            IOperationResult result;
            result = new OperationResult();
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Any())
                {
                    foreach (var error in state.Value.Errors)
                    {
                        result.ErrorMessages.Add(error.ErrorMessage);
                    }
                    result.IsSuccess = false;
                }
            }
            return result;
        }
    }
}