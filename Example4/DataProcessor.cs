using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Example4
{
    class DataProcessor
    {
        private int count = 0;
        private int result = 0;
        private object lockObject = new object();
        private Dictionary<Type, string> cache = new Dictionary<Type, string>();

        private int GetCompulationallyExpensiveCalculationResult(int p)
        {
            if (p < 10)
            {
                // 10 threads will go here
                for (int i = 0; i < 1000; i++)
                {
                    try
                    {
                        cache[typeof(int)] = "int";
                        Thread.Sleep(0);
                        cache.Remove(typeof(int));
                        cache[typeof(int)] = "int";
                        cache[typeof(string)] = "string";
                        cache.FirstOrDefault(kvp => kvp.Value == "string");
                        cache[typeof(int)] = "int32";
                    }
                    catch (Exception e)
                    {
                        // don't abort program on exception
                    }
                    Thread.Sleep(0);
                }
            } else
            {
                // 90 threads will wait 10 seconds and try to read an item from cache
                Thread.Sleep(10000);
                return cache[typeof(int)] == "int" ? 1 : 0;
            }
            return 5;
        }
        private void DoCalculationAndUpdateResultsInterlocked(int p)
        {
            var simpleFixForExample1Problem = GetCompulationallyExpensiveCalculationResult(p);
            lock (lockObject)
            {
                result += simpleFixForExample1Problem;
                count++;
            }
        }
        public void DoProcessing(int p)
        {
            if (p < 0 || p > 100)
            {
                throw new ArgumentOutOfRangeException("Incorrect parameter");
            }
            DoCalculationAndUpdateResultsInterlocked(p);
        }
        public string GetResults()
        {
            return string.Format("count = {0}, result = {1}", count, result);
        }
    }
}
