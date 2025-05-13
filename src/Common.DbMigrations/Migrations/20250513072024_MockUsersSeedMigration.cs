using Common.Contracts.Constants;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.DbMigrations.Migrations
{
	/// <inheritdoc />
	public partial class MockUsersSeedMigration : Migration
	{
		static string[] _upScripts = new string[]
		{
			Path.Combine(MigrationsConstants.UpSeeds, "002_MockUsersSeed.sql"),
		};

		static string[] _downScripts = new string[]
		{
			Path.Combine(MigrationsConstants.DownSeeds, "002_MockUsersSeed.sql"),
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
