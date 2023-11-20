using System;
using System.Collections.Generic;

namespace Mod8_Collections
{
    internal class CheckRepeats
    {
        static HashSet<int> hash = new HashSet<int>();

        public static void CheckRepeatsWorking()
        {
            Console.WriteLine(">>> Проверка на повторение числовых значений Check Repeats<<<");
            Console.WriteLine("\nДля выхода, введите \"Q\"");

            string key = "a";

            while (key != "q") 
            {
                Console.Write("\nВведите число для проверки: ");
                key = Console.ReadLine();

                if (int.TryParse(key, out int number)) { }
                else if (key == "q") break;
                else { Console.WriteLine($">> {key} << - неправильный формат данных!"); continue; }

                if (AddNumber(number)) Console.WriteLine("<< Число добавлено! >>");
                else Console.WriteLine("<< Число повторяется! >>");
            }
            Console.WriteLine("...Работа Check Repeats завершена...");
        }

        static bool AddNumber(int num)
        {
            int count = hash.Count;
            hash.Add(num);

            if (hash.Count > count) return true;
            else return false;
        }
    }
}
