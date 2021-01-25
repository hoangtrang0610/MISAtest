using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseReponsitory<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        #region DECLARE
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        protected IDbConnection _dbConnection = null;
        protected string _tableName;
        string _paramName = string.Empty;
        #endregion
        public BaseReponsitory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionStrings");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
            _paramName = $"{_tableName}Id";
        }
        public int Add(TEntity entity)
        {
            var rowAffects = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var parameters = MappingDbType(entity);
                    //Thực hiện thêm 1 bản ghi
                    rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", parameters, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                }

            }
            //trả về số bản ghi thêm mới được
            return rowAffects;

        }

        public int Delete(Guid emloyeeId)
        {
            var res = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                res = _dbConnection.Execute($"DELETE FROM {_tableName} WHERE {_tableName}Id = '{emloyeeId.ToString()}'");
                transaction.Commit();
            }
            return res;
        }

        public IEnumerable<TEntity> GetEntities()
        {
            //Kết nối tới CSDL
            //Khởi tạo các commandText:
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.Text);
            //Trả về dữ liệu
            return entities;
        }

        public IEnumerable<TEntity> GetEntities(string storeName)
        {
            //Kết nối tới CSDL
            //Khởi tạo các commandText:
            var entities = _dbConnection.Query<TEntity>("storeName", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return entities;
        }

        public TEntity GetEntityByCode(string customerCode)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityById(Guid entityId)
        {
            DynamicParameters id = new DynamicParameters();
            id.Add(_paramName, entityId.ToString());
            var res = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}ById", id, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        public int Update(TEntity entity)
        {
            //Khởi tạo kết nối với Db:
            var parameters = MappingDbType(entity);
            //Thực thi commandText
            var rowAffects = _dbConnection.Execute($"Proc_Update{_tableName}", parameters, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }
        /// <summary>
        /// map kiểu dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DynamicParameters MappingDbType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();// lấy tất cả properties của customer
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    var dbValue = ((bool)propertyValue == true ? 1 : 0);
                    parameters.Add($"@{propertyName}", propertyValue, DbType.Int32);

                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }
            return parameters;
        }

        public int GetEntityBySpces(TEntity entity, System.Reflection.PropertyInfo propertyName)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.AddNew)
                query = $"select *from {_tableName} where {propertyName} = '{propertyValue}'";
            else if (entity.EntityState == EntityState.Update)
                query = $"select *from {_tableName} where {propertyName} = '{propertyValue}' and {_tableName}Id <> '{keyValue}'";
            else return null;
            var entityReturn = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }

        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Close();
            }
        }

        
        
    }
}
