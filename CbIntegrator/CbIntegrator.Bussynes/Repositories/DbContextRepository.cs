using CbIntegrator.Bussynes.Models;
using CbIntegrator.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbIntegrator.Bussynes.Repositories
{
	public class DbContextUserRepository : IUsersRepository
	{
		public DbContextUserRepository()
		{

		}
		public User GetUser(string login, string password)
		{
			using var context = new CbIntegratorDbContextFactory().CreateDbContext(null);

			var user = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
			if (user == null)
			{
				throw new Exception();
			}

			return new User
			{
				Login = user.Login,
				Password = user.Password
			};
		}

		public User Register(string login, string password)
		{
			using var context = new CbIntegratorDbContextFactory().CreateDbContext(null);

			var user = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
			if (user != null)
			{
				throw new Exception();
			}

			user = new UsersTable { Login = login, Password = password, Name = "1" };

			context.Users.Add(user);
			context.SaveChanges();

			return new User
			{
				Login = user.Login,
				Password = user.Password
			};
		}
	}
}
