using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 5, 2, 9, 5, 6, 3 };
            var result = InsertionSort(input);
            foreach (var item in result)
                Console.Write(item + " ");

            Console.ReadKey();
        }

        public static int[] InsertionSort(int[] arr)
        {
            if (arr.Length == 0)
                return new int[] { };
            for(var i=1;i<arr.Length; i++)
            {
                int j = i;
                while(j>0 && arr[j]<arr[j-1])
                {
                    Swap(j, j - 1, arr);
                    j--;
                }
            }
            return arr;
        }

        private static void Swap(int i, int j, int[] arr)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
