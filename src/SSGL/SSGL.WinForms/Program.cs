using Common.Contracts.Interfaces.IRepositories;
using Common.Repository;
using LSCore.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SSGL.Repository;

namespace SSGL.WinForms
{
	internal static class Program
	{
		private static bool _useDatabase = false;

		/// <summary>
		/// </summary>
		[STAThread]
		static void Main()
		{
			var host = BuildHost();
			ApplicationConfiguration.Initialize();
			Application.Run(host.Services.GetRequiredService<Form1>());
		}

		private static IHost BuildHost()
		{
			var builder = Host.CreateApplicationBuilder();
			builder.Services.AddTransient<Form1>();
			builder.Services.AddSingleton<IConfigurationRoot>(builder.Configuration);
			builder.Configuration.AddJsonFile(
				"appsettings.json",
				optional: true,
				reloadOnChange: true
			);
			if (builder.Configuration["USE_DATABASE"] is "true")
			{
				builder.Services.AddEntityFrameworkNpgsql().AddDbContext<CommonDbContext>();
				builder.AddLSCoreDependencyInjection(
					"SSGL",
					(opt) =>
					{
						opt.Scan.SetShouldScanAssemblyPredicate(
							(a) => a.FullName != null && a.FullName.StartsWith("Common")
						);
					}
				);
			}
			else
			{
				builder.Services.AddTransient<IUserRepository, UserMockRepository>();
			}
			return builder.Build();
		}
	}
}
