using Identity.Application.Configurations.Database;
using Identity.Domain.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Identity.Infrastructure.Configurations
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly IConfiguration _configuration;
        private IDbConnection _connection;
        private bool _disposed = false;
        private ConnectionStringType _connectionStringType;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                if (_connectionStringType == ConnectionStringType.PostgreSQLConnection)
                {
                    _connection = new SqlConnection(_configuration.GetConnectionString("PostgreSQLConnection"));
                }
                else
                {
                    _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                }

                _connection.Open();
            }

            return _connection;
        }

        public IDbConnection GetNewConnection()
        {
            if (_connectionStringType == ConnectionStringType.DefaultConnection)
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }

            if (_connectionStringType == ConnectionStringType.PostgreSQLConnection)
            {
                return new SqlConnection(_configuration.GetConnectionString("PostgreSQLConnection"));
            }

            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        /// <summary>
        /// Sets connectionString type.
        /// </summary>
        /// <param name="connectionStringType">The connectionStringType.</param>
        public void SetConnectionStringType(ConnectionStringType connectionStringType)
        {
            _connectionStringType = connectionStringType;
        }

        /// <summary>
        /// Document: https://rules.sonarsource.com/csharp/RSPEC-3881
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing && _connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }

            _disposed = true;
        }
    }
}