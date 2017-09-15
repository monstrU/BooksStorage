using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;
using FacadeServices.Interfaces.DataBases;

namespace FacadeServices.Contracts.DataBases
{
    public class MemoryStorage :IMemoryStorage
    {
        public List<BookModel> Books { get; set; }
        public IList<PersonModel> Authors { get; set; }
        public MemoryStorage()
        {
            Books = new List<BookModel>();
            Authors = new List<PersonModel>();
            InitTestDb();
        }

        private void InitTestDb()
        {
            Authors.Add(new PersonModel
            {
                PersonId = 1,
                Name = "Лев",
                Family = "Толстой"
            });
            Authors.Add(new PersonModel
            {
                PersonId = 2,
                Name = "Илья",
                Family ="Ильф"
            });
            Authors.Add(new PersonModel
            {
                PersonId = 3,
                Name = "Евгений",
                Family ="Петров"
            });
            Authors.Add(new PersonModel
            {
                PersonId = 4,
                Name = "Аркадий",
                Family ="Стругацкий"
            });
            Authors.Add(new PersonModel
            {
                PersonId = 5,
                Name = "Борис",
                Family ="Стругацкий"
            });
            Authors.Add(new PersonModel
            {
                PersonId = 6,
                Name = "Михаил",
                Family = "Булгаков"
            });

            Books.Add(new BookModel
            {
                BookId = 1,
                Title = "Война и мир",
                PublishDate = new DateTime(1991, 01, 02),
                PagesCount = 412,
                Publisher = "Эксмо",
                ISBN = "2-266-11156",
                BookFileName = "",
                Authors = new List<PersonModel> {Authors[0]}
            });
            Books.Add(new BookModel
            {
                BookId = 2,
                Title = "Золотой теленок",
                PublishDate = new DateTime(2011, 11, 22),
                PagesCount = 214,
                Publisher = "Кантата",
                ISBN = "2-266-14456",
                BookFileName ="",
                Authors = new List<PersonModel> {  Authors[1], Authors[2]}
            });
            Books.Add(new BookModel
            {
                BookId = 3,
                Title = "Пикник на обочине",
                PublishDate = new DateTime(2014, 4, 3),
                PagesCount = 431,
                Publisher = "Terra",
                ISBN = "978-5-17-057848-1",
                BookFileName = "Arkadij_Strugatskij_Boris_Strugatskij__Piknik_na_obochine.jpeg",
                Authors = new List<PersonModel> {Authors[3], Authors[4]}
            });
            Books.Add(new BookModel
            {
                BookId = 4,
                Title = "Театральный роман",
                PublishDate = new DateTime(2011, 4, 2),
                PagesCount = 201,
                Publisher = "АСТ",
                ISBN = "5-17-015967-6",
                BookFileName = "Mihail_Bulgakov__Teatralnyj_roman.jpeg",
                Authors = new List<PersonModel> {  Authors[5] }
            });
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
        
        public void UpdateBook(BookModel oldBook, BookModel newBook)
        {
            var bookIndex = Books.FindIndex(i => i.BookId == oldBook.BookId);
            if (bookIndex >= 0)
            {
                Books.RemoveAt(bookIndex);
                Books.Add(newBook);
            }
        }
    }
}