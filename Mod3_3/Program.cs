using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 3 - Определение простого числа


            Console.WriteLine("Определение простого числа. Чтобы выйти, введите q");

            while (true) // Пользователь может проверять множество чисел в одном цикле.
            {
                Console.Write("\nВведите число: "); string rl = Console.ReadLine();

                if (rl == "q" || rl == "Q") break; // Если пользователь ввел команду "ВЫЙТИ", то в начале итерации цикл прерывается

                int num1;

                if (int.TryParse(rl, out num1)) // Проверка того, что пользователь ввел число, а не строку
                {
                    if (num1 == 1) { Console.WriteLine("Единица - простое число!"); continue; } // Если введена 1, цикл сразу завершается

                    int div = 2; // Делимое сразу равно 2, так как при делении любого числа на 1, остаток от деления == 0. => алгоритм будет неправильным

                    while (div != num1 + 1) // Цикл работает, пока делимое != введенному числу (число простое), либо пока остаток от деления != 0 (число !простое)
                    {
                        if (div == num1) { Console.WriteLine("Число простое!"); break; }

                        if (num1 % div == 0 && div != num1) { Console.WriteLine("Число не является простым."); break; }

                        div++;
                    }
                }
                else Console.WriteLine("Неверная комбинация!");
            }
            Console.ReadKey();
        }
    }
}
