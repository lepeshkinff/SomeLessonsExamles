using CbIntegrator.Bussynes.Options;
using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Engine;
using CbIntegrator.UI.Froms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CbIntegrator.UnitTests")]

namespace CbIntegrator.UI
{
	internal static class Program
	{
		internal static ApplicationContextCb context;

		static IServiceProvider serviceProvider;

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			serviceProvider = CreateProvider();
			context = serviceProvider.GetRequiredService<ApplicationContextCb>();
			
			var config = ReadConfiguration();
			//var dbOptions = new DbOptions { ConnectionString = config.GetConnectionString("db")! };
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			var login = serviceProvider.GetRequiredService<LoginForm>();
			context.MainForm = login;
			Application.Run(context);
		}

		private static IServiceProvider CreateProvider()
		{
			var services = new ServiceCollection();

			services.AddSingleton<SessionBreaker>();
			services.AddSingleton<ApplicationContextCb>();
			services.AddTransient<IApplicationContext>(sp =>
			{
				return sp.GetRequiredService<ApplicationContextCb>();
			});
			
			services.AddTransient<IUsersService, UsersService>();
			services.AddTransient<IUsersRepository, DbContextUserRepository>();

			services.AddTransient<LoginForm>();
			services.AddTransient<MainForm>();
			services.AddTransient<Func<MainForm>>(sp =>
			{
				return () => sp.GetRequiredService<MainForm>();
			});
			services.AddTransient<Func<LoginForm>>(sp =>
			{
				return () => sp.GetRequiredService<LoginForm>();
			});

			return services.BuildServiceProvider();
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