using CbIntegrator.Bussynes.Exceptions;
using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Options;
using System.Data.Common;
using System.Data.SqlClient;

namespace CbIntegrator.Bussynes.Repositories
{
	public class UsersRepository : DbConnector, IUsersRepository
	{
		public UsersRepository(DbOptions configuration) : base(configuration)
		{
		}

		/// <inheritdoc/>
		public User GetUser(string login, string password)
		{
			var user = Execute(c => GetUserInternal(c, login, password));
			return user;
		}

		public List<User> GetUsers()
		{
			return GetList<User>(
				"select login, password from users",
				null,
				reader => new User
				{
					Login = reader.GetString(0),
					Password = reader.GetString(1)
				});
		}

		public User Register(string login, string password)
		{
			var user = Execute(c => RegisterInternal(c, login, password));
			return user;
		}

		private User RegisterInternal(DbConnection sqlConnection, string login, string password)
		{
			using var cmd = new SqlCommand(@$"
					insert into users(id, name, login, password)
					value(@id, '', @login, @password)",
					  (SqlConnection)sqlConnection);

			cmd.Parameters.AddWithValue("id", Guid.NewGuid());
			cmd.Parameters.AddWithValue("login", login);
			cmd.Parameters.AddWithValue("password", password);

			cmd.ExecuteNonQuery();

			return GetUserInternal(sqlConnection, login, password);
		}

		private User GetUserInternal(DbConnection sqlConnection, string login, string password)
		{
			using var cmd = new SqlCommand(@$"
					select 
						login, password
					from 
						users 
					where 
						login = @login and 
						password = @password",
					  (SqlConnection)sqlConnection);

			cmd.Parameters.AddWithValue("login", login);
			cmd.Parameters.AddWithValue("password", password);

			using var reader = cmd.ExecuteReader();

			if (!reader.Read())
			{
				throw new UserNotFoundException();
			}

			return new User
			{
				Login = reader.GetString(0),
				Password = reader.GetString(1)
			};
		}
	}

}