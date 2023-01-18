using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CbIntegrator.DbContexts
{
	[Table("Currencies")]
	public class Currency
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}