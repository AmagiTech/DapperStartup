using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.Services
{
    public interface IAdventureWorksDb
    {
        bool Delete<T>(T entity) where T : class;
        bool DeleteAll<T>() where T : class;
        int Execute(string sql, CommandType? commandType = null, object param = null);
        int Execute(string sql, CommandType? commandType = null, params SqlParameter[] parameters);
        int Execute(string sql, object param);
        int Execute(string sql, params SqlParameter[] parameters);
        IDataReader ExecuteReader(string sql, CommandType? commandType = null, object param = null);
        IDataReader ExecuteReader(string sql, CommandType? commandType = null, params SqlParameter[] parameters);
        IDataReader ExecuteReader(string sql, object param = null);
        IDataReader ExecuteReader(string sql, params SqlParameter[] parameters);
        void ExecuteReader(string sql, Action<IDataReader> action, CommandType? commandType = null, object param = null);
        void ExecuteReader(string sql, Action<IDataReader> action, CommandType? commandType = null, params SqlParameter[] parameters);
        void ExecuteReader(string sql, Action<IDataReader> action, object param = null);
        void ExecuteReader(string sql, Action<IDataReader> action, params SqlParameter[] parameters);
        T ExecuteScalar<T>(string sql, CommandType? commandType = null, object param = null);
        T ExecuteScalar<T>(string sql, CommandType? commandType = null, params SqlParameter[] parameters);
        T ExecuteScalar<T>(string sql, object param = null);
        T ExecuteScalar<T>(string sql, params SqlParameter[] parameters);
        IEnumerable<T> GetAll<T>() where T : class;
        T GetById<T>(Guid id) where T : class;
        T GetById<T>(int id) where T : class;
        T GetById<T>(long id) where T : class;
        long Insert<T>(T entity) where T : class;
        IEnumerable<T> Query<T>(string sql, object param = null) where T : class;
        IEnumerable<T> Query<T>(string sql, CommandType? commandType, object param = null) where T : class;
        IEnumerable<T> Query<T>(string sql, CommandType? commandType, params SqlParameter[] parameters) where T : class;
        IEnumerable<T> Query<T>(string sql, params SqlParameter[] parameters) where T : class;
        T QueryFirstOrDefault<T>(string sql, object param = null) where T : class;
        T QueryFirstOrDefault<T>(string sql, CommandType? commandType, object param = null) where T : class;
        T QueryFirstOrDefault<T>(string sql, CommandType? commandType, params SqlParameter[] parameters) where T : class;
        T QueryFirstOrDefault<T>(string sql, params SqlParameter[] parameters) where T : class;
        T QuerySingleOrDefault<T>(string sql, object param = null) where T : class;
        T QuerySingleOrDefault<T>(string sql, CommandType? commandType, object param = null) where T : class;
        T QuerySingleOrDefault<T>(string sql, CommandType? commandType, params SqlParameter[] parameters) where T : class;
        T QuerySingleOrDefault<T>(string sql, params SqlParameter[] parameters) where T : class;
        bool Update<T>(T entity) where T : class;
    }
}