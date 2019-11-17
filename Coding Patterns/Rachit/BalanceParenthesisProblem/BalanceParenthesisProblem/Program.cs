using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceParenthesisProblem
{
    /*
        () has score 1
        AB has score A + B where A and B are balanced parenthesis strings
        (A) has score 2 * A where A is a balanced parenthesis string

        Input: (()(()))
        Output: 6
    */
    class Program
    {
        private static int[] en;
        static void Main(string[] args)
        {
            var input = "(()(()))";
            var result = ScoreOfParenthesis(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int ScoreOfParenthesis(string s)
        {
            int n = s.Length;
            en = new int[n];
            Stack<int> st = new Stack<int>();
            for(int i = 0; i < n; i++)
            {
                if (s[i] == '(')
                    st.Push(i);
                else
                {
                    int t = st.Peek();
                    en[t] = i;//important!! index of the array represents the left parenthesis and its corresponding value represents the position of balanced right parenthesis
                    st.Pop();
                }
            }
            return Go(0, n - 1);

        }

        private static int Go(int lo, int hi)
        {
            if (lo + 1 == hi)
                return 1;
            int mid = en[lo];//important
            if (mid == hi)
                return 2 * Go(lo + 1, hi - 1);
            return Go(lo, mid) + Go(mid + 1, hi);

        }
    }
}
