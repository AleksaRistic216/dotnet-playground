using Repository;

var builder = WebApplication.CreateBuilder(args);
builder
	.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
	.AddEnvironmentVariables();
builder.Services.AddSingleton<IConfigurationRoot>(builder.Configuration);
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<LDSSMDbContext>();

var app = builder.Build();
app.Run();
