using CbIntegrator.Bussynes.Models;

namespace CbIntegrator.Bussynes.Repositories
{
	public class DummyIUsersRepository : IUsersRepository
	{
		public User GetUser(string login, string password)
		{
			return new User();
		}

		public ICollection<User> GetUsers(int page, int pageSize)
		{
			throw new NotImplementedException();
		}

		public int GetUsersCount()
		{
			return 10;
		}

		public User Register(string login, string password)
		{
			return new User();
		}
	}

}