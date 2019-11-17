using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftedBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int ShiftedBinarySearchRecursive(int[] arr, int target)
        {
            return ShiftedBinarySearch(arr, target, 0, arr.Length - 1);
        }

        private static int ShiftedBinarySearch(int[] arr, int target, int left, int right)
        {
            if (left > right)
                return -1;

            int middle = (left + right) / 2;
            int potentialMatch = arr[middle];
            int leftNum = arr[left];
            int rightNum = arr[right];

            if (target == potentialMatch)
                return middle;
            //left side is sorted
            else if(leftNum <= potentialMatch)
            {
                if(target<potentialMatch && target >=leftNum)
                {
                   return ShiftedBinarySearch(arr, target, left, middle - 1);
                }
                else
                {
                   return ShiftedBinarySearch(arr, target, right, middle + 1);
                }
            }
            else//right side is sorted
            {
                if(target>potentialMatch && target<=rightNum)
                {
                   return ShiftedBinarySearch(arr, target, middle + 1, right);
                }
                else
                {
                    return ShiftedBinarySearch(arr, target, left, middle - 1);
                }
            }
        }

        public static int ShiftedBinarySearchIterative(int[] arr,int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while(left<=right)
            {
                int middle = (left + right) / 2;
                int potentialMatch = arr[middle];
                int leftNum = arr[left];
                int rightNum = arr[right];

                if (target == potentialMatch)
                    return middle;

                else if(leftNum <= potentialMatch)
                {
                    if(target >= leftNum && target< potentialMatch)
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                else
                {
                    if(target>=potentialMatch && target<rightNum)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
            }
            return -1;
        }
    }
}
