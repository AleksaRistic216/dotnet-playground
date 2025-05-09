namespace Contracts.Constants;

public static class MigrationsConstants
{
	public static readonly string SeedsRoot = Path.Combine(Environment.CurrentDirectory, "Seeds");
	public static readonly string UpSeeds = Path.Combine(SeedsRoot, "Up");
	public static readonly string DownSeeds = Path.Combine(SeedsRoot, "Down");
}
