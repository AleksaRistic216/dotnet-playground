using Contracts.Entities;
using LSCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.EntityMaps;

namespace Repository;

public class LDSSMDbContext(
	DbContextOptions<LDSSMDbContext> options,
	IConfigurationRoot configuration
) : LSCoreDbContext<LDSSMDbContext>(options)
{
	public DbSet<UserEntity> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseNpgsql(
			$"Server={configuration["POSTGRES_HOST"]};Port={configuration["POSTGRES_PORT"]};Userid={configuration["POSTGRES_USER"]};Password={configuration["POSTGRES_PASSWORD"]};Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;Database={configuration["POSTGRES_DATABASE"]};Include Error Detail=true;",
			(action) =>
			{
				action.MigrationsAssembly("DbMigrations");
			}
		);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<UserEntity>().AddMap(new UserEntityMap());
	}
}
