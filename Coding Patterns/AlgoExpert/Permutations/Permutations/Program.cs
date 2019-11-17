using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<int> { 1, 2, 3 };
            var result = GetPermutations(input);
            foreach(var permutation in result)
            {
                foreach(var item in permutation)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static List<List<int>> GetPermutations(List<int> arr)
        {
            List<List<int>> permutations = new List<List<int>>();
            GetPermutations(arr, new List<int>(), permutations);
            return permutations;
        }

        private static void GetPermutations(List<int> arr, List<int> currentPermutation, List<List<int>> permutations)
        {
            if(arr.Count == 0)
            {
                permutations.Add(currentPermutation);
            }
            else
            {
                for(var i=0;i<arr.Count;i++)
                {
                    List<int> newArray = new List<int>(arr);
                    newArray.Remove(arr[i]);
                    List<int> newPermutation = new List<int>(currentPermutation);
                    newPermutation.Add(arr[i]);

                    GetPermutations(newArray, newPermutation, permutations);    
                }
            }
        }
    }
}
