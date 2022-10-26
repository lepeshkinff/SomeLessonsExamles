namespace Repositories
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

	}

	public class UserInfo
	{
		public User User { get; set; }
		public Proffile Profile { get; set; }
}

public class Proffile
{

}
}