using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WebApplication2.Services
{
    public class AdventureWorksDb : IAdventureWorksDb
    {
        private readonly IConfiguration configuration;
        public AdventureWorksDb(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private IDbConnection GetConnection()
            => new SqlConnection(configuration.GetConnectionString("AdventureWorksDb"));

        private DynamicParameters GetDynamicParameters(params SqlParameter[] parameters)
        {
            var dynamicParameters = new DynamicParameters(new { });
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    dynamicParameters.Add(parameter.ParameterName, parameter.Value);
                }
            }
            return dynamicParameters;
        }

        public bool Delete<T>(T entity) where T : class
        {
            using (var db = GetConnection())
            {
                return db.Delete<T>(entity);
            }
        }

        public bool DeleteAll<T>() where T : class
        {
            using (var db = GetConnection())
            {
                return db.DeleteAll<T>();
            }
        }

        public T GetById<T>(Guid id) where T : class
        {
            using (var db = GetConnection())
            {
                return db.Get<T>(id);
            }
        }

        public T GetById<T>(int id) where T : class
        {
            using (var db = GetConnection())
            {
                return db.Get<T>(id);
            }
        }

        public T GetById<T>(long id) where T : class
        {
            using (var db = GetConnection())
            {
                return db.Get<T>(id);
            }
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            using (var db = GetConnection())
            {
                return db.GetAll<T>();
            }
        }

        public long Insert<T>(T entity) where T : class
        {
            using (var db = GetConnection())
            {
                return db.Insert(entity);
            }
        }

        public bool Update<T>(T entity) where T : class
        {
            using (var db = GetConnection())
            {
                return db.Update(entity);
            }
        }

        public IEnumerable<T> Query<T>(string sql, CommandType? commandType, object param = null) where T : class
        {
            using (var db = GetConnection())
            {
                return db.Query<T>(sql, param: param, commandType: commandType);
            }
        }
        public IEnumerable<T> Query<T>(string sql, CommandType? commandType, params SqlParameter[] parameters) where T : class => Query<T>(sql, commandType, GetDynamicParameters(parameters));

        public IEnumerable<T> Query<T>(string sql, object param = null) where T : class => Query<T>(sql, commandType: null, param: param);
        public IEnumerable<T> Query<T>(string sql, params SqlParameter[] parameters) where T : class => Query<T>(sql, commandType: null, param: GetDynamicParameters(parameters));


        public T QueryFirstOrDefault<T>(string sql, CommandType? commandType, object param = null) where T : class
        {
            using (var db = GetConnection())
            {
                return db.QueryFirstOrDefault<T>(sql, param: param, commandType: commandType);
            }
        }

        public T QueryFirstOrDefault<T>(string sql, CommandType? commandType, params SqlParameter[] parameters) where T : class => QueryFirstOrDefault<T>(sql, commandType: commandType, param: GetDynamicParameters(parameters));
        public T QueryFirstOrDefault<T>(string sql, object param = null) where T : class => QueryFirstOrDefault<T>(sql, commandType: null, param: param);
        public T QueryFirstOrDefault<T>(string sql, params SqlParameter[] parameters) where T : class => QueryFirstOrDefault<T>(sql, commandType: null, param: GetDynamicParameters(parameters));


        public T QuerySingleOrDefault<T>(string sql, CommandType? commandType, object param = null) where T : class
        {
            using (var db = GetConnection())
            {
                return db.QuerySingleOrDefault<T>(sql, param: param, commandType: commandType);
            }
        }
        public T QuerySingleOrDefault<T>(string sql, CommandType? commandType, params SqlParameter[] parameters) where T : class => QuerySingleOrDefault<T>(sql, commandType: commandType, param: GetDynamicParameters(parameters));
        public T QuerySingleOrDefault<T>(string sql, object param = null) where T : class => QuerySingleOrDefault<T>(sql, commandType: null, param: param);
        public T QuerySingleOrDefault<T>(string sql, params SqlParameter[] parameters) where T : class => QuerySingleOrDefault<T>(sql, commandType: null, param: GetDynamicParameters(parameters));

        public int Execute(string sql, CommandType? commandType = null, object param = null)
        {
            using (var db = GetConnection())
            {
                return db.Execute(sql, param: param, commandType: commandType);
            }
        }
        public int Execute(string sql, CommandType? commandType = null, params SqlParameter[] parameters) => Execute(sql, commandType, GetDynamicParameters(parameters));
        public int Execute(string sql, object param) => Execute(sql, commandType: null, param: param);
        public int Execute(string sql, params SqlParameter[] parameters) => Execute(sql, commandType: null, param: GetDynamicParameters(parameters));

        public T ExecuteScalar<T>(string sql, CommandType? commandType = null, object param = null)
        {
            using (var db = GetConnection())
            {
                return db.ExecuteScalar<T>(sql, param: param, commandType: commandType);
            }
        }
        public T ExecuteScalar<T>(string sql, CommandType? commandType = null, params SqlParameter[] parameters) => ExecuteScalar<T>(sql, commandType, GetDynamicParameters(parameters));
        public T ExecuteScalar<T>(string sql, object param = null) => ExecuteScalar<T>(sql, commandType: null, param: param);
        public T ExecuteScalar<T>(string sql, params SqlParameter[] parameters) => ExecuteScalar<T>(sql, commandType: null, param: GetDynamicParameters(parameters));

        public IDataReader ExecuteReader(string sql, CommandType? commandType = null, object param = null)
        {
            using (var db = GetConnection())
            {
                return db.ExecuteReader(sql, commandType: commandType, param: param);
            }
        }
        public IDataReader ExecuteReader(string sql, CommandType? commandType = null, params SqlParameter[] parameters) => ExecuteReader(sql, commandType: commandType, param: GetDynamicParameters(parameters));
        public IDataReader ExecuteReader(string sql, object param = null) => ExecuteReader(sql, commandType: null, param: param);
        public IDataReader ExecuteReader(string sql, params SqlParameter[] parameters) => ExecuteReader(sql, commandType: null, param: GetDynamicParameters(parameters));

        public void ExecuteReader(string sql, Action<IDataReader> action, CommandType? commandType = null, object param = null)
        {
            using (var db = GetConnection())
            {
                var _reader = db.ExecuteReader(sql, commandType: commandType, param: param);
                action.Invoke(_reader);
            }
        }
        public void ExecuteReader(string sql, Action<IDataReader> action, CommandType? commandType = null, params SqlParameter[] parameters)
            => ExecuteReader(sql, action, commandType, GetDynamicParameters(parameters));
        public void ExecuteReader(string sql, Action<IDataReader> action, object param = null)
        => ExecuteReader(sql, action, null, param);
        public void ExecuteReader(string sql, Action<IDataReader> action, params SqlParameter[] parameters)
        => ExecuteReader(sql, action, null, GetDynamicParameters(parameters));
    }
}
