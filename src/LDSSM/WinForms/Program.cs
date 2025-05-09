using System.Configuration;
using LDSSM.Repository;
using LSCore.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace LDSSM.WinForms
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
			var host = BuildHost();
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(host.Services.GetRequiredService<Form1>());
		}

		private static IHost BuildHost()
		{
			var builder = Host.CreateApplicationBuilder();
			builder.Services.AddTransient<Form1>();
			builder.Services.AddScoped<DXGridForm>();
			builder.Configuration.AddJsonFile(
				"appsettings.json",
				optional: false,
				reloadOnChange: true
			);
			builder.Services.AddSingleton<IConfigurationRoot>(builder.Configuration);
			builder.Services.AddEntityFrameworkNpgsql().AddDbContext<LDSSMDbContext>();
			builder.AddLSCoreDependencyInjection("LDSSM");
			return builder.Build();
		}
	}
}
