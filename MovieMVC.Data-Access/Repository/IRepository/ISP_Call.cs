using Dapper;
using System;
using System.Collections.Generic;

namespace MovieMVC.Data_Access.Repository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        T Single<T>(String procedurename, DynamicParameters param = null);

        void Execute(string procedureName, DynamicParameters param = null);

        T OneRecord<T>(string procedureName, DynamicParameters param = null);

        IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null);

        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null);


    }
}
