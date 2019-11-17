using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int UniquePaths(int m,int n)
        {
            int[,] dp = new int[m, n];
            for(var i=0;i<m;i++)
            {
                dp[i, 0] = 1;//For 0th column, to go to every row we have only 1 way  
            }

            for(var i=0;i<n;i++)
            {
                dp[0, i] = 1;//For 0th row, to go to every column we have only 1 way
            }

            //Now 1st row and 1st column is filled with 1s
            for(var i=1;i<m;i++)
            {
                for(var j=1;j<m;j++)
                {
                    //We can come to the (i,j)th cell from either top cell or left cell
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
