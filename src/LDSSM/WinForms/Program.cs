using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Repository;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace WinForms
{
	internal static class Program
	{
		private static IServiceProvider serviceProvider;

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			serviceProvider = serviceCollection.BuildServiceProvider();
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(serviceProvider.GetRequiredService<Form1>());
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			// Register forms
			services.AddTransient<Form1>();
			var configurationManager = new ConfigurationManager();
			configurationManager.AddJsonFile(
				"appsettings.json",
				optional: false,
				reloadOnChange: true
			);
			services.AddSingleton<IConfigurationRoot>(configurationManager);
			services.AddEntityFrameworkNpgsql().AddDbContext<LDSSMDbContext>();
		}
	}
}
