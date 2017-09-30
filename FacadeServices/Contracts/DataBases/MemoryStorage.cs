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
        public List<PersonModel> Persons { get; set; }
        public MemoryStorage()
        {
            Books = new List<BookModel>();
            Persons = new List<PersonModel>();
            InitTestDb();
        }

        private void InitTestDb()
        {
            Persons.Add(new PersonModel
            {
                PersonId = 1,
                Name = "Лев",
                Family = "Толстой"
            });
            Persons.Add(new PersonModel
            {
                PersonId = 2,
                Name = "Илья",
                Family ="Ильф"
            });
            Persons.Add(new PersonModel
            {
                PersonId = 3,
                Name = "Евгений",
                Family ="Петров"
            });
            Persons.Add(new PersonModel
            {
                PersonId = 4,
                Name = "Аркадий",
                Family ="Стругацкий"
            });
            Persons.Add(new PersonModel
            {
                PersonId = 5,
                Name = "Борис",
                Family ="Стругацкий"
            });
            Persons.Add(new PersonModel
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
                ISBN = "978-5-17-090468-6",
                BookFileName = "",
                Authors = new List<PersonModel> {Persons[0]}
            });
            Books.Add(new BookModel
            {
                BookId = 2,
                Title = "Золотой теленок",
                PublishDate = new DateTime(2011, 11, 22),
                PagesCount = 214,
                Publisher = "Кантата",
                ISBN = "978-5-17-056062-2",
                BookFileName ="",
                Authors = new List<PersonModel> {  Persons[1], Persons[2]}
            });
            Books.Add(new BookModel
            {
                BookId = 3,
                Title = "Пикник на обочине",
                PublishDate = new DateTime(2014, 4, 3),
                PagesCount = 431,
                Publisher = "Terra",
                ISBN = "978-5-17-082983-5",
                BookFileName = "Arkadij_Strugatskij_Boris_Strugatskij__Piknik_na_obochine.jpeg",
                Authors = new List<PersonModel> {Persons[3], Persons[4]}
            });
            Books.Add(new BookModel
            {
                BookId = 4,
                Title = "Театральный роман",
                PublishDate = new DateTime(2011, 4, 2),
                PagesCount = 201,
                Publisher = "АСТ",
                ISBN = "978-5-44-530154-7",
                BookFileName = "Mihail_Bulgakov__Teatralnyj_roman.jpeg",
                Authors = new List<PersonModel> {  Persons[5] }
            });
        }

        public void Add(BookModel book)
        {
            Books.Add(book);
        }

        public void Add(PersonModel person)
        {
            Persons.Add(person);
        }

        public IList<BookModel> LoadBooks()
        {
            return Books;
        }

        public BookModel LoadBook(int bookId)
        {
            return Books.FirstOrDefault(b => b.BookId == bookId);
        }
        
        public void UpdateBook(BookModel book)
        {
            var bookIndex = Books.FindIndex(i => i.BookId == book.BookId);
            if (bookIndex >= 0)
            {
                Books.RemoveAt(bookIndex);
                Books.Add(book);
            }
            else
            {
                throw new Exception($"Не удалось найти книгу {book.Title} в хранилище.");
            }
        }

        public IList<PersonModel> LoadPersons()
        {
            return Persons;
        }

        public PersonModel LoadPerson(int personId)
        {
            return Persons.FirstOrDefault(b => b.PersonId == personId);
        }

        public void UpdatePerson(PersonModel person)
        {
            var personIndex = Persons.FindIndex(i => i.PersonId == person.PersonId);
            if (personIndex >= 0)
            {
                Persons.RemoveAt(personIndex);
                Persons.Add(person);
            }
            else
            {
                throw new Exception($"Не удалось найти писателя {person.Family} в хранилище.");
            }
        }
    }
}