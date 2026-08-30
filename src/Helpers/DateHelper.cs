namespace Helpers;

public class DateHelper
{
    public static int DaysUntil(DateTime target) =>
        (target.Date - DateTime.Today).Days;

    public static string FormatRelative(DateTime date)
    {
        var diff = DateTime.Now - date;
        return diff.TotalHours switch
        {
            < 1 => "just now",
            < 24 => $"{(int)diff.TotalHours} hours ago",
            _ => $"{(int)diff.TotalDays} days ago"
        };
    }
}
