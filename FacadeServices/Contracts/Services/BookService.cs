using System.Collections.Generic;
using DomainModel;
using FacadeServices.Interfaces.DataBases;
using FacadeServices.Interfaces.Services;

namespace FacadeServices.Contracts.Services
{
    public class BookService: ServiceBase, IBooksService
    {
        public BookService(IBookStorageDb bookStorageDb) : base(bookStorageDb)
        {
        }

        public IList<BookModel> LoadBooks()
        {
            return BookStorageDb.BooksMapper.LoadBooks();
        }

        public BookModel LoadBook(int bookId)
        {
            return BookStorageDb.BooksMapper.LoadBook(bookId);
        }
    }
}