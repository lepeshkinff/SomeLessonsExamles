using Microsoft.EntityFrameworkCore;

namespace CbIntegrator.DbContexts
{
	public class CbIntegratorDbContext : DbContext
	{
		public DbSet<UsersTable> Users { get; set; }

		public CbIntegratorDbContext(DbContextOptions<CbIntegratorDbContext> connection) : base(connection) { }
		
	}
}