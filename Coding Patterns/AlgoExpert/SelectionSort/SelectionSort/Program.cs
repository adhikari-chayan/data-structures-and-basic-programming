using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 5, 2, 9, 5, 6, 3 };
            var result = SelectionSort(input);
            foreach(var item in result)
                Console.Write(item+" ");

            Console.ReadKey();
        }

        public static int[] SelectionSort(int[] arr)
        {
            if (arr.Length == 0)
                return new int[] { };

            for(int startIndex=0;startIndex<arr.Length-1;startIndex++)
            {
                int smallestIdx = startIndex;
                for(int i=startIndex+1;i<arr.Length;i++)
                {
                    if(arr[smallestIdx] > arr[i])
                    {
                        smallestIdx = i;
                    }
                    
                }
                Swap(startIndex, smallestIdx, arr);

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
