﻿using System.Collections.Generic;
using DomainModel;
using FacadeServices.Interfaces.DataBases;
using FacadeServices.Interfaces.Services;

namespace FacadeServices.Contracts.Services
{
    public class BookService: ServiceBase, IBooksService
    {
        public BookService(IBookStorageDb bookStorageDb, IMemoryStorage memoryStorage) : base(bookStorageDb, memoryStorage)
        {
        }

        public IList<BookModel> LoadBooks()
        {
            return MemoryStorage.LoadBooks();
        }

        public BookModel LoadBook(int bookId)
        {
            return MemoryStorage.LoadBook(bookId);
        }
    }
}