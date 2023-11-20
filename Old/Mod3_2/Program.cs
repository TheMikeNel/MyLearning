using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 2 - Игра "21"


            Console.WriteLine("Приветствуем вас в игре 21!");
            Console.ReadKey();

            Console.Write("Сколько карт у вас в руке?: "); int cardCount = int.Parse(Console.ReadLine());

            Console.WriteLine("В игре есть следующие номиналы:\nЧисловые = 1...9\nВалет = J\nДама = Q\nКороль = K\nТуз = T");
            int summ = 0; // Переменная для общей суммы номиналов всех карт

            for (int i = 1; i < cardCount + 1; i++)
            {
                Console.Write($"\nВведите номинал карты {i}: "); string nominal = Console.ReadLine();

                int add = 0; // Переменная текущего значения слагаемого

                if (int.TryParse(nominal, out add)) // Если номинал карты - число, а не картинка
                {
                    if (add >= 1 && add <= 9) summ += add; // Если номинал карты находится в нужном диапазоне (от 1 до 9)

                    else // Иначе введенное число недействительно
                    {
                        Console.WriteLine("\nВведенное значение недействительно!");

                        i--; // Перезабивается правильное значение на ту же карту, т.е. номер карты должен уменьшиться и быть действующим, независимо от итераций цикла
                    }
                }

                else // Если введенное пользователем значение карты не является числом
                {
                    switch (nominal)
                    {
                        case "J":
                            summ += 10; break;
                        case "D":
                            summ += 10; break;
                        case "K":
                            summ += 10; break;
                        case "T":
                            summ += 10; break;
                        default: Console.WriteLine("\nВведенное значение недействительно!"); i--; break;
                    }
                }
            }
            Console.WriteLine("\nВ сумме, вы набрали: {0} очков!", summ);
            Console.ReadKey();
        }
    }
}
