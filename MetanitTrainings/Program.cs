namespace MetanitTrainings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Recursive.Factorial(4));

            int[] array1 = [1, 2, 3];
            int[] array2 = [1, 1, 5];
            Console.WriteLine(LocalFunctions.CompareArrays(array1, array2));
        }
    }
}
