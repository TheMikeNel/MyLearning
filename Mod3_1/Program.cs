using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1 - Четность / нечетность чисел


            Console.Write("Определение четности / нечетности числа\nВведите число: "); int num = int.Parse(Console.ReadLine());
            Console.Write(num % 2 == 0 ? "\nВведенное число - четное" : "\nВведенное число - нечетное");
            Console.ReadKey();
        }
    }
}
