using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 5, 2, 9, 5, 6, 3 };
            var result = BubbleSort(input);
            foreach(var item in result)
                Console.Write(item+" ");

            Console.ReadKey();
        }

        public static int[] BubbleSort(int[] arr)
        {
            if (arr.Length == 0)
                return new int[] { };

            int counter = 0;
            bool isSorted = false;
            while(!isSorted)
            {
                isSorted = true;
                for(var i=0;i<arr.Length-1-counter;i++)
                {
                    if(arr[i]>arr[i+1])
                    {
                        Swap(i, i + 1, arr);
                        isSorted = false;
                    }
                }
                counter++;
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
