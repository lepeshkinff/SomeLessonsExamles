using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CbIntegrator.DbContexts
{
	public class CbIntegratorDbContextFactory : IDesignTimeDbContextFactory<CbIntegratorDbContext>
	{
		public CbIntegratorDbContext CreateDbContext(string[] args)
		{
			var conn = new SqlConnectionStringBuilder();
			conn.DataSource = "localhost";
			conn.InitialCatalog = "CbIntegrator";
			conn.UserID = "test";
			conn.Password = "test";
			
			var optionsBuilder = new DbContextOptionsBuilder<CbIntegratorDbContext>();
			optionsBuilder
				.UseSqlServer(conn.ConnectionString);

			return new CbIntegratorDbContext(optionsBuilder.Options);
		}
	}
}