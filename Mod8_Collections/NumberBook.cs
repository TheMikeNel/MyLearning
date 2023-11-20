using System;
using System.Collections.Generic;

namespace Mod8_Collections
{
    internal class NumberBook
    {
        static Dictionary<string, string> contacts = new Dictionary<string, string>();

        public static void NumberBookWorking()
        {
            Console.WriteLine("\nДобро пожаловать в книгу номеров!\n");
            Console.Write("Вы хотите добавить номер (a) или считать (g)?: ");
            char key = char.ToLower(Console.ReadKey().KeyChar);

            while (@"ag".IndexOf(key) > -1)
            {
                if (key == 'a')
                {
                    Console.WriteLine("\n<< Добавление номера >>\n");
                    Console.Write("Введите номер (формат: 89123456789): ");
                    string number = Console.ReadLine();

                    Console.Write("\nВведите имя контакта: ");
                    string name = Console.ReadLine();

                    AddNewContact(number, name);
                }

                else if (key == 'g')
                {
                    Console.WriteLine("\n<< Поиск контакта >>\n");

                    Console.Write("Введите номер (формат: 89123456789): ");
                    string num = Console.ReadLine();
                    string name = GetContactByNumber(num);

                    Console.WriteLine($">> Вывод: {((name == null) ? "Номер не найден!": name)} <<\n");
                }

                Console.Write("\nВы хотите добавить номер (a) или считать (g)?: ");
                key = char.ToLower(Console.ReadKey().KeyChar);
            }

            Console.WriteLine("\n>>> Работа с книгой номеров завершена <<<");
        }

        static void AddNewContact(string number, string name)
        {
            contacts.Add(number, name);
            Console.WriteLine("\n>>Номер добавлен!<<");
        }

        static string GetContactByNumber(string number)
        {
            if (contacts.TryGetValue(number, out string name)) return name;
            else return null;
        }
    }
}
