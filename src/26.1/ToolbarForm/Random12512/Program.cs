using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Random12512.Infrastructure;
using System.Windows.Forms;

namespace Random12512 {
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
                    services.AddTransient<Views.EditFormView>();
                    services.AddTransient<Views.AltEditFormView>();
                    services.AddTransient<Views.TreeListView>();
                    services.AddTransient<Views.SchedulerView>();
                    services.AddTransient<Views.RichEditorView>();
                    services.AddTransient<Views.SpreadsheetView>();
                    services.AddTransient<Views.PdfViewerView>();
                    services.AddTransient<Views.PieChartView>();
                    services.AddTransient<Views.DonutChartView>();
                    services.AddTransient<Views.BarChartView>();
                    services.AddTransient<Views.StackedBarChartView>();
                    services.AddTransient<Views.AreaChartView>();
                    services.AddTransient<Views.AreaStackedChartView>();
                    services.AddTransient<Views.DiagramControlView>();
                    services.AddTransient<Views.GanttView>();
                    services.AddTransient<Views.DashboardView>();
                    services.AddTransient<Views.ReportView>();
                    services.AddSingleton<ICommonDataService>(new DataService());
                });
            return builder;
        }
    }
}