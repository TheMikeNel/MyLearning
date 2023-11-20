using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int str;
            int stolb;
            Console.WriteLine("Создание матрицы.");
            Console.Write("Введите количество строк: "); str = int.Parse(Console.ReadLine());
            Console.Write("\nВведите количество столбцов: "); stolb = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Random r = new Random();
            int summ = 0;
            int[,] matrixA = new int[str, stolb];
            int[,] matrixB = new int[str, stolb];
            int[,] matrixC = new int[str, stolb];

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrixA[i, j] = r.Next(10, 100);
                    Console.Write(matrixA[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < matrixB.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    matrixB[i, j] = r.Next(10, 100);
                    Console.Write(matrixB[i, j] + " ");
                    summ += matrixB[i, j];
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nСуммирующая матрица\n");

            for (int k = 0; k < matrixC.GetLength(0); k++)
            {
                for (int l = 0; l < matrixC.GetLength(1); l++)
                {
                    matrixC[k, l] = matrixA[k, l] + matrixB[k, l];
                    Console.Write(matrixC[k, l] + " ");
                    summ += matrixC[k, l];
                }
                Console.WriteLine();
            }
            Console.Write("\nСумма всех элементов: " + summ);
            Console.ReadKey();


            #region Массив массивов

            Console.WriteLine("\n\nИнициализация программы замера температуры...");
            Console.Write("\n\nВведите количество часов работы: ");
            int hours = int.Parse(Console.ReadLine());

            Console.Write("\n\nВведите шаг замеров (раз в 1 - 60 минут): "); // Сколько раз за час производятся замеры
            int period = int.Parse(Console.ReadLine());
            int[][] measure = new int[hours][];

            int periodInHour = 60 / period; // Количество замеров за 1 час

            if (60 % period != 0) periodInHour++; // Если количество замеров не целое число, происходит округление в большую сторону

            if (periodInHour % period < 1) periodInHour = 1; // Если количество замеров меньше одного раза в час, все равно производится 1 замер

            Console.WriteLine() ;

            for (int i = 0; i < measure.Length; i++) // Создание матрицы замеров
            {
                measure[i] = new int[periodInHour]; // Задание количества замеров за час (Длины подмассива каждого элемента основного массива)
                Console.Write($"{i + 1} час:   ");

                for (int j = 0; j < periodInHour; j++) // Задание значений температуры в каждом периоде измерения за конкретный час
                {
                    measure[i][j] = r.Next(0, 50);
                    Console.Write($"{measure[i][j]} град. С  ");
                }
                Console.WriteLine();
            }

            int fullLength = measure.Length * periodInHour; // Полная длина массива массивов
            int sum = 0; 

            for (int i = 0; i < measure.Length; i++) // Цикл для определения суммы всех значений температуры (для вычисления средней температуры)
            {
                for (int j = 0; j < measure[i].Length; j++)
                {
                    sum += measure[i][j];
                }
            }

            float flMedian = (float)sum / (float)fullLength; // Средняя температура за все время
            Console.WriteLine($"\nСредняя температура за период замеров: {flMedian.ToString("#.#")} град. С");
            #endregion

            Console.ReadKey();
        }
    }
}
