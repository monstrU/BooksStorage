using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacadeServices.Interfaces;
using FacadeServices.Interfaces.DataBases;

namespace FacadeServices.Contracts.Mappers
{
    public abstract class MapperBase: IMapper
    {
        private IConnectionFactory ConnectionFactory { get; set; }
        public IDbConnection CreateConnection()
        {
            return ConnectionFactory.CreateConnection();
        }

        protected MapperBase(IConnectionFactory connFactory)
        {
            ConnectionFactory = connFactory;
        }
    }
}
