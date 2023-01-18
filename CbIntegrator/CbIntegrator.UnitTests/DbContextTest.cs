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

			var usersTask = dbContext.Users.ToListAsync();

			var users = await usersTask;

			var user = new UsersTable { Login = Guid.NewGuid().ToString(), Name = Guid.NewGuid().ToString(), Password = "123" };
			dbContext.Users.Add(user);

			await dbContext.SaveChangesAsync();

			Assert.True(user.Id != 0);

			user.Name = "SomeNewName";

			await dbContext.SaveChangesAsync();

			dbContext.Users.Remove(user);

			await dbContext.SaveChangesAsync();

			users = dbContext.Users.ToList();

			user = await dbContext
				.Users
				.FirstOrDefaultAsync(x => x.Id == user.Id);

			Assert.NotNull(user);

			var others = dbContext
				.Users
				.Where(x => x.Name.StartsWith("1"))
				.ToList();


		}
	}
}
