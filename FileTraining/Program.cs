using System;
using System.IO;
using System.Text;

namespace FileTraining
{
    internal class Program
    {
        static string checkedDirectoryPath = @"C:\Users\mihar\Documents\Data\GitHub\MyLearning";

        static void DirectoryTree(string path, string trim = "")
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach (var item in directoryInfo.GetDirectories())
            {
                Console.WriteLine($"{trim}{item.Name}");
                DirectoryTree(item.FullName, trim + "  ");
            }

            foreach (var item in directoryInfo.GetFiles()) { Console.WriteLine($"{trim}{item.Name}"); }
        }


        static string companyNamePath = @"companyName.txt";

        static void CreateCompanyName()
        {
            if (File.Exists(companyNamePath))
            {
                Console.WriteLine($"Компания: {File.ReadAllText(companyNamePath)}");
            }
            else
            {
                Console.Write("Введите название компании: ");
                string companyName = Console.ReadLine();

                File.WriteAllText(companyNamePath, companyName);
                CreateCompanyName();
            }
        }


        static string dirsWriteFile = @"checkedDirs.txt";

        static void WriteDirectoriesToFile(string dir)
        {
            var dirs = new DirectoryInfo(dir).GetDirectories();

            using (StreamWriter sw = new StreamWriter(dirsWriteFile))
            {
                foreach (DirectoryInfo d in dirs)
                {
                    sw.WriteLine(d.Name);
                    Console.WriteLine($">> {d.Name}");
                }
            }
            Console.WriteLine("\n>>>Запись завершена<<<");
        }

        static void ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine($"Dirrr: {sr.ReadLine()}");
                }
            }
            Console.WriteLine("\n>>>Вывод завершен<<<");
        }


        static string notesFile = "Notes.csv";

        static void NotesWriting()
        {
            char k = 'y';
            string note = string.Empty;
            Console.WriteLine("\nЗапись заметок >>");

            using (StreamWriter sw = new StreamWriter(notesFile, true, Encoding.Unicode))
            {
                do
                {
                    Console.WriteLine("\nВведите имя автора: ");
                    note += $"{Console.ReadLine()}\t";

                    string now = DateTime.Now.ToShortTimeString();
                    Console.WriteLine($"Время заметки: \n{now}");
                    note += now + "\t";

                    Console.WriteLine("Заметкa >>");
                    note += $"{Console.ReadLine()}\t";
                    sw.WriteLine(note);

                    Console.Write("\nПродолжить? n/y: "); k = Console.ReadKey().KeyChar;

                } while (char.ToLower(k) != 'n');
            }
        }

        static void NotesReading()
        {
            Console.WriteLine("\nЧтение заметок >>");

            using (StreamReader sr = new StreamReader(notesFile, Encoding.Unicode))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] note = line.Split('\t');
                    Console.WriteLine($"Автор: {note[0], 10}    Время записи: {note[1], 5}    Заметка: {note[2]}");                                        
                }
            }
        }

        static void BuildString(params string[] args)
        {
            StringBuilder sb1 = new StringBuilder("Hello");
            Console.WriteLine("Длина sb1 = " + sb1.Length);
            Console.WriteLine("Вместимость = " +  sb1.Capacity);

            StringBuilder sb2 = new StringBuilder(100);
            Console.WriteLine("Длина sb2 = " + sb2.Length);
            Console.WriteLine("Вместимость = " + sb2.Capacity);

            if (args != null)
            {
                Console.WriteLine(sb1.ToString());

                foreach (string arg in args)
                {
                    sb2.Append(arg + " ");
                    Console.WriteLine($"{"Append word: ",15} {arg}");
                }

                Console.WriteLine("sb2 is: " + sb2.ToString());
                Console.WriteLine("Текущая длина sb2 = " + sb2.Length);
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Проверка директории " + checkedDirectoryPath);
            DirectoryTree(checkedDirectoryPath);

            Console.WriteLine("\nПроверка компании...");

            CreateCompanyName();

            Console.WriteLine("\nПроизвести запись директорий в файл одним потоком...");
            Console.ReadKey();
            WriteDirectoriesToFile(checkedDirectoryPath);

            Console.WriteLine("\nВывести записанный файл...");
            Console.ReadKey();
            ReadFile(dirsWriteFile);


            Console.WriteLine("String builder works..");
            Console.Write("Write Any Line: "); string line = Console.ReadLine();
            BuildString(line.Split(' '));


            NotesWriting();
            Console.ReadKey();
            NotesReading();

            Console.ReadKey();
        }
    }
}
