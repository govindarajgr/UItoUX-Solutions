﻿using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace UItoUX.DBEngine
{
    public interface IDapperHandler
    {
        IDbConnection Connection { get; }

        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text);  // return the Single row Data table values

        Task<T> QuerySingleAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text); // return the Data table with singel row oblject  with SP 
        Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text);  // return the object values

        Task ExecuteAsync(string sql, object? parameters = null, CommandType commandType = CommandType.Text); // Insert, Update and Delete

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text);   // return the data table with more the one rows

        Task<GridReader> QueryMultipleAsync(string sql, object? parameters = null, CommandType commandType = CommandType.Text);  // return the Data Set values

        Task<IDataReader> ExecuteReaderAsync(IDbConnection connection, string sql, CommandType commandType, object? parameters = null);

        void ExecuteScript(string script);

        object ExecuteScalar(string script);
    }
    public class DapperHandler(IConfiguration configuration) : IDapperHandler
    {
        private readonly IConfiguration _configuration = configuration;

        public IDbConnection Connection
        {
            get
            {
                var sqlconnection = new SqlConnection(_configuration.GetConnectionString("ConnString"));
                return sqlconnection;
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using (Connection)
            {
                return await Connection.QueryFirstOrDefaultAsync<T>(sql, parameters, commandType: commandType);
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using (Connection)
            {
                return await Connection.QueryAsync<T>(sql, parameters, commandType: commandType, commandTimeout: 600);
            }
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {

            using (Connection)
            {
                return await Connection.QuerySingleAsync<T>(sql, parameters, commandType: commandType);
            }
        }
        public async Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {

            using (Connection)
            {
                return await Connection.ExecuteScalarAsync<T>(sql, parameters, commandType: commandType);
            }
        }
        public async Task ExecuteAsync(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using (Connection)
            {
                await Connection.ExecuteAsync(sql, parameters, commandType: commandType);
            }
        }

        public async Task<GridReader> QueryMultipleAsync(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using (Connection)
            {
                return await Connection.QueryMultipleAsync(sql, parameters, commandType: commandType, commandTimeout: 180);
            }
        }

        public async Task<IDataReader> ExecuteReaderAsync(IDbConnection connection, string sql, CommandType commandType, object? parameters = null)
        {
            return await connection.ExecuteReaderAsync(sql, parameters, commandType: commandType, commandTimeout: 180);
        }

        public void ExecuteScript(string script)
        {
            try
            {
                using (Connection)
                {
                    Connection.Open();
                    Connection.Execute(script);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public object ExecuteScalar(string script)
        {
            object? result = null;
            try
            {
                using (Connection)
                {
                    Connection.Open();
                    result = Connection.ExecuteScalar(script);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

    }

}
