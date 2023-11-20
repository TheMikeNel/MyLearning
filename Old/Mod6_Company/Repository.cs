using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mod6_Company
{
    internal class Repository
    {
        static readonly string path = @"Workers.csv";

        static int id = 0;

        /// <summary>
        /// Получение текущего ID добавляемого работника
        /// </summary>
        public static int GetNextID()
        {
            if (id == 0) // Если программа открывается в первый раз и еще не добавлено ни одного сотрудника, выполняется поиск ID последнего сотрудника
            {
                string[] s;

                if (File.Exists(path) && (s = File.ReadAllLines(path)).Length > 0) // Если программа уже создавала когда-либо файл и добавлялись сотрудники
                {
                    if (int.TryParse(s.Last().Split('#')[0], out id)) id++; // Если на последней строке файла корректно введены данные сотрудника, ID следующего сотрудника равен ID последнего добавленного + 1.
                    else id = 1; // Иначе ID следующего сотрудника = 1
                }
                else id = 1; // Иначе, если файла учета сотрудников не существует или сотрудники в него не добавлялись, ID следующего сотрудника = 1
            }
            else id++; // Иначе, если с программой работают в данный момент, то при добавлении нового сотрудника, его ID просто увеличивается на 1 после предыдущего.
            return id;
        }

        /// <summary>
        /// Получить список всех добавленных работников
        /// </summary>
        public static Worker[] GetAllWorkers()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    List<Worker> workers = new List<Worker>();

                    while(!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        Worker w = new Worker();
                        w.SetWorkerByLine(s);
                        workers.Add(w);
                    }

                    return workers.ToArray();
                }
            }
            else
            {
                Console.WriteLine("\nНи один работник не добавлен!");
                return null;
            }
        }

        /// <summary>
        /// Получить работника по его ID
        /// </summary>
        /// <param name="workerID"></param>
        /// <returns></returns>
        public static Worker GetWorkerByID(int workerID)
        {
            Worker w = new Worker();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        if (int.Parse(line.Split('#')[0]) == workerID) // Первым элементом в строке работника стоит его ID
                        {
                            w.SetWorkerByLine(line);
                            break;
                        }
                    }

                    if (w.ID == 0) Console.WriteLine("\nРаботник с заданным ID не найден"); // Если ID работника == 0 (Значение в конструкторе по умолчанию), то работника с таким ID не найдено
                                                                                            // т.к. ID работника, при его нахождении всегда >= 1
                    return w;
                }
            }
            else
            {
                Console.WriteLine("\nНи один работник не добавлен!");
                return w;
            }
        }

        /// <summary>
        /// Получить работников, добавленных по времени между двумя заданными DateTime
        /// </summary>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <returns></returns>
        public static Worker[] GetWorkersBetweenTwoDates(DateTime minDate, DateTime maxDate)
        {
            Worker[] workers = GetAllWorkers();

            if (workers != null) // Если в списке есть работники
            {
                List<Worker> result = new List<Worker>();

                foreach (Worker w in workers)
                {
                    if (w.DateOfAdd >= minDate && w.DateOfAdd <= maxDate) result.Add(w);
                }

                return result.ToArray();
            }
            else return null;
        }

        /// <summary>
        /// Добавить работника в список с заданным форматированием (добавление табуляции)
        /// </summary>
        /// <param name="worker">Параметры работника</param>
        public static void AddWorker(Worker worker)
        {
            using (StreamWriter sr = new StreamWriter(path, true, Encoding.Unicode))
            {
                string[] lineArr = worker.GetWorkerParamsAsString().Split('#');
                string line = string.Empty;

                foreach (string l in lineArr)
                {
                    line += l + "#\t";
                }

                sr.WriteLine(line);
            }
        }

        /// <summary>
        /// Удалить работника из списка по его ID
        /// </summary>
        /// <param name="workerID"></param>
        public static void DeleteWorker(int workerID)
        {
            Worker[] workers = GetAllWorkers();
            bool isDeleted = false;

            if (workers != null) // Если список работников не пуст
            {
                foreach (Worker worker in workers)
                {
                    if (worker.ID == workerID) // Если в списке по порядку найден работник с данным ID, файл с работниками удаляется
                                               // и создается новый файл со всеми работниками из удаленного файла, кроме удаляемого работника
                    {
                        File.Delete(path);
                        isDeleted = true;

                        foreach (Worker w in workers) // Создание нового файла с добавлением всех работников, кроме удаляемого
                        {
                            if (w.ID == workerID) continue;
                            AddWorker(w);
                        }
                        break;
                    }
                }

                if (isDeleted) Console.WriteLine("Работник удалён"); // Если в ходе программы, работник с заданным ID нашелся в списке, он будет удален
                else Console.WriteLine($"Работник с ID: {workerID} не найден!"); // Иначе, работника с таким ID не найдено
            }
        }

        #region Sorting

        /// <summary>
        /// Получить массив работников, отсортированных по возрасту
        /// </summary>
        /// <returns></returns>
        public static Worker[] GetWorkersSortByAge()
        {
            Worker[] w = GetAllWorkers();

            for (int i = 0; i < w.Length - 1; i++)
            {
                for (int j = i + 1; j < w.Length; j++)
                {
                    if (w[i].Age < w[j].Age)
                    {
                        Worker t = w[j];
                        w[j] = w[i];
                        w[i] = t;
                    }
                }
            }

            return w;
        }

        /// <summary>
        /// Получить массив работников, отсортированных по высоте
        /// </summary>
        /// <returns></returns>
        public static Worker[] GetWorkersSortByHeight()
        {
            Worker[] w = GetAllWorkers();
            
            for (int i = 0; i < w.Length - 1; i++)
            {
                for (int j = i + 1; j < w.Length; j++)
                {
                    if (w[i].Height < w[j].Height)
                    {
                        Worker t = w[j];
                        w[j] = w[i];
                        w[i] = t;
                    }
                }
            }
            return w;
        }
        #endregion
    }
}
