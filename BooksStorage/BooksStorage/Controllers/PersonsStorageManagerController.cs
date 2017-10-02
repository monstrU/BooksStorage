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
                result = CreateErrorResult();
            }
            else
            {
                try
                {
                    var converter = new PersonConverter();
                    var personDb = converter.Convert(person);
                    BooksService.UpdatePerson(personDb);
                    person.PersonId = personDb.PersonId;
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

        [ActionName("AddPerson")]
        [HttpPost]
        public IHttpActionResult AddPerson([FromBody] PersonEditViewModel person)
        {
            IOperationResult result;
            if (!ModelState.IsValid)
            {
                result = CreateErrorResult();
            }
            else
            {
                try
                {
                    
                    var converter = new PersonEditConverter();
                    var personDb = converter.Convert(person);

                    BooksService.AddPerson(personDb);
                    person.PersonId = personDb.PersonId;
                    result = new OperationResult<PersonEditViewModel>
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

        [ActionName("DeletePerson")]
        [HttpGet]
        public IHttpActionResult DeletePerson(int personId)
        {
            IOperationResult result;
            try
            {
                BooksService.DeletePerson(personId);
                result = new OperationResult
                {
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
            return CreateResult(result);
        }
    }
}