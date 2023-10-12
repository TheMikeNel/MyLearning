using System;

namespace ConsoleApps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Иванов Иван Иванович";
            byte age = 20;
            string email = "ivan@mail.ru";
            byte programScores = 10;
            byte mathScores = 7;
            byte physicScores = 5;
            float approxScores = ((float)programScores + (float)mathScores + (float)physicScores) / 3;

            //Задание 1. Вариант №1
            Console.WriteLine($"Full name: {fullName} \nAge: {age} \nEmail: {email} \nProgramming scores: {programScores} \nMath scores: {mathScores} \nPhysicScores {physicScores}");
            Console.WriteLine("Approximate: " + approxScores.ToString("#.#") + "\n");
            Console.ReadKey();

            //Задание 1. Вариант №2
            string fullSet = "Full name: {0} \nAge: {1} \nEmail: {2} \nProg scores: {3} \nMath scores: {4} \nPhysicScores: {5} \nApproximate {6}";

            Console.WriteLine(fullSet,
                fullName,
                age,
                email,
                programScores,
                mathScores,
                physicScores,
                approxScores.ToString("#.##"));
            Console.ReadKey();

            //Задание 2
            Console.WriteLine("\nSumm of Scores: {0}\nApproximate Scores: {1}", 
                (programScores + mathScores + physicScores).ToString(),
                approxScores.ToString("---> # . ## <---"));
            Console.ReadKey();
        }
    }
}
