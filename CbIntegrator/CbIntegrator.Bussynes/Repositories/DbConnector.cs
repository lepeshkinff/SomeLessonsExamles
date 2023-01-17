using CbIntegrator.Bussynes.Exceptions;
using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Options;
using System.Data;
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

      protected List<T> GetList<T>(
         string query, 
         SqlParameter[]? parameters, 
         Func<IDataReader, T> read)
      {
			using var connection = GetDbConnection();
			using var cmd = new SqlCommand(query, (SqlConnection)connection);

         if(parameters is { Length: >0 }) 
         { 
            foreach(var param in parameters)
            {
					cmd.Parameters.Add(param);
				}
         }
			
			using var reader = cmd.ExecuteReader();

         var result = new List<T>();
         while(reader.Read())
         {
				result.Add(read(reader));

			}

         return result;
		}
    }
}