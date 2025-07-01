using DevExpress.XtraEditors;
using LSCore.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace T1297240.WinForms
{
	internal static class Program
	{
		/// <summary>
		/// </summary>
		[STAThread]
		static void Main()
		{
			WindowsFormsSettings.ForceDirectXPaint();
			WindowsFormsSettings.UseAdvancedTextEdit = DevExpress.Utils.DefaultBoolean.True;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var host = BuildHost();
			ApplicationConfiguration.Initialize();
			Application.Run(host.Services.GetRequiredService<Form1>());
		}

		private static IHost BuildHost()
		{
			var builder = Host.CreateApplicationBuilder();
			builder.Services.AddTransient<Form1>();
			builder.Configuration.AddJsonFile(
				"appsettings.json",
				optional: false,
				reloadOnChange: true
			);
			builder.Services.AddSingleton<IConfigurationRoot>(builder.Configuration);
			builder.AddLSCoreDependencyInjection(
				"T1297240",
				(opt) => {
					//opt.Scan.SetShouldScanAssemblyPredicate(
					//	(a) => a.FullName != null && a.FullName.StartsWith("Common")
					//);
				}
			);
			return builder.Build();
		}
	}
}
