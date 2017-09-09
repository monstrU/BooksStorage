using System.Collections.Generic;
using DomainModel;

namespace FacadeServices.Interfaces.Services
{
    public interface IBooksService
    {
        IList<BookModel> LoadBooks();
    }
}