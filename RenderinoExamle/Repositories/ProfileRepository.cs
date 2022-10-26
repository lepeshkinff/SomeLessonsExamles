namespace Repositories
{
	public class ProfileRepository : IProfileRepository
	{
		public IList<Proffile> GetProffiles()
		{
			return new List<Proffile> { new Proffile() };
		}
	}
}