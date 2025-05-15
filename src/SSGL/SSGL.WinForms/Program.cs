using Common.Contracts.Interfaces.IRepositories;
using Common.Repository;
using DevExpress.AIIntegration;
using LSCore.DependencyInjection;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel.Connectors.InMemory;
using OpenAI;
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
			throw new Exception("Broken app.");
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

			#region Embedding

			var model = builder.Configuration["EMBEDDING_MODEL"];
			var key = builder.Configuration["OPEN_AI_KEY"];
			var embeddingGenerator = new OpenAIClient(key)
				.GetEmbeddingClient(model)
				.AsIEmbeddingGenerator();
			var vectorStore = new InMemoryVectorStore();
			builder.Services.AddSingleton<IEmbeddingGenerator>(embeddingGenerator);
			//var container = AIExtensionsContainerDesktop.Default;
			//container.AddEmbeddingGenerator(embeddingGenerator);
			#endregion
			return builder.Build();
		}
	}
}
