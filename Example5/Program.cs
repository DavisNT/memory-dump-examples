using System;
using System.Threading;

namespace Example5
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Running iteration {0}...", i);
                CreateThreadsAndRunProcessing();
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }
        static void CreateThreadsAndRunProcessing()
        {
            Thread[] threadsArray = new Thread[100];
            var dp = new DataProcessor();

            Console.WriteLine("Starting processing in 100 threads...");
            for (int i = 0; i < 100; i++)
            {
                var i2 = i;
                threadsArray[i] = new Thread(() => dp.DoProcessing(i2));
                threadsArray[i].Start();
            }
            Console.WriteLine("Threads started.");

            for (int i = 0; i < 100; i++)
            {
                threadsArray[i].Join();
            }
            Console.WriteLine("Processing done. Result is " + dp.GetResults());
        }
    }
}
