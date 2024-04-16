namespace MetanitTrainings
{
    internal static class Recursive
    {
        public static uint Factorial(uint n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }
    }
}
