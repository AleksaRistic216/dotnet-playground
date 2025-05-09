using LDSSM.Contracts.Constants;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbMigrations.Migrations
{
	/// <inheritdoc />
	public partial class SystemUserSeedMigration : Migration
	{
		static string[] _upScripts = new string[]
		{
			Path.Combine(MigrationsConstants.UpSeeds, "001_SystemUserSeed.sql"),
		};

		static string[] _downScripts = new string[]
		{
			Path.Combine(MigrationsConstants.DownSeeds, "001_SystemUserSeed.sql"),
		};

		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			foreach (var script in _upScripts)
				migrationBuilder.Sql(File.ReadAllText(script));
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			foreach (var script in _downScripts)
				migrationBuilder.Sql(File.ReadAllText(script));
		}
	}
}
