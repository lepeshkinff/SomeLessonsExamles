using CbIntegrator.Bussynes.Models;

namespace CbIntegrator.Bussynes.Repositories
{
	public class DummyIUsersRepository : IUsersRepository
	{
		public User GetUser(string login, string password)
		{
			return new User();
		}

		public User Register(string login, string password)
		{
			return new User();
		}
	}

}