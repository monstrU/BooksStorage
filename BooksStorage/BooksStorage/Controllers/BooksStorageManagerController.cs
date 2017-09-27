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
    public class BooksStorageManagerController : ApiControllerBase
    {
        public IBooksService BooksService { get; set; }

        public BooksStorageManagerController(IBooksService booksService)
        {
            BooksService = booksService;
        }
        
        [ActionName("SaveBook")]
        [HttpPost]
        public IHttpActionResult SaveBook([FromBody]BookEditViewModel book)
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
                    IList<PersonModel> persons = BooksService.LoadPersons();
                    var converter = new BooksEditConverter(Constants.BookUrlsFolder, persons);
                    var bookDb = converter.Convert(book);
                    BooksService.UpdateBook(bookDb);
                    result = new OperationResult<BookEditViewModel>
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
        
            return CreateResult(result);
        }

      
    }
}