using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace FacadeServices.Interfaces
{
    public interface IBookStorageService
    {
        void InitSqDb();
        IEnumerable<BookModel> LoadBooks();
    }
}
