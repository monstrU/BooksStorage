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
                MemoryStorage.UpdateBook(book);
        }

        public IList<PersonModel> LoadPersons()
        {
            return MemoryStorage.LoadPersons();
        }

        public PersonModel LoadPerson(int personId)
        {
            return MemoryStorage.LoadPerson(personId);
        }

        public void UpdatePerson(PersonModel person)
        {
            MemoryStorage.UpdatePerson(person);
        }

        public void DeleteBook(int bookId)
        {
            MemoryStorage.DeleteBook(bookId);
        }
    }
}