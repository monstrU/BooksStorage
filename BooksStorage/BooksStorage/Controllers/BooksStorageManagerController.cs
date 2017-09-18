using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BooksStorage.Utils;
using BooksStorage.Utils.Converters;
using BooksStorage.ViewModels;
using DomainModel;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class BooksStorageManagerController : ApiController
    {
        public IBooksService BooksService { get; set; }

        public BooksStorageManagerController(IBooksService booksService)
        {
            BooksService = booksService;
        }
        
        [ActionName("SaveBook")]
        [HttpPost]
        public IHttpActionResult SaveBook([FromBody]BookViewModel book)
        {

            IOperationResult result;
            if (!ModelState.IsValid)
            {
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
            }
            else
            {
                try
                {
                    var converter = new BooksConverter(Constants.BookUrlsFolder);
                    var bookDb = converter.Convert(book);
                    BooksService.UpdateBook(bookDb);
                    result = new OperationResultGeneric<BookViewModel>
                    {
                        DataResult = book,
                        IsSuccess = true
                    };
                    
                }
                catch (Exception ex)
                {
                    result = new OperationResult
                    {
                        IsSuccess = false
                    };
                    result.ErrorMessages.Add(ex.Message);
                }
            }
          
            IHttpActionResult httpResult;
            if (result.IsSuccess)
                httpResult = Ok(result);
            else
                httpResult = Content(HttpStatusCode.InternalServerError, result);
            
            return httpResult;
        }
    }
}