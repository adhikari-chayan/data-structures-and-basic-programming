using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairWithMaxAppealSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 6, 2, 7, 4, 4, 1, 6 };
            var result = FindPairWithMaxAppeal(input);
            foreach (var item in result)
                Console.WriteLine(item);
            Console.ReadKey();
        }


        
        public static int[] FindPairWithMaxAppeal(int[] arr)
        {
            int maxVal = int.MinValue;
            int currVal = 0;
            int left = 0;
            int right = arr.Length - 1;
            int[] result = new int[] { -1, -1 };

            while(left<right)
            {
               

                if(arr[left] < arr[right])
                {
                    currVal = arr[left] + arr[right] + Math.Abs(right - left);
                    if (currVal > maxVal)
                    {
                        result[0] = left;
                        result[1] = right;
                    }
                    left++;
                }
                else
                {
                    currVal = arr[right] + arr[left] + Math.Abs(right - left);
                    if (currVal > maxVal)
                    {
                        result[0] = left;
                        result[1] = right;
                    }
                    right--;
                }

               
                maxVal = Math.Max(maxVal, currVal);
            }

            return result;
        }

        //A[i] +A[j] + abs(i-j)
        //= A[i] +A[j] +(i-j) = (A[i]+i) + (A[j]-j)
        //= A[i] +A[j] - (i-j) = (A[i]-i) + (A[j]+j)
        //Since we are allowed to have same i = j, so just find the max value of each(A[i]-i), (A[i]+i).


        public static int[] MaxAppealPair(int[] arr)
        {
            if (arr == null || arr.Length == 0) return new int[] { -1, -1 };

            int max1 = int.MinValue, max2 = int.MinValue;
            int m1 = -1, m2 = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                int curr1 = arr[i] + i;
                int curr2 = arr[i] - i;

                if (curr1 > max1)
                {
                    max1 = curr1;
                    m1 = i;
                }
                if (curr2 > max2)
                {
                    max2 = curr2;
                    m2 = i;
                }
            }
            return new int[] { m2, m1 };
        }
    }
}
