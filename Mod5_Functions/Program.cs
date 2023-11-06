using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod5_Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string line = Console.ReadLine();
            Console.WriteLine("Реверсивный текст: " + ReversWords(line));
            Console.ReadKey();
        }

        private static string ReversWords(string text)
        {
            string[] words = SeparateLineWords(text); ;
            string endLine = "";

            for (int i = words.Length - 1; i >= 0; i--) 
            {
                endLine += words[i] + " ";
            }

            return endLine;
        }

        private static string[] SeparateLineWords(string line)
        {
            return line.Split(' ');
        }
    }
}
