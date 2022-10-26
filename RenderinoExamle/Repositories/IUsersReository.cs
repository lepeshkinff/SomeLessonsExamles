namespace Repositories
{
	public interface IUsersReository
	{
		IList<User> GetUsers();
	}

	public interface IProfileRepository
	{
		IList<Proffile> GetProffiles();
	}
}