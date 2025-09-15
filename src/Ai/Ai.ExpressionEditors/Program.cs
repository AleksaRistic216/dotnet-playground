using Common.Repository;
using DevExpress.AIIntegration;
using DevExpress.LookAndFeel;
using LSCore.DependencyInjection;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ai.ExpressionEditors {
    internal static class Program {
        /// <summary>
        /// </summary>
        [STAThread]
        static void Main() {
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXI);
            var host = BuildHost();
            ApplicationConfiguration.Initialize();
            IConfigurationRoot configuration = host.Services.GetRequiredService<IConfigurationRoot>();
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
                "Ai",
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