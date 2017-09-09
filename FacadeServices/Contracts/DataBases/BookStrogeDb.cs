using FacadeServices.Contracts.Mappers;
using FacadeServices.Interfaces;
using FacadeServices.Interfaces.DataBases;

namespace FacadeServices.Contracts.DataBases
{
    public class BookStrogeDb: IBookStorageDb
    {
        public IBooksMapper BooksMapper { get; }

        public BookStrogeDb(IConnectionFactory connectionFactory)
        {
            BooksMapper= new BooksMapper(connectionFactory);
        }
    }
}