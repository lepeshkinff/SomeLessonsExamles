using CbIntegrator.Bussynes.Models;

namespace CbIntegrator.Bussynes.Repositories
{
    public interface IUsersRepository
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <exception cref="UserNotFoundException">Если пользователь не авторизован ил не найден</exception>
		/// <returns></returns>
		User GetUser(string login, string password);
		  User Register(string login, string password);
	}
}