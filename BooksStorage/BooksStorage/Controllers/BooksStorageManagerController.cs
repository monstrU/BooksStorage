﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
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
                result = CreateErrorResult();
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

        [ActionName("AddBook")]
        [HttpPost]
        public IHttpActionResult AddBook([FromBody]BookEditViewModel book)
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
                    IList<PersonModel> persons = BooksService.LoadPersons();
                    var converter = new BooksEditConverter(Constants.BookUrlsFolder, persons);
                    var bookDb = converter.Convert(book);
                  
                    BooksService.AddBook(bookDb);
                    book.BookId = bookDb.BookId;
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

        [ActionName("DeleteBook")]
        [HttpGet]
        public IHttpActionResult DeleteBook(int bookId)
        {
            IOperationResult result;
            try
            {
                BooksService.DeleteBook(bookId);
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