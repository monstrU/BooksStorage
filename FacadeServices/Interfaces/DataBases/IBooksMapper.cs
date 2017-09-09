using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace FacadeServices.Interfaces.DataBases
{
    public interface IBooksMapper
    {
        IList<BookModel> LoadBooks();
    }
}
