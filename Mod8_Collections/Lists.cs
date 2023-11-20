using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod8_Collections
{
    internal class Lists
    {
        /// <summary>
        /// Демонстрирует программу работы со списками List. Создает список из listCount рандомных значений в диапазоне от 0 до maxRandom,
        /// затем, удаляет значения, больше minValue, но меньше maxValue
        /// </summary>
        /// <param name="listCount"></param>
        /// <param name="maxRandom"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public static void ListWorking(int listCount, int maxRandom, int minValue, int maxValue)
        {
            List<int> list = CreateList(listCount, maxRandom);

            DisplayList(list);

            list = ReworkListByTwoRanges(list, minValue, maxValue);

            Console.WriteLine($"\nСписок, с удаленными значениями, соответствующими условию: больше {minValue}, но меньше {maxValue}");
            DisplayList(list);
        }

        static void DisplayList(List<int> list)
        {
            Console.WriteLine("Displaying List: ");

            foreach (int i in list) Console.Write(i + " ");

            Console.WriteLine("\nCount: " + list.Count);
        }

        static List<int> CreateList(int Length, int maxRand)
        {
            List<int> list = new List<int>();
            Random r = new Random();

            for (int i = 0; i < Length; i++) list.Add(r.Next(maxRand));

            return list;
        }

        static List<int> ReworkListByTwoRanges(List<int> list, int min, int max)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > min && list[i] < max) list.RemoveAt(i);
            }

            return list;
        }
    }
}
