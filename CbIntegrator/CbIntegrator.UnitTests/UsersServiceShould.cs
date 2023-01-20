using CbIntegrator.Bussynes.Exceptions;
using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.Bussynes.Services;
using CbService;

namespace CbIntegrator.UnitTests
{
	public class UsersServiceShould
	{
		[Fact]
		public void Test()
		{
			var client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap12);

			var result = client.GetCursDynamic(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), "810");
		}

		[Theory]
		[InlineData(null, "1")]
		[InlineData("1", null)]
		[InlineData("1", "2")]
		public void AuthorizeUserSuccess(string login, string password)
		{
			var service = new UsersService(null, new UsersRepo());

			Assert.Throws<ServiceException>(() => service.Authorize(login, password));
		}

		class UsersRepo : IUsersRepository
		{
			public User GetUser(string login, string password)
			{
				if(login == null || password == null)
				{
					return null;
				}

				if (login == "1" || password == "2")
				{
					return new User { Login = login, Password = password };
				}

				if (login == "1" || password != "2")
				{
					throw new UserNotFoundException();
				}

				throw new Exception();
			}

			public User Register(string login, string password)
			{
				throw new NotImplementedException();
			}
		}
	}
}