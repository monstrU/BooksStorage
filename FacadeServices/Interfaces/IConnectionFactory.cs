using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeServices.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
