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
        }

        public static int BinarySearchRecursive(int[] arr,int target)
        {
            return BinarySearch(arr, target, 0,arr.Length-1);
        }

        private static int BinarySearch(int[] arr, int target, int left, int right)
        {
            if (left > right)
                return -1;
            int middle = (left + right) / 2;
            int potentialMatch = arr[middle];
            if (potentialMatch == target)
                return middle;
            else if (potentialMatch < target)
              return  BinarySearch(arr, target, middle + 1, right);
            else
              return  BinarySearch(arr, target, left, middle - 1);
        }

        public static int BinarySearchIterative(int[] arr,int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while(left<=right)
            {
                int middle = (left + right) / 2;
                int potentialMatch = arr[middle];
                if (potentialMatch == target)
                    return middle;
                else if (potentialMatch < target)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            return -1;
        }
    }
}
