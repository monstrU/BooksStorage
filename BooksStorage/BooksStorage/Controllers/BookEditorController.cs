﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksStorage.Utils;
using BooksStorage.Utils.Converters;
using DomainModel;
using FacadeServices;
using FacadeServices.Factories;
using FacadeServices.Interfaces;

namespace BooksStorage.Controllers
{
    public class BookEditorController : ControllerBase
    {
        public BookEditorController()
        {
            
        }

        public ActionResult Load(Nullable<int> bookId)
        {
            BookViewModel book;
            if (!bookId.HasValue)
            {
                book = new BookViewModel();
            }
            else
            {
                /*var dbFactory = new SqLiteConnectionFactory();
                var DataProvider = new DataProvider(dbFactory);
                var DataService = new BookStorageService(DataProvider);
                DataService.InitSqDb();*/

                var bookDb = BooksService.LoadBook(bookId.GetValueOrDefault());
                var converter= new BooksConverter(Constants.BookUrlsFolder);
                book = converter.Convert(bookDb);
            }
            return View("Load", book);
		}

		// GET: BookEditor
		public ActionResult Save(BookViewModel book)
        {
            
            var converter = new BooksConverter(Constants.BookUrlsFolder);
            //var dalBooks = DataService.LoadBooks();
            //var books = dalBooks.Select(converter.Convert).ToList();
            return View("Load", book);
        }
    }
}