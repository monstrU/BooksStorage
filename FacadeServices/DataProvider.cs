using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Dapper;
using FacadeServices.Interfaces;

namespace FacadeServices
{
    public class DataProvider : IDataProvider 
    {
        public IConnectionFactory DbFactory { get; private set; }
        public DataProvider(IConnectionFactory dbFactory)
        {
            DbFactory = dbFactory;   
        }
        public IEnumerable<T> Query<T>(string query, CommandType commandType) where T: class
        {
            using(var conn = DbFactory.CreateConnection())
            {
                var items = conn.Query<T>(query, commandType: commandType);
                return items;
            }
        }

        public IEnumerable<T> QueryMultiple<T, TC>(string query, Func<T, TC, T> mapping, string splitOn, CommandType commandType) where T : class where TC : class
        {
            using (var conn = DbFactory.CreateConnection())
            {
                var items = conn.Query<T, TC, T>(query,
                    mapping,
                    splitOn: splitOn,
                    commandType: commandType);
                return items;
            }
        }

        public IEnumerable<T> Query<T>(string query, dynamic param, CommandType commandType) where T : class
        {
            using(var conn = DbFactory.CreateConnection())
            {
                var items = SqlMapper.Query<T>(conn, query, param, commandType: commandType);
                return items;
            }
        }

        public int Execute(string query, dynamic param, CommandType commandType)
        {
            using(var conn = DbFactory.CreateConnection())
            {
                var r = SqlMapper.Execute(conn, sql: query, param: param, commandType: commandType);
                return r;
            }
        }
    }
}