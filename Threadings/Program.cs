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
                if (o is CancellationToken cancellationToken)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("Cancellable thread work iteration: " + i);
                        if (cancellationToken.IsCancellationRequested)
                        {
                            Console.WriteLine("Thread cancelled");
                            Console.WriteLine($"Thread ends: {th.Name}. Hash = {th.GetHashCode()}, ID: {th.ManagedThreadId}");
                            break;
                        }
                        Thread.Sleep(150);
                    }
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Event: {o}");
                        Thread.Sleep(150);
                    }
                }

                Console.WriteLine($"Thread ends: {th.Name}. Hash = {th.GetHashCode()}, ID: {th.ManagedThreadId}");
            }
        }

        private static void ThreadReadKey(CancellationTokenSource cancel)
        {
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine("Entered char: " + c);
            cancel.Cancel();
        }

        static void Main(string[] args)
        {           
            var th = Thread.CurrentThread;
            th.Name = "MainThread";
            Console.WriteLine($"TEntery point: {th.Name}. Hash = {th.GetHashCode()}, ID: {th.ManagedThreadId}");

            Thread thread1 = new(ThreadTask);
            Thread thread3 = new(ThreadTask);

            using (CancellationTokenSource tokenSource = new())
            {
                CancellationToken token = tokenSource.Token;
                thread1.Start("Negr killed");
                ParameterizedThreadStart cancelThread = new((o) => ThreadReadKey(tokenSource));
                Thread thread2 = new(cancelThread);
                thread2.Start();
                thread3.Start(token);

                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine(i);
                    if (i >= 25) thread3.Join();
                    Thread.Sleep(50);
                }

                tokenSource.Cancel();
            }

            Console.WriteLine(thCount);
        }
    }
}
