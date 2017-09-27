using System;
using System.Collections.Generic;
using DomainModel;
using FacadeServices.Interfaces.DataBases;
using FacadeServices.Interfaces.Services;

namespace FacadeServices.Contracts.Services
{
    public class BookService: ServiceBase, IBooksService
    {
        public BookService(IMemoryStorage memoryStorage) : base(memoryStorage)
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

        public void UpdateBook(BookModel book)
        {
            var find = MemoryStorage.LoadBook(book.BookId);
            if (find != null)
            {
                MemoryStorage.UpdateBook(find, book);
            }
            else
            {
                throw new Exception($"Не удалось найти книгу {book.Title} в хранилище.");
            }
        }

        public IList<PersonModel> LoadPersons()
        {
            return MemoryStorage.LoadPersons();
        }
    }
}