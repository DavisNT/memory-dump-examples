﻿using System;
using System.Threading;

namespace Example4
{
    class Program
    {
        static void Main(string[] args)
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
            Thread.Sleep(15000);
            Console.WriteLine("15 seconds elapsed since all threads have been started.");

            for (int i = 0; i < 100; i++)
            {
                threadsArray[i].Join();
            }
            Console.WriteLine("Processing done. Result is " + dp.GetResults());
        }
    }
}
