using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 4 - Меньшее число

            Console.WriteLine("Программа находит меньшее число из последовательности!");
            Console.Write("Введите величину последовательности: "); int i = int.Parse(Console.ReadLine());

            int minValue = int.MaxValue;

            for (int j = 1; j < i + 1; j++) 
            { 
                Console.Write($"\nведите число номер {j}: "); int wNum = int.Parse(Console.ReadLine());
                if (wNum < minValue) minValue = wNum;
            }
            Console.WriteLine("Минимальное число ==> " + minValue);
            Console.ReadKey();
        }
    }
}
