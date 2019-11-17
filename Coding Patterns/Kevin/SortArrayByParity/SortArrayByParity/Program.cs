using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayByParity
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 3, 1, 2, 4 };
            var result = SortByParity(input);
            foreach(var item in result)
                Console.Write(item+ " ");
            Console.ReadKey();
        }

        public static int[] SortByParity(int[] arr)
        {
            int index = 0;
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]%2==0)
                {
                    int temp = arr[index];
                    arr[index] = arr[i];
                    arr[i] = temp;
                    index++;
                }
            }
            return arr;
        }
    }
}
