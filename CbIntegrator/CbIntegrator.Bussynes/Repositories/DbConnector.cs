using CbIntegrator.Bussynes.Options;
using System.Data.Common;
using System.Data.SqlClient;

namespace CbIntegrator.Bussynes.Repositories
{
    public abstract class DbConnector
    {
        private string connectionString;
        public DbConnector(DbOptions configuration)
        {
            connectionString = configuration.ConnectionString;
        }

        protected DbConnection GetDbConnection()
        {
            return new SqlConnection(connectionString);
        }

        protected T Execute<T>(Func<DbConnection, T> action)
        {
            var connection = GetDbConnection();
            try
            {
                return action(connection);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}