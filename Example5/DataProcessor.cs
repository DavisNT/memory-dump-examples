using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Example5
{
    class DataProcessor
    {
        private int count = 0;
        private int result = 0;
        private object lockObject = new object();
        private ConcurrentDictionary<int, DataClass> localCache = new ConcurrentDictionary<int, DataClass>();
        private static List<ConcurrentDictionary<int, DataClass>> globalCache = new List<ConcurrentDictionary<int, DataClass>>();

        public DataProcessor()
        {
            globalCache.Add(localCache);
        }
        private int GetCompulationallyExpensiveCalculationResult(int p)
        {
            if (!localCache.ContainsKey(p))
            {
                localCache[p] = new DataClass("created for parameter " + p.ToString() + " in some iteration");
            }
            return localCache[p].names.Count;
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
