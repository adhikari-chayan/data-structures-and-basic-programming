using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArrayAroundPivot
{
    class Program
    {
        // {1,5,3,6,7,8,9,11,12} and I enter any number say 4 then my output should be {7,8,9,11,12,1,5,3,6}
        static void Main(string[] args)
        {
            var input = new int[] { 1, 5, 3, 6, 7, 8, 9, 11, 12 };
            var result = RotateLeft(input, 1);
            foreach(var item in result)
                Console.Write(item+" ");

            Console.ReadKey();
        }

        public static int[] RotateLeft(int[] x,int pivot)
        {
            if (pivot < 0 || x == null || x.Length < 1)
                throw new Exception("Invalid argument");

            //Rotate first half
            x = Reverse(x, 0, pivot - 1);
            //Rotate second half
            x = Reverse(x, pivot, x.Length - 1);
            //Rotate all
            x = Reverse(x, 0, x.Length - 1);

            return x;
        }

        private static int[] Reverse(int[] x, int start, int end)
        {
            while(start<end)
            {
                int temp = x[start];
                x[start] = x[end];
                x[end] = temp;

                start++;
                end--;

            }

            return x;
        }
    }
}
