using CbIntegrator.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CbIntegrator.UnitTests
{
	public class DbContextTest
	{
		[Fact]
		public async Task ReadDataFromTable()
		{
			using var dbContext = new CbIntegratorDbContextFactory()
				.CreateDbContext(null);

			var users = await dbContext.Users.ToListAsync();

			users = dbContext.Users.ToList();

			var user = dbContext
				.Users
				.Where(x => x.Id == 1)
				.FirstOrDefault();

			var others = dbContext
				.Users
				.Where(x => x.Name.StartsWith("1"))
				.ToList();


		}
	}
}