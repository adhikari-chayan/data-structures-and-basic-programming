using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 5, 2, 9, 5, 6, 3 };
            var result = QuickSort(input);
            foreach (var item in result)
                Console.Write(item + " ");

            Console.ReadKey();
        }

        public static int[] QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
            return arr;
        }
        public static void QuickSort(int[] arr, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx)
                return;
            int pivotIdx = startIdx;
            int leftIdx = startIdx + 1;
            int rightIdx = endIdx;
            while (rightIdx >= leftIdx)
            {
                if(arr[leftIdx] > arr[pivotIdx] && arr[rightIdx] < arr[pivotIdx])
                {
                    Swap(leftIdx, rightIdx, arr);
                }
                if(arr[leftIdx] <= arr[pivotIdx])
                {
                    leftIdx++;
                }
                if(arr[rightIdx] > arr[pivotIdx])
                {
                    rightIdx--;
                }
            }
            Swap(pivotIdx, rightIdx, arr);
            //Perform Quicksort on the smaller sub array. this will ensure that the Space compexity remains O(logn)
            //Size is calculated by subtracting star end end index of the two subarrays on either side of the right index(which is where the pivot was moved to)
            bool leftSubArrayIsSmaller = (rightIdx - 1) - startIdx < endIdx - (rightIdx + 1);
            if(leftSubArrayIsSmaller)
            {
                QuickSort(arr, startIdx, rightIdx - 1);
                QuickSort(arr, rightIdx + 1, endIdx);
            }
            else
            {
                QuickSort(arr, rightIdx + 1, endIdx);
                QuickSort(arr, startIdx, rightIdx - 1);
            }
        }

        private static void Swap(int i, int j, int[] arr)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}

