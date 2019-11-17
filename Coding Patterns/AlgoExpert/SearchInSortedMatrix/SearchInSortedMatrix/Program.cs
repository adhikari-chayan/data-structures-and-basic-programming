using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInSortedMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] input = new int[,]
            {
                {1,4,7,12,15,1000 },
                {2,5,19,31,32,1001 },
                {3,8,24,33,35,1002 },
                {40,41,42,44,45,1003},
                {99,100,103,106,128,1004 }
            };

            var result = SearchInSortedArray(input, 44);

            foreach(var item in result)
                Console.Write(item+", ");

            Console.ReadKey();

        }

        public static int[] SearchInSortedArray(int[,] matrix,int target)
        {
            int row = 0;
            int col = matrix.GetLength(1) - 1;

            while(row<matrix.GetLength(0) && col>=0)
            {
                if (matrix[row, col] > target)
                    col--;
                else if (matrix[row, col] < target)
                    row++;
                else
                    return new int[] { row, col };
            }

            return new int[] { -1, -1 };
        }
    }
}
