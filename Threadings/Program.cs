namespace Threadings
{
    internal class Program
    {
        private static object sync = new object();

        private static int thCount = 0;
        private static void ThreadTask(object? o)
        {
            var th = Thread.CurrentThread;
            Console.WriteLine($"Thread started: {th.Name}. Hash = {th.GetHashCode()}, ID: {th.ManagedThreadId}, param: {o}");
            thCount++;

            lock (sync)
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Event: {o}");
                    Thread.Sleep(150);
                }
                Console.WriteLine($"Thread ends: {th.Name}. Hash = {th.GetHashCode()}, ID: {th.ManagedThreadId}");
            }
        }

        static void Main(string[] args)
        {           
            var th = Thread.CurrentThread;
            th.Name = "MainThread";
            Console.WriteLine($"TEntery point: {th.Name}. Hash = {th.GetHashCode()}, ID: {th.ManagedThreadId}");

            Thread thread1 = new(ThreadTask);
            Thread thread2 = new(ThreadTask);
            Thread thread3 = new(ThreadTask);

            thread1.Start("Negr killed");
            thread2.Start("Norm people alive");
            thread3.Start("Cat eats");

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
                if (i >= 25) thread3.Join();
                Thread.Sleep(20);
            }
            ThreadTask("Nothing!");
            Console.WriteLine(thCount);
        }
    }
}
