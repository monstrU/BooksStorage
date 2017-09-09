using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DomainModel;
using FacadeServices.Factories;
using FacadeServices.Interfaces;

namespace FacadeServices
{
    public class BookStorageService : IBookStorageService
    {
        public IDataProvider Provider { get; private set; }


        public BookStorageService(IDataProvider provider)
        {
            Provider = provider;
        }

        public void InitSqDb()
        {


            Provider.Execute(@"CREATE TABLE ""Books"" (
	                                `BookId`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                                `PagesCount`	INTEGER NOT NULL,
	                                `Publisher`	TEXT,
	                                `ISBN`	TEXT,
	                                `BookFileName`	TEXT NULL,
	                                `Title`	TEXT NOT NULL,
	                                `PublishDate`	TEXT
                                );
                                CREATE TABLE `Persons` (
	                                `PersonId`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                                `Name`	TEXT NOT NULL,
	                                `Family`	TEXT NOT NULL
                                );
                                CREATE TABLE `Authors` (
	                                `PersonId`	INTEGER NOT NULL,
	                                `BookId`	INTEGER NOT NULL,
	                                PRIMARY KEY(PersonId,BookId),
	                                FOREIGN KEY(`PersonId`) REFERENCES `Persons`(`PersonId`),
	                                FOREIGN KEY(`BookId`) REFERENCES `Books`(`BookId`)
                                );",
                              null,
                              CommandType.Text);

            Provider.Execute("insert into books (Title, PublishDate,  PagesCount, Publisher, ISBN) values('Война и мир', '1991-01-02 00:00:00', 1500, 'Эксмо', '2-266-11156')", null, CommandType.Text);
            Provider.Execute("insert into books (Title, PublishDate,  PagesCount, Publisher, ISBN) values('Золотой теленок', '2011-11-22 00:00:00', 234, 'Кантата', '2-266-14456')", null, CommandType.Text);
            //Аркадий Стругацкий, Борис Стругацкий
            Provider.Execute("insert into books (Title, PublishDate,  PagesCount, Publisher, ISBN, BookFileName) values('Пикник на обочине', '2011-11-22 00:00:00', 201, 'Terra', '978-5-17-057848-1','Arkadij_Strugatskij_Boris_Strugatskij__Piknik_na_obochine.jpeg')", null, CommandType.Text);

            //Театральный роман
            Provider.Execute("insert into books (Title, PublishDate,  PagesCount, Publisher, ISBN, BookFileName) values('Театральный роман', '2011-11-22 00:00:00', 138, 'АСТ', '5-17-015967-6', 'Mihail_Bulgakov__Teatralnyj_roman.jpeg')", null, CommandType.Text);

            Provider.Execute("insert into Persons (Name, Family) values('Лев', 'Толстой')", null, CommandType.Text);
            Provider.Execute("insert into Persons (Name, Family) values('Илья', 'Ильф')", null, CommandType.Text);
            Provider.Execute("insert into Persons (Name, Family) values('Евгений', 'Петров')", null, CommandType.Text);
            Provider.Execute("insert into Persons (Name, Family) values('Аркадий', 'Стругацкий')", null, CommandType.Text);
            Provider.Execute("insert into Persons (Name, Family) values('Борис', 'Стругацкий')", null, CommandType.Text);
            Provider.Execute("insert into Persons (Name, Family) values('Михаил', 'Булгаков')", null, CommandType.Text);

            Provider.Execute("insert into Authors(PersonId, BookId) values(1,1)", null, CommandType.Text);
            Provider.Execute("insert into Authors(PersonId, BookId) values(2,2)", null, CommandType.Text);
            Provider.Execute("insert into Authors(PersonId, BookId) values(3,2)", null, CommandType.Text);
            Provider.Execute("insert into Authors(PersonId, BookId) values(4, 3)", null, CommandType.Text);
            Provider.Execute("insert into Authors(PersonId, BookId) values(5, 3)", null, CommandType.Text);
            Provider.Execute("insert into Authors(PersonId, BookId) values(6, 4)", null, CommandType.Text);

        }
        public IEnumerable<BookModel> LoadBooks()
        {
            var gbooks = Provider.QueryMultiple<BookModel, PersonModel>(@"select 	Books.BookId, 
		                    Books.Title, 
		                    Books.PublishDate,  
		                    Books.PagesCount, 
		                    Books.Publisher, 
		                    Books.ISBN, 
		                    Books.BookFileName,
		                    Persons.PersonId,
		                    Persons.Name,
		                    Persons.Family
	                    from Books 
		                    inner join Authors on Authors.BookId=Books.BookId
		                    inner join Persons on Persons.PersonId=Authors.PersonId
	                    order by Books.Title",
                            (book, person) =>
                            {
                                book.Authors.Add(person);
                                return book;
                            }, 
                            "PersonId",
                            CommandType.Text
                        ).ToList();
            var authors = Provider.Query<AuthorModel>(string.Format(@"select PersonId, BookId from Authors"), CommandType.Text).ToList();
            var persons = Provider.Query<PersonModel>(string.Format(@"select PersonId, Name, Family from Persons"), CommandType.Text).ToList();
            /*
            foreach (var book in gbooks)
            {
                var tempAuthors = new List<AuthorModel>();
                
                var bookAuhtors = authors.Where(a => a.BookId == book.BookId);
                foreach (var bauthor in bookAuhtors)
                {
                    var person = persons.FirstOrDefault(p => p.PersonId == bauthor.Person.PersonId);
                    if (person != null)
                    {
                        tempAuthors.Add(new AuthorModel
                        {
                            BookId = book.BookId,
                            Person = new PersonModel()
                            {
                                PersonId = person.PersonId
                            }
                        });
                    }


                }

                book.Authors = tempAuthors;
                
            }*/
            return gbooks;
        }

        /*public GuestBookModel AddGuestBook(GuestBookModel book)
        {
           Provider.Execute(@"insert into GuestBooks(GuestBookName) values(@szGuestBookName)"
                , new { szGuestBookName = book.GuestBookName }
                , CommandType.Text);
            return book;
        }

        public GuestBookModel DeleteGuestBook(GuestBookModel book)
        {
            Provider.Execute(@"delete from GuestBooks where GuestBookId=@nGuestBookId"
                 , new { nGuestBookId = book.GuestBookId }
                 , CommandType.Text);
            return book;
        }
        public GuestBookModel LoadGuestBook(int guestBookId)
        {
            var gbooks = Provider.Query<GuestBookModel>(@"select GuestBookId,  GuestBookName from GuestBooks where GuestBookId=@nGuestBookId"
                , new { nGuestBookId = guestBookId}
                , CommandType.Text);

            return gbooks.FirstOrDefault();
        }

        public void UpdateGuestBook(GuestBookModel  book)
        {
            Provider.Execute(@"update GuestBooks set GuestBookName=@szGuestBookName where GuestBookId=@nGuestBookId"
                , new { szGuestBookName = book.GuestBookName, nGuestBookId = book.GuestBookId }
                , CommandType.Text);
        }

        public IEnumerable<MessageModel> LoadMessages()
        {
            
            var messages = Provider.Query<MessageModel>(@"select MessageId, Title, Body, CreateDate, GuestBookId, UserId from dbo.Messages order by CreateDate desc"
                , CommandType.Text);
            return messages;
        }

        public IEnumerable<MessageModel> LoadMessagesInBook(int guestBookId)
        {

            var messages = Provider.Query<MessageModel>(@"select MessageId, Title, Body, CreateDate, GuestBookId, UserId from dbo.Messages 
                            where  GuestBookId=@nGuestBookId                       
                            order by CreateDate desc"
                , new { nGuestBookId = guestBookId}
                , CommandType.Text);
            return messages;
        }

        public void AddMessage(MessageModel model)
        {
            Provider.Execute(@"insert into Messages(Title, Body, UserId, GuestBookId) values(@szTitle, @szBody, null, @szGuestBookId)"
                , new {szTitle = model.Title, szBody = model.Body, szGuestBookId = model.GuestBook.GuestBookId}
                , CommandType.Text);

        }

        public  GuestBookModel GetDefaultGuestBook(Nullable<int> guestbookId)
        {
            int tempGuestBookId = 1;
            GuestBookModel book= new GuestBookModel();
            book.GuestBookId = guestbookId.HasValue ? guestbookId.Value : tempGuestBookId;
            return book;
        }
        */
    }
}


