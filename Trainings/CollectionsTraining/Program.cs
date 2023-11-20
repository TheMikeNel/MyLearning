using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionar();
            Queu();
            Stec();
            Hash();
            Console.ReadKey();
        }

        // Есть List - почти как Array, только оптимизированнее и проще

        static void Dictionar()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {{"Cars", 2 }, {"Builds", 3 } };

            foreach (KeyValuePair<string, int> kvp in dict) // Для перебора Dictionary создается  экземпляр KeyValuePair
            {
                Console.WriteLine($"{kvp.Key} count is {kvp.Value}");
            }
        }

        static void Queu()
        {
            // FiFO - First in first out. Представляется как очередь. При добавлении элементов и последующем получении элемента, первым выйдет тот, который первым зашел.\

            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(5);
            q.Enqueue(6);
            int r = q.Dequeue();
            Console.WriteLine($"Last elem = {r}, Dequeue now = {q.Dequeue()}, Peek = {q.Peek()}");
        }

        static void Stec()
        {
            //FILO - First in last out. Можно представить как стопку книг. Каждый добавляемый элемент кладется сверху стопки. И при взятии этемента из стека, берется последняя положенная книга

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine($"{stack.Pop()} - pop, {stack.Peek()} - Peek");
            int som = stack.Pop() + stack.Pop();
            Console.WriteLine($"Summ = {som}, Count = {stack.Count}");
        }

        static void Hash()
        {
            //Множества значений (математика)

            HashSet<int> hash1 = new HashSet<int>() { 1, 1, 1, 1, 2, 3, 4, 5, 5}; // Запишет только 1 2 3 4 5, т.к. учитываются только оригинальные данные.
            foreach (int hash in hash1) Console.WriteLine(hash);

            HashSet<int> hash2 = new HashSet<int>() { 1, 3, 2, 6, 7, 7 };
            foreach (int hash in hash2) Console.WriteLine(hash);

            hash1.UnionWith(hash2); // Сложение множеств
            foreach (int hash in hash1) Console.WriteLine("Union is " + hash);

            hash1.ExceptWith(hash2); // Вычитание множеств
            foreach (int hash in hash1) Console.WriteLine("Except is " + hash);
        }
    }
}
