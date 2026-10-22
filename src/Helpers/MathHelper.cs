namespace Helpers;

public static class MathHelper
{
    public static int Factorial(int n) => n <= 1 ? 1 : n * Factorial(n - 1);

    public static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (var i = 2; i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }
}
