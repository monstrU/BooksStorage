using System.Collections.Generic;
using System.Linq;
using DomainModel;
using FacadeServices.Interfaces.DataBases;

namespace FacadeServices.Contracts.DataBases
{
    public class MemoryStorage :IMemoryStorage
    {
        public IList<BookModel> Books { get; set; }
        public IList<PersonModel> Authors { get; set; }
        public MemoryStorage()
        {
            Books = new List<BookModel>();
            Authors = new List<PersonModel>();
        }

        public void Add(BookModel book)
        {
            Books.Add(book);
        }

        public void Add(PersonModel person)
        {
            Authors.Add(person);
        }

        public IList<BookModel> LoadBooks()
        {
            return Books;
        }

        public BookModel LoadBook(int bookId)
        {
            return Books.FirstOrDefault(b => b.BookId == bookId);
        }
    }
}