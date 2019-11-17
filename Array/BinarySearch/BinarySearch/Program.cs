using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 6, 7, 8, 9, 10, 1, 2, 3 };
            int key = 7;
            BinarySearchIterative(arr, key);
            //BinarySearchRecursive(arr, key,0,(arr.Length-1));
            Console.ReadKey();
        }

        private static void BinarySearchRecursive(int[] arr, int key,int min,int max)
        {
            Array.Sort(arr);
            if(min>max)
            {
                Console.WriteLine("Not Found");
                return;

            }
            else
            {
                int mid = (min + max) / 2;
                if(key==arr[mid])
                {
                    Console.WriteLine($"Element available at position {++mid}");
                    return;
                }
                else if(key<arr[mid])
                {
                    BinarySearchRecursive(arr, key, min, mid - 1);
                }
                else
                {
                    BinarySearchRecursive(arr, key, mid+1, max);
                }
            }
        }

        private static void BinarySearchIterative(int[] arr, int key)
        {
            Array.Sort(arr);
            int max = arr.Length - 1;
            int min = 0;

            while(min<=max)
            {
                int mid = (max + min) / 2;
                if(key==arr[mid])
                {
                    Console.WriteLine($"Element available at position {++mid}");
                    return;
                }

                else if(key < arr[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            Console.WriteLine("Not Found");
        }
    }
}
