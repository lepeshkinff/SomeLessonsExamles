namespace Repositories
{
	public class UsersService : IUsersService
	{
		private readonly IUsersReository usersReository;
		private readonly IProfileRepository profileRepository;

		public UsersService(IUsersReository usersReository, IProfileRepository profileRepository)
		{
			this.usersReository = usersReository;
			this.profileRepository = profileRepository;
		}

		public IList<UserInfo> GetUsers(string name)
		{
			var users = usersReository.GetUsers();
			var profiles = profileRepository.GetProffiles();

			return users
				.Where(x => x.Name == name)
				.Select(x =>
				{
					return new UserInfo
					{
						User = x,
						Profile = profiles.First()
					};
				}).ToList();
		}
	}
}
