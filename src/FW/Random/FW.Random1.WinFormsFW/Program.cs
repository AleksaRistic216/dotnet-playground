using FW.Random1.WinFormsFW.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;

namespace FW.Random1.WinFormsFW {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            Application.Run(new AccordionShellForm(host.Services));
        }

        static IHostBuilder CreateHostBuilder() {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<Views.DataGridView>();
                    services.AddSingleton<ICommonDataService>(new DataService());
                });
            return builder;
        }
    }
}