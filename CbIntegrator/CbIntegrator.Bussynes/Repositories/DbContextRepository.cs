using CbIntegrator.Bussynes.Models;
using CbIntegrator.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("CbIntegrator.UI")]

namespace CbIntegrator.Bussynes.Repositories
{
	public class DbContextUserRepository : IUsersRepository
	{
		public DbContextUserRepository()
		{

		}

		internal ICollection<int> GetPages()
		{
			const int _pageSize = 15;
			var count = GetUsersCount();
			var totalPages = count / _pageSize;
			if (count % _pageSize != 0)
			{
				totalPages += 1;
			}
			totalPages = 100;
			var list = new List<int>();
			for (var i = 0; i < totalPages; i++)
			{
				list.Add(i + 1);
			}
			return list;
		}

		public ICollection<User> GetUsers(int page, int pageSize)
		{
			using var context = new CbIntegratorDbContextFactory().CreateDbContext(null);

			var sort = "Name";

			return context.Users
				.Skip(page*pageSize)
				.Take(pageSize)
				.OrderBy(x => context.Entry<UsersTable>(x).Properties.First(x => x.Metadata.Name == sort))
				.Select(x => new User
				{
					Login= x.Login,
					Password = x.Password
				})
				.ToList();
		}

		public int GetUsersCount()
		{
			using var context = new CbIntegratorDbContextFactory().CreateDbContext(null);
			return context.Users.Count();
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
