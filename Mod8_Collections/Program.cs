using System;

namespace Mod8_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lists.ListWorking(100, 100, 25, 50);
            Console.WriteLine("\nДля продолжения, нажмите любую клавишу...\n");

            Console.ReadKey();

            NumberBook.NumberBookWorking();
            Console.WriteLine("\nДля продолжения, нажмите любую клавишу...\n");

            Console.ReadKey();

            CheckRepeats.CheckRepeatsWorking();
            Console.WriteLine("\nДля продолжения, нажмите любую клавишу...\n");

            Console.ReadKey();

            WriteBook.WriteBookWorking();
            Console.WriteLine("\nДля продолжения, нажмите любую клавишу...\n");

            Console.ReadKey();
        }
    }
}
