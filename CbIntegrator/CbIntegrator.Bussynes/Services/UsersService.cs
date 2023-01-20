using CbIntegrator.Bussynes.Exceptions;
using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Repositories;

namespace CbIntegrator.Bussynes.Services
{
	public class UsersService : IUsersService
	{
		private readonly IApplicationContext applicationContext;
		private readonly IUsersRepository repository;

		public UsersService(IApplicationContext applicationContext, IUsersRepository repository)
		{
			this.applicationContext = applicationContext;
			this.repository = repository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		
		/// <returns></returns>
		public User? Authorize(string username, string password)
		{
			try
			{
				var user = repository.GetUser(username, password);
				applicationContext.StartSession();
				return user;
			}
			catch (UserNotFoundException)
			{
				return null;
			}
		}

		public (User? user, ErrorInfo? error) Register(string username, string password)
		{
			try
			{
				if(password is not { Length: > 6 } x || !x.Contains("!"))
				{
					throw new ServiceException("");
				}

				applicationContext.StartSession();
				return (repository.Register(username, password), null);
			}
			catch (UserNotFoundException)
			{
				return (null, new ErrorInfo());
			}
		}
	}
}
