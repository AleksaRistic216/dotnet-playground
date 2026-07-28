using DevExpress.Images;
using Microsoft.Extensions.Hosting;

namespace RibbonForm.WinForms {
    internal static class Program {
        /// <summary>
        /// </summary>
        [STAThread]
        static void Main() {
            var host = BuildHost();
            ApplicationConfiguration.Initialize();
            Application.Run(host.Services.GetRequiredService<Form1>());
        }

        private static IHost BuildHost() {
            var builder = Host.CreateApplicationBuilder();
            builder.Services.AddTransient<Form1>();
            builder.Configuration.AddJsonFile(
                "appsettings.json",
                optional: false,
                reloadOnChange: true
            );
            builder.Services.AddSingleton<IConfigurationRoot>(builder.Configuration);
            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<CommonDbContext>();
            builder.AddLSCoreDependencyInjection(
                "LDSSM",
                (opt) => {
                    opt.Scan.SetShouldScanAssemblyPredicate(
                        (a) => a.FullName != null && a.FullName.StartsWith("Common")
                    );
                }
            );
            return builder.Build();
        }
    }
}