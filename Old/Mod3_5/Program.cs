using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 5 - Игра "Угадай число"


            Random rand = new Random();

            Console.WriteLine("Игра - 'Угадай число'. Какое максимальное число можно загадать?: "); int max = int.Parse(Console.ReadLine());

            int secret = rand.Next(1, max + 1);

            while (true)
            {
                Console.WriteLine("Введите число: "); string w = Console.ReadLine();
                if (w == "") { Console.WriteLine("Загаданное число было равно {0}", secret); break; } // Если пользователь ничего не ввел, игра заканчивается

                int wNum;

                if (int.TryParse(w, out wNum))
                {
                    if (wNum < secret) Console.WriteLine("Введенное число МЕНЬШЕ загаданного!");
                    if (wNum > secret) Console.WriteLine("Ввуденное число БОЛЬШЕ загаданного!");
                    if (wNum == secret) { Console.WriteLine("Вы УГАДАЛИ!"); break; }
                }
            }
            Console.ReadKey();
        }
    }
}
