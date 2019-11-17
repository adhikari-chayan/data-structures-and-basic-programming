using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigzagTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var input = new List<List<int>>
            {
               new List<int> {1,3,4,10 },
               new List<int> {2,5,9,11 },
               new List<int> {6,8,12,15 },
               new List<int> {7,13,14,16 }
            };

            var result = Program.ZigZagTraversal(input);
            foreach(var item in result)
                Console.Write(item+" ");
            Console.ReadKey();
        }

        public static List<int> ZigZagTraversal(List<List<int>> array)
        {
            int maxRowIdx = array.Count() - 1;
            int maxColIdx = array[0].Count() - 1;

            List<int> result = new List<int>();
            int row = 0;
            int col = 0;
            bool goingDown = true;//start is always going down from (0,0)
            while (!IsOutOfBounds(row, col, maxRowIdx, maxColIdx))
            {
                result.Add(array[row][col]);
                if(goingDown)
                {
                    if (col == 0 || row == maxRowIdx)//weird point reached
                    {
                        goingDown = false;//change direction to go up
                        if(col==0)//1st column
                        {
                            row++;
                        }
                        else//last row
                        {
                            col++;
                        }
                    }
                    else
                    {
                        row++;
                        col--;
                    }
                }
                else//going up
                {
                    if(row==0 || col == maxColIdx)//weird point reached
                    {
                        goingDown = true;//change direction to go down
                        if(row==0)//1st row
                        {
                            col++;
                        }
                        else//last column
                        {
                            row++;
                        }
                    }
                    else
                    {
                        row--;
                        col++;
                    }

                }
            }
            return result;

            
        }

        private static bool IsOutOfBounds(int row, int col, int maxRowIdx, int maxColIdx)
        {
            return row < 0 || row > maxRowIdx || col < 0 || col > maxColIdx;
        }
    }
}
