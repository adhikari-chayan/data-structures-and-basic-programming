using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 0, 1, 21, 33, 45, 45, 45, 45, 45, 45, 61, 71, 73 };
            var result = SearchForRangeRecursive(input, 45);
            foreach(var item in result)
                Console.WriteLine(item);

            Console.ReadKey();
        }

        public static int[] SearchForRangeRecursive(int[] array,int target)
        {
            int[] finalRange = new int[] { -1, -1 };
            AlteredBinarySearch(array, target, 0, array.Length - 1, finalRange, true);
            AlteredBinarySearch(array, target, 0, array.Length - 1, finalRange, false);

            return finalRange;

        }

        private static void AlteredBinarySearch(int[] array, int target, int left, int right, int[] finalRange, bool goLeft)
        {
            if (left > right)
                return;

            int mid = (left + right) / 2;
            if(array[mid]==target)
            {
                if(goLeft)
                {
                    if(mid==0||array[mid-1]!=target)
                    {
                        finalRange[0] = mid;
                    }
                    else
                    {
                        AlteredBinarySearch(array, target, left, mid - 1, finalRange, goLeft);
                    }
                }
                else
                {
                    if(mid==array.Length-1||array[mid+1]!=target)
                    {
                        finalRange[1] = mid;
                    }
                    else
                    {
                        AlteredBinarySearch(array, target, mid + 1, right, finalRange, goLeft);
                    }
                }
            }
            else if(array[mid]<target)
            {
                AlteredBinarySearch(array, target, mid + 1, right, finalRange, goLeft);
            }
            else
            {
                AlteredBinarySearch(array, target, left, mid - 1, finalRange, goLeft);
            }
        }
    }
}
