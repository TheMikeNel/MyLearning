using System.Text;

namespace MetanitTrainings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Recursive.Factorial(4));

            //int[] array1 = [1, 0, 0];
            //int[] array2 = [1, 1, 0];
            //int[][] arrayIsland = [array1, array2, array2];
            //Console.WriteLine(LocalFunctions.CompareArrays(array1, array2));
            //Console.WriteLine(Solution.IslandPerimeter(arrayIsland));

            //Kiwi kivi = new Kiwi();
            //IAnimal<Bird> iBird = kivi;
            //IAnimal<Animal> animal = kivi;

            //int id = 1;
            //StringBuilder sb = new StringBuilder(20, 20);
            //sb.Append(id);
            //Console.WriteLine($"SB before: {sb} Length{sb.Length}; Capacity{sb.Capacity}; MaxCapacity{sb.MaxCapacity}.");
            //sb.Insert(0, "0", sb.Capacity - sb.Length);
            //Console.WriteLine($"SB after: {sb} Length{sb.Length}; Capacity{sb.Capacity}; MaxCapacity{sb.MaxCapacity}.");
            //Console.ReadKey();

            //int[,] i = { { 1, 2, 3 }, { 1, 2, 2 }, { 1, 2, 2 } };
            //foreach (int x in i)
            //{
            //    Console.WriteLine(x + "\n");
            //}
            //Console.WriteLine(i.Length);

            Stack<string> strings = new Stack<string>();

            for (int i = 0; i < 10; i++)
            {
                strings.Push("string number: " + i.ToString());
            }

            List<string> strings2 = new List<string>(strings);

            foreach (string s in strings2)
            {
                Console.WriteLine(s);
            }
        }
    }
}
