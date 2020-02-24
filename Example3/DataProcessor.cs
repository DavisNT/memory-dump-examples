using System;
using System.Collections.Generic;
using System.Linq;

namespace Example3
{
    class DataProcessor
    {
        private int count = 0;
        private int result = 0;
        private object lockObject = new object();

        private int[] lookupTable = { 4, 8, 5, 11, 6, 5, 9, 31, 7, 2,
            8, 2, 2, 34, 1, 16, 8, 1, 15, 3,
            15, 5, 9, 7, 81, 9, 9, 83, 3, 3,
            31, 5, 5, 31, 4, 8, 8, 5, 5, 45,
            7, 6, 59, 9, 9, 1, 4, 46, 2, 21,
            57, 2, 89, 2, 41, 4, 67, 30, 7, 3,
            9, 3, 10, 79, 5, 8, 78, 2, 7, 97,
            50, 99, 7, 9, 19, 35, 2, 6, 85, 1,
            47, 3, 64, 9, 78, 33, 9, 2, 3, 81,
            1, 1, 98, 3, 19, 5, 6, 55, 98, 44 };
        private Dictionary<int, int> lookupDictionary = new Dictionary<int, int>();

        public DataProcessor() {
            for (int i = 0; i < 20000; i++) {
                    lookupDictionary.Add(i, lookupTable[i % 100]+i);
            }
        }
        private int InnocentHorrorCalculation(int k, int v, int p) {
            var ts = new TimeSpan(k, v, p);

            return (k + 1) * (p + 1) + ts.Days;
        }
        
        private int GetCompulationallyExpensiveCalculationResult(int p)
        {
            int r = p * p % 100;

            do
            {
                r += p;
                r += lookupDictionary.FirstOrDefault(n => InnocentHorrorCalculation(n.Key, n.Value, p) % 101 > Math.Abs(r)).Value;
                p = lookupTable[p];
            }
            while (p >= 10);
            return r;
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
