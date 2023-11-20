using System;

namespace Mod8_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lists.ListWorking(100, 100, 25, 50);
            Console.WriteLine("Для продолжения, нажмите любую клавишу...");

            Console.ReadKey();

            NumberBook.NumberBookWorking();
            Console.WriteLine("Для продолжения, нажмите любую клавишу...");

            Console.ReadKey();

            CheckRepeats.CheckRepeatsWorking();
            Console.WriteLine("Для продолжения, нажмите любую клавишу...");

            Console.ReadKey();

            WriteBook.WriteBookWorking();
            Console.WriteLine("Для продолжения, нажмите любую клавишу...");

            Console.ReadKey();
        }
    }
}
