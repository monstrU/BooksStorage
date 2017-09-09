using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DomainModel;
using FacadeServices.Interfaces;
using FacadeServices.Interfaces.DataBases;

namespace FacadeServices.Contracts.Mappers
{
    public class BooksMapper: MapperBase, IBooksMapper
    {
        public BooksMapper(IConnectionFactory connFactory) : base(connFactory)
        {
        }

        public IList<BookModel> LoadBooks()
        {
            var lookup = new Dictionary<int, BookModel>();
            IList<BookModel> result;
            using (var conn = CreateConnection())
            {
                result = conn.Query<BookModel, PersonModel, BookModel>(@"select 	Books.BookId, 
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
                                 BookModel foundBook;
                                 if (!lookup.TryGetValue(book.BookId, out foundBook))
                                 {
                                     foundBook = book;
                                     lookup.Add(book.BookId, foundBook);
                                 }
                                 foundBook.Authors.Add(person);
                                 return foundBook;
                             },
                             splitOn: "PersonId",
                             commandType: CommandType.Text
                         )
                         .Distinct()
                         .ToList();
            }
         return result;
            
        }

        public BookModel LoadBook(int bookId)
        {
            var lookup = new Dictionary<int, BookModel>();
            IList<BookModel> result=new List<BookModel>();
            using (var conn = CreateConnection())
            {
                try
                {
                    var  result2 = conn.Query<BookModel, PersonModel, BookModel>(@"select 	
                            Books.BookId, 
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
	                    where Books.BookId==@bookId",
                        (book, person) =>
                        {
                            BookModel foundBook;
                            if (!lookup.TryGetValue(book.BookId, out foundBook))
                            {
                                foundBook = book;
                                lookup.Add(book.BookId, foundBook);
                            }
                            foundBook.Authors.Add(person);
                            return foundBook;
                        },
                        splitOn: "PersonId",
                        commandType: CommandType.Text,
                        param: new { bookId }
                        );
                    result = result2.Distinct().ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return result.FirstOrDefault();
        }
    }
}
