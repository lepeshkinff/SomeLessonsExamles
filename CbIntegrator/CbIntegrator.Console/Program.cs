using CbIntegrator.Console;
using System.Data.Common;
using System.Data.SqlClient;

internal partial class Program
{
	private static void Main(string[] args)
	{
		var service = new AuthorizationService();
		Console.WriteLine("Start");
		service.Authorize("", "");
		Console.WriteLine("Stop");
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
