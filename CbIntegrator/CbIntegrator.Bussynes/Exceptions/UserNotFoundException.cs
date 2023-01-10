namespace CbIntegrator.Bussynes.Exceptions
{
	/// <summary>
	/// Пользователь не найден
	/// </summary>
	public class UserNotFoundException : ServiceException
	{
		public UserNotFoundException():base("User not found")
		{

		}
	}
}
