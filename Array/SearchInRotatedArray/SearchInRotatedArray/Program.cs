using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.geeksforgeeks.org/search-an-element-in-a-sorted-and-pivoted-array/
namespace SearchInRotatedArray
{

   // 1.The idea is to find the pivot point, divide the array in two sub-arrays and call binary search.
   // 2.The main idea for finding pivot is – for a sorted(in increasing order) and pivoted array, pivot element is the only element for which next element to it is smaller than it.
    class Program
    {
        static void Main(string[] args)
        {
            // Let us search 3 in below array 
            int[] arr1 = { 5, 6, 7, 8, 9, 10, 1, 2, 3 };
            int n = arr1.Length;
            int key = 2;
            Console.Write($"Index of the element is :{PivotedBinarySearch(arr1, n, key)}"
                         );

            Console.ReadKey();
        }

        private static int PivotedBinarySearch(int[] arr, int n, int key)
        {
            int pivot = FindPivot(arr, 0, n - 1);
            //If we didn't find a pivot, then 
            // array is not rotated at all 
            if (pivot == -1)
                return BinarySearch(arr, key,0, n - 1);

            // If we found a pivot, then first 
            // compare with pivot and then 
            // search in two subarrays around pivot 
            if (arr[pivot] == key)
                return pivot;

            if (arr[0] <= key)//*imp
                return BinarySearch(arr, key, 0, pivot - 1 );

            return BinarySearch(arr, key, pivot + 1, n - 1);
        }

        public static int BinarySearch(int[] arr,int key,int min,int max)
        {
            //Array.Sort(arr);
            if (min > max)
                return -1;

            int mid = (min + max) / 2;
            if (key == arr[mid])
                return mid;

            else if (key < arr[mid])
                return BinarySearch(arr, key, min, mid - 1);
            else
                return BinarySearch(arr, key, mid + 1, max);

        }

        public static int FindPivot(int[] arr,int min,int max)
        {
            // base cases 
            if (max < min)
                return -1;
            if (max == min)
                return min;

            /* low + (high - low)/2; */
            int mid = (min + max) / 2;

            if (mid < max && arr[mid] > arr[mid + 1])
                return mid;

            if (mid > min && arr[mid] < arr[mid - 1])
                return (mid - 1);

            if (arr[min] >= arr[mid])
                return FindPivot(arr, min, mid - 1);

            return FindPivot(arr, mid + 1, max);

            //inefficient way of finding pivot
            //for (var i = 0; i < arr.Length - 1; i++)
            //{
            //    if (arr[i] > arr[i + 1])
            //        return i;
            //}
            //return -1;
        }
    }
}
