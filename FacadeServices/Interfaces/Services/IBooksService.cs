using System.Collections.Generic;
using DomainModel;

namespace FacadeServices.Interfaces.Services
{
    public interface IBooksService
    {
        IList<BookModel> LoadBooks();
        BookModel LoadBook(int bookId);
        void UpdateBook(BookModel book);
        IList<PersonModel> LoadPersons();

        PersonModel LoadPerson(int personId);
    }
}