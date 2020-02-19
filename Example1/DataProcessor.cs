using System;
using System.Threading;

namespace Example1
{
    class DataProcessor
    {
        private int count = 0;
        private int sum = 0;
        private object lockobject = new object();

        private int GetCompulationallyExpensiveCalculationResult(int p)
        {
            Thread.Sleep(5000);
            return p * 5;
        }
        private void DoCalculationAndUpdateResultsInterlocked(int p) {
            lock (lockobject)
            {
                sum += GetCompulationallyExpensiveCalculationResult(p);
                count++;
            }
        }
        public void DoProcessing(int p) {
            if (p < 0 || p > 100) {
                throw new ArgumentOutOfRangeException("Incorrect parameter");
            }
            DoCalculationAndUpdateResultsInterlocked(p);
        }
        public string GetResults() {
            return string.Format("count = {0}, sum = {1}", count, sum);
        }
    }
}
