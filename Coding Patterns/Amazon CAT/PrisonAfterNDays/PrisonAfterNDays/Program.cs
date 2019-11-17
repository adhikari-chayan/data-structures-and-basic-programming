using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonAfterNDays
{
    /// <summary>
    /// Applying XNOR
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var cells = new int[] { 0, 1, 0, 1, 1, 0, 0, 1 };
            //var result = ActiveAndInactive(cells, cells.Length, 7);
            var result = PrisonAfterNDays(cells, cells.Length);
            foreach (var item in result)
                Console.Write(item+" ");

            Console.ReadKey();
        }

        static int[] ActiveAndInactive(int[] cells,
                              int n, int k)
        {

            // copy cells[] array into 
            // temp [] array 
            bool[] temp = new bool[n];
            for (int i = 0; i < n; i++)
                temp[i] = Convert.ToBoolean(cells[i]);

            // Iterate for k days 
            while (k-- > 0)
            {

                // Finding next values  
                // for corner cells 
                //temp[0] = false == Convert.ToBoolean(cells[1]);
                //temp[n - 1] = false == Convert.ToBoolean(cells[n - 2]);

                // Compute values of intermediate cells 
                // If both cells active or inactive, then  
                // temp[i]=0 else temp[i] = 1. 
                for (int i = 1; i <= n - 2; i++)
                    //XNOR for boolean can be achived by applying ==
                    temp[i] = Convert.ToBoolean(cells[i - 1]) == Convert.ToBoolean(cells[i + 1]);

                // Copy temp[] to cells[]  
                // for next iteration 
                for (int i = 0; i < n; i++)
                    cells[i] = Convert.ToInt32(temp[i]);
            }

            return cells;
        }


        public static int[] PrisonAfterNDays(int[] cells, int N)
        {

            Dictionary<int, int> allStates = new Dictionary<int, int>();
            int state = 0;
            for (int i = 0; i < 8; ++i)
            {
                if (cells[i] > 0)
                    state ^= 1 << i;
            }



            // While days remaining, simulate a day
            while (N > 0)
            {
                // If this is a cycle, fast forward by
                // seen.get(state) - N, the period of the cycle.
                if (allStates.ContainsKey(state))
                {
                    N %= allStates[state] - N;
                }
                else
                {
                    allStates.Add(state, N);
                }


                if (N >= 1)
                {
                    N--;
                    state = NextDay(state);
                }
            }

            int[] ans = new int[8];
            for (int i = 0; i < 8; ++i)
            {
                if (((state >> i) & 1) > 0)
                {
                    ans[i] = 1;
                }
            }

            return ans;
        }

        public static int NextDay(int state)
        {
            int ans = 0;

            // We only loop from 1 to 6 because 0 and 7 are impossible,
            // as those cells only have one neighbor.
            for (int i = 1; i <= 6; ++i)
            {
                if (((state >> (i - 1)) & 1) == ((state >> (i + 1)) & 1))
                {
                    ans ^= 1 << i;
                }
            }

            return ans;
        }


    }
}
