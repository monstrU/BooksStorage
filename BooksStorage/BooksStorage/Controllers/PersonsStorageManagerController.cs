using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BooksStorage.Utils;
using BooksStorage.Utils.Converters;
using BooksStorage.Utils.Interfaces;
using BooksStorage.ViewModels;
using DomainModel;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class PersonsStorageManagerController : ApiControllerBase
    {
        public IBooksService BooksService { get; set; }

        public PersonsStorageManagerController(IBooksService booksService)
        {
            BooksService = booksService;
        }


        [ActionName("Run")]
        [HttpGet]
        public IHttpActionResult Run()
        {
            return Ok("aaaaaaaaaa");
        }

        [ActionName("SavePerson")]
        [HttpPost]
        public IHttpActionResult SavePerson([FromBody]PersonViewModel person)
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
                    var converter = new PersonConverter();
                    var personDb = converter.Convert(person);
                    BooksService.UpdatePerson(personDb);
                    result = new OperationResult<PersonViewModel>
                    {
                        DataResult = person,
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