using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxAreaOfIsland
{
    class Program
    {
        //https://leetcode.com/problems/max-area-of-island/
        static void Main(string[] args)
        {

        }

        public static int MaxAreaOfIsland(int[,] grid)
        {
            int max = 0;
            int row = grid.GetLength(0);
            int col = grid.GetLength(1);
            for(int i=0;i<row;i++)
            {
                for(int j=0;j<col;j++)
                {
                    if(grid[i,j] ==1)
                    {
                        max = Math.Max(max, Dfs(grid, i, j));
                    }
                }
            }

            return max;
        }

        private static int  Dfs(int[,] grid, int i, int j)
        {
            int row = grid.GetLength(0);
            int col = grid.GetLength(1);
            if (i < 0 || i >= row || j < 0 || j >= col || grid[i, j] == 0)
                return 0;

            grid[i, j] = 0;
            int count = 1;

            count += Dfs(grid, i + 1, j);
            count += Dfs(grid, i - 1, j);
            count += Dfs(grid, i, j + 1);
            count += Dfs(grid, i, j - 1);

            return count;
        }
    }
}
