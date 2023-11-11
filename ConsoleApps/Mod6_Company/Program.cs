using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod6_Company
{
    internal class Program
    {
        static string nameFile = "Company.txt";
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

        static string employeeFile = "Employees.csv";
        static int employeeID = 0;
        static void WriteEmployees()
        {
            if (employeeID == 0) // Если программа открывается в первый раз и еще не добавлено ни одного сотрудника, выполняется поиск ID последнего сотрудника
            {
                string[] s;

                if (File.Exists(employeeFile) && (s = File.ReadAllLines(employeeFile)).Length > 0) // Если программа уже создавала когда-либо файл и добавлялись сотрудники
                {
                    if (int.TryParse(s.Last().Split('#')[0], out employeeID)) employeeID++; // Если на последней строке файла корректно введены данные сотрудника, ID следующего сотрудника равен ID последнего добавленного + 1.
                    else employeeID = 1; // Иначе ID следующего сотрудника = 1
                }
                else employeeID = 1; // Иначе, если файла учета сотрудников не существует или сотрудники в него не добавлялись, ID следующего сотрудника = 1
            }
            else employeeID++; // Иначе, если с программой работают в данный момент, то при добавлении нового сотрудника, его ID просто увеличивается на 1 после предыдущего.

            using (StreamWriter sw = new StreamWriter(employeeFile, true, Encoding.Unicode))
            {
                string line = string.Empty;
                
                Console.WriteLine("\n\nID: " + employeeID);
                line += employeeID + "#\t";

                Console.WriteLine($"\nВремя добавления записи: {DateTime.Now}");
                line += DateTime.Now.ToString() + "#\t";

                Console.Write("\nВведите Ф И О сотрудника: "); line += Console.ReadLine() + "#\t";

                Console.Write("\nВозраст: "); line += Console.ReadLine() + "#\t";

                Console.Write("\nРост: "); line += Console.ReadLine() + "#\t";

                Console.Write("\nДата рождения >> Год: "); int year = int.Parse(Console.ReadLine());
                Console.Write("\nДата рождения >> Месяц: "); int month = int.Parse(Console.ReadLine());
                Console.Write("\nДата рождения >> День: "); int day = int.Parse(Console.ReadLine());
                DateTime dateTime = new DateTime(year, month, day);
                line += dateTime.ToShortDateString() + "#\t";

                Console.Write("\nМесто рождения: "); line += Console.ReadLine();

                sw.WriteLine(line);

                Console.WriteLine("\nЗапись добавлена <<");
            }

        }

        static void ReadEmployees()
        {
            if (File.Exists(employeeFile))
            {
                Console.WriteLine("\n");

                using (StreamReader sr = new StreamReader(employeeFile))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] empData = line.Split('\t');
                        line = string.Empty;

                        foreach (string emp in empData)
                        {
                            line += emp + " ";
                        }
                        Console.WriteLine(line);
                    }
                }
            }
            else Console.WriteLine("\nФайл не создан. Добавьте хотя бы одну запись!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в справочник сотрудников!");
            CompanyNaming();
            char key;
            Console.Write("Добавить запись (a) или считать записи? (r) >>: "); key = Console.ReadKey(true).KeyChar;

            while (char.ToLower(key) == 'a' || char.ToLower(key) == 'r')
            {
                if (char.ToLower(key) == 'a')
                {
                    WriteEmployees();
                }
                else if (char.ToLower(key) == 'r')
                {
                    ReadEmployees();
                }
                Console.Write("\nДобавить запись (a) или считать записи? (r) >>: "); key = Console.ReadKey(true).KeyChar;
            }
        }
    }
}
