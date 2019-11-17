using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int GetNthFibonacciRecursive(int n)
        {
            if (n == 1)
                return 0;
            else if (n == 2)
                return 1;
            else
                return GetNthFibonacciRecursive(n - 1) + GetNthFibonacciRecursive(n - 2);
        }

        public static int GetNthFibonacciUsingMemoize(int n)
        {
            Dictionary<int, int> memoize = new Dictionary<int, int>();
            memoize.Add(1, 0);
            memoize.Add(2, 1);
            return GetNthFibonacci(n, memoize);
        }

        private static int GetNthFibonacci(int n, Dictionary<int, int> memoize)
        {
            if (memoize.ContainsKey(n))
                return memoize[n];
            else
            {
                memoize.Add(n, GetNthFibonacci(n - 1, memoize) + GetNthFibonacci(n - 2, memoize));
                return memoize[n];
            }
        }

        public static int GetNthFibonacciIterative(int n)
        {
            List<int> previousTwo = new List<int> { 0, 1 };
            int counter = 3;
            while(counter <=n)
            {
                int nextFib = previousTwo[0] + previousTwo[1];
                previousTwo[0] = previousTwo[1];
                previousTwo[1] = nextFib;
            }

            if (n > 1)
                return previousTwo[1];
            else
                return previousTwo[0];

    
        }
    }
}
