using System;
using System.Collections.Generic;
using System.Data;

namespace FacadeServices.Interfaces
{
    public interface IDataProvider 
    {
        IEnumerable<T> Query<T>(string query, CommandType commandType) where T: class;
        IEnumerable<T> QueryMultiple<T, TC>(string query, Func<T, TC, T> mapping, string splitOn, CommandType commandType) where T : class
                                                                                   where TC : class ;
        int Execute(string query, dynamic param, CommandType commandType);
        IEnumerable<T> Query<T>(string query, dynamic param, CommandType commandType) where T : class;
    }
}