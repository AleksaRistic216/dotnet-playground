namespace Helpers;

public static class StringHelper
{
    public static string Reverse(string input)
    {
        var chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    public static bool IsPalindrome(string input) =>
        input.Equals(Reverse(input), StringComparison.OrdinalIgnoreCase);
}
