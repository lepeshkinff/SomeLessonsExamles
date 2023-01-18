using CbIntegrator.Console;
using CbIntegrator.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data.SqlClient;

internal partial class Program
{
	private static async Task Main(string[] args)
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

	private static void PetsExample()
	{
		var cat = new Cat();
		var pets = new Pet[] { new Cat(), new Dog() };

		foreach(var pet in pets)
		{
			PlayWithPet(pet);
		}
	}


	internal static void PlayWithPet(Pet pet)
	{
		pet.Play();
	}
}
