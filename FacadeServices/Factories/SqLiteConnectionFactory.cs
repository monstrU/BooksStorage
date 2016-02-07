using System.Data;
using System.Data.SQLite;
using FacadeServices.Interfaces;

namespace FacadeServices.Factories
{
    public class SqLiteConnectionFactory : IConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
            const string connString = "Data Source=:memory:;pooling = true;";
            IDbConnection dbConnection = new SQLiteConnection(connString);
            dbConnection.Open();
            return dbConnection;
        }
    }
}