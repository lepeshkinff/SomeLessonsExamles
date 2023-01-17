using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CbIntegrator.DbContexts
{
	[Table("Users")]
	public class UsersTable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		public string Password { get; set; }

		public string Login { get; set; }
	}
}