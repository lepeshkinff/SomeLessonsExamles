using CbIntegrator.Bussynes.Options;
using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Engine;
using CbIntegrator.UI.Froms;
using Microsoft.Extensions.Configuration;

namespace CbIntegrator.UI
{
	internal static class Program
	{
		static MainFormFactory factory;
		static ApplicationContextCb context;

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

			factory = new MainFormFactory();
			context = new ApplicationContextCb(factory);
			factory.Context = context;

			var config = ReadConfiguration();
			var dbOptions = new DbOptions { ConnectionString = config.GetConnectionString("db")! };
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			var login = new LoginForm(factory, new UsersService(context, new DummyIUsersRepository()));
			context.MainForm = login;
			Application.Run(context);
		}

		private static IConfiguration ReadConfiguration()
		{
			var config = new ConfigurationBuilder()
					 .AddJsonFile("appsettings.json", false)
					 .Build();

			return config;
		}
	}
}