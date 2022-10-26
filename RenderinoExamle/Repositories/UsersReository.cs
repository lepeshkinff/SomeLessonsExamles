namespace Repositories
{
	public class UsersRepository : IUsersReository
	{
		private Dictionary<string, User> _dict = new Dictionary<string, User>()
		{
			["123"] = new User()
		};

		public IList<User> GetUsers()
		{
			return _dict.Values.ToList();
		}
	}
}