using Common.Contracts.Entities;
using Common.Repository.EntityMaps;
using LSCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Common.Repository;

public class CommonDbContext(
	DbContextOptions<CommonDbContext> options,
	IConfigurationRoot configuration
) : LSCoreDbContext<CommonDbContext>(options)
{
	public DbSet<UserEntity> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseNpgsql(
			$"Server={configuration["POSTGRES_HOST"]};Port={configuration["POSTGRES_PORT"]};Userid={configuration["POSTGRES_USER"]};Password={configuration["POSTGRES_PASSWORD"]};Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;Database={configuration["POSTGRES_DATABASE"]};Include Error Detail=true;",
			(action) =>
			{
				action.MigrationsAssembly("Common.DbMigrations");
			}
		);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<UserEntity>().AddMap(new UserEntityMap());
	}
}
