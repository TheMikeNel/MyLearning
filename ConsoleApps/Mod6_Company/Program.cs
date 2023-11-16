using System;
using System.IO;

namespace Mod6_Company
{
    internal class Program
    {
        static string nameFile = "Company.txt";

        /// <summary>
        /// Создание имени компании, если оно не было задано ранее
        /// </summary>
        static void CompanyNaming()
        {
            if (File.Exists(nameFile))
            {
                Console.WriteLine($"\nКомпания  {File.ReadAllText(nameFile)}\n");
            }
            else
            {
                Console.Write("\nВведите название вашей компании: "); string name = Console.ReadLine();
                File.WriteAllText(nameFile, name);
                CompanyNaming();
            }
        }

        /// <summary>
        /// Отображение с настроенным форматированием заданных работников в консоли 
        /// </summary>
        /// <param name="workers"></param>
        static void DisplayWorkerParamsToLine(Worker[] workers)
        {
            if (workers != null)
            {
                Console.WriteLine("\nID \t Время создания \t\t ФИО \t Возраст  Рост \t Дата рождения \t Место рождения\n");

                foreach (Worker worker in workers)
                {
                    string[] line = worker.GetWorkerParamsAsString().Split('#');

                    Console.WriteLine($"{line[0]} \t{line[1]}\t{line[2],10} {line[3],5} {line[4],5}  \t{line[5]} {line[6],10}\n");
                }
            }
        }

        /// <summary>
        /// Запись нового работника
        /// </summary>
        static void WriteWorker()
        {
            string line = string.Empty;
            int employeeID = Repository.GetNextID();

            Console.WriteLine("\n\nID: " + employeeID); line += employeeID + "#";

            Console.WriteLine($"\nВремя добавления записи: {DateTime.Now}"); line += DateTime.Now.ToString() + "#";

            Console.Write("\nВведите Ф И О сотрудника: "); line += Console.ReadLine() + "#";

            Console.Write("\nВозраст: "); line += Console.ReadLine() + "#";

            Console.Write("\nРост: "); line += Console.ReadLine() + "#";

            Console.Write("\nДата рождения >> Год: "); int year = int.Parse(Console.ReadLine());
            Console.Write("\nДата рождения >> Месяц: "); int month = int.Parse(Console.ReadLine());
            Console.Write("\nДата рождения >> День: "); int day = int.Parse(Console.ReadLine());
            DateTime dateTime = new DateTime(year, month, day);
            line += dateTime.ToShortDateString() + "#";

            Console.Write("\nМесто рождения: "); line += Console.ReadLine();

            Worker w = new Worker();
            w.SetWorkerByLine(line);
            Repository.AddWorker(w);
        }

        static void DeleteWorkerByID(int id)
        {
            Repository.DeleteWorker(id);
        }

        /// <summary>
        /// Чтение всех работников
        /// </summary>
        static void ReadAllWorkers()
        {
            Worker[] workers = Repository.GetAllWorkers();
            DisplayWorkerParamsToLine(workers);
        }

        /// <summary>
        /// Чтение работника с соответствующим ID
        /// </summary>
        /// <param name="id"></param>
        static void ReadWorkerByID(int id)
        {
            Worker w = Repository.GetWorkerByID(id);

            if (w.ID != 0)
            {
                Worker[] wArr = new Worker[1]; // Создание массива из одного работника для форматированного отображения одного работника в консоли
                                               // (в метод вывода DisplayWorkerParamsToLine(), в качестве работников передается только массив)
                wArr[0] = w;

                DisplayWorkerParamsToLine(wArr);
            }
        }

        /// <summary>
        /// Получение работников с соответствующим временем записи в файл диапазону между min и max DateTime
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        static void ReadWorkersBetweenTwoDates(DateTime min, DateTime max)
        {
            Worker[] w = Repository.GetWorkersBetweenTwoDates(min, max);
            DisplayWorkerParamsToLine(w);
        }

        static void Main(string[] args)
        {
            // Строка-подсказка с наименованием функциональных клавиш
            string functionsDescription =
            "\nДобавить работника (a)\n" +
            "Удалить работника с заданным ID (d)\n" +
            "Получить всех работников (g)\n" +
            "Получить работника с заданным ID (i)\n" +
            "Получить всех работников, добавленных между двумя датами (t)\n>>: ";

            Console.WriteLine("Добро пожаловать в справочник работников!");
            CompanyNaming();
            char key;

            Console.Write("\n" + functionsDescription); key = char.ToLower(Console.ReadKey().KeyChar);

            while (key == 'a' || key == 'd' || key == 'g' || key == 'i' || key == 't')
            {
                switch (char.ToLower(key))
                {
                    case 'a':
                        WriteWorker();
                        Console.WriteLine("\nРаботник добавлен");
                        break;
                    case 'g':
                        ReadAllWorkers();
                        break;
                    case 'i':
                        Console.Write("\nВведите ID искомого работника: "); 
                        ReadWorkerByID(int.Parse(Console.ReadLine()));
                        break;
                    case 'd':
                        Console.Write("\nВведите ID удаляемого работника: ");
                        DeleteWorkerByID(int.Parse(Console.ReadLine()));
                        break;
                    case 't':
                        DateTime minDate = DateTime.Now.AddDays(-10);
                        DateTime maxDate = DateTime.Now.AddDays(1);
                        Console.WriteLine($"\nПолучение работников, добавленных в промежутке между {minDate} и {maxDate} числами");
                        ReadWorkersBetweenTwoDates(minDate, maxDate);
                        break;
                }
                Console.Write("\n" + functionsDescription); key = char.ToLower(Console.ReadKey().KeyChar);
            } 


            Console.ReadKey();
        }
    }
}
