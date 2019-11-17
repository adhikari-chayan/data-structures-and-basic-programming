using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.geeksforgeeks.org/given-an-array-a-and-a-number-x-check-for-pair-in-a-with-sum-as-x/
namespace TwoElementsInArrayHavingSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 45, 6, 10, -8 };
            int sum = 16;
            

            if (HasArrayTwoCandidates(arr,sum))
                Console.Write("Array has two elements" +
                            " with given sum");
            else
                Console.Write("Array doesn't have " +
                           "two elements with given sum");

            Console.WriteLine();

            HasArrayTwoCandidatesUsingHashSet(arr, sum);
            Console.ReadKey();
        }

        private static bool HasArrayTwoCandidates(int[] arr, int sum)
        {
            Array.Sort(arr);
            int start, end;

            start = 0;
            end = arr.Length - 1;
            while(start < end)
            {
                if (arr[start] + arr[end] == sum)
                    return true;
                else if ((arr[start] + arr[end]) < sum)//*imp
                    start++;//*imp
                else
                    end--;//*imp
            }
            return false;
        }

        private static void HasArrayTwoCandidatesUsingHashSet(int[] arr, int sum)
        {
            HashSet<int> s = new HashSet<int>();
            for(var i=0;i<arr.Length;i++)
            {
                int temp = sum - arr[i];//*imp
                if(temp >= 0 && s.Contains(temp))//*imp
                {
                    Console.Write("Pair with given sum " +sum + " is (" + arr[i] +", " + temp + ")");//*imp
                }
                s.Add(arr[i]);
            }
        }
    }
}
