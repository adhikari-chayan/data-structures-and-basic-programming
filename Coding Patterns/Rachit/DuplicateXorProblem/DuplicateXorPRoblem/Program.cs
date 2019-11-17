using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateXorProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 3, 4, 2, 3, 1, 4 };
            var result = FindNumberWithSingleOccurrenceUsingXor(input);

            Console.WriteLine(result);

            input = new int[] { 5,17,12,1,12,17,1 };
            //input = new int[] { 3,4,8,2,1,2,8,3 };//Algo fails as there are two elements that occur once
            result = FindNumberWithSingleOccurrenceUsingXor(input);

            Console.WriteLine(result);
            Console.WriteLine("--------------------------------------");
            input = new int[] { 3, 4, 8, 2, 1, 2, 8, 3 };
            
            var results = FindMultipleNumberWithSingleOccurenceUsingXor(input);
            foreach(var item in results)
                Console.WriteLine(item);


            Console.ReadKey();
        }

        /// <summary>
        /// O(n) space and time
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindNumberWithSingleOccurrence(int[] arr)
        {
            Dictionary<int, int> numCount = new Dictionary<int, int>();
            for(var i=0;i<arr.Length;i++)
            {
                if (numCount.ContainsKey(arr[i]))
                    numCount[arr[i]]++;
                else
                    numCount.Add(arr[i], 1);
            }
            return numCount.FirstOrDefault(kv => kv.Value == 1).Key;
        }

       /* Let us consider the above example.
        Let ^ be xor operator as in C and C++.

        res = 7 ^ 3 ^ 5 ^ 4 ^ 5 ^ 3 ^ 4

        Since XOR is associative and commutative, above
        expression can be written as:
        res = 7 ^ (3 ^ 3) ^ (4 ^ 4) ^ (5 ^ 5)
            = 7 ^ 0 ^ 0 ^ 0
            = 7 ^ 0
            = 7
            
        Space Complexity is O(1), time complexity is O(n)     
             */


        public static int FindNumberWithSingleOccurrenceUsingXor(int[] arr)
        {
            int res = arr[0];
            for(var i=1;i<arr.Length;i++)
            {
                res = res ^ arr[i];
            }

            
            return res;
        }

        public static int[] FindMultipleNumberWithSingleOccurenceUsingXor(int[] arr)
        {
            int res = arr[0];
            for (var i = 1; i < arr.Length; i++)
            {
                res = res ^ arr[i];
            }

            int k = FindkthPositionThatHasBitTurnedOn(res);

            //variable that holds XOR of elements for which kth element is turned to 1
            int a = 0;
            //variable that holds XOR of elements for which kth element is not turned to 1
            int b = 0;


            if (FindkthPositionThatHasBitTurnedOn(arr[0]) == k)
                a = arr[0];
            else
                b = arr[0];
            for (var i = 1; i < arr.Length; i++)
            {
                if (FindkthPositionThatHasBitTurnedOn(arr[i]) == k)
                    a = a ^ arr[i];
                else
                    b = b ^ arr[i]; 
            }
            return new int[] { a, b };
        }
         

        

        private static int FindkthPositionThatHasBitTurnedOn(int res)
        {
            string binary = Convert.ToString(res, 2);
            binary = new string('0', 8 - binary.Length) + binary;
            char[] bitArray = binary.ToArray();
            int k = 0; //kth bit which is turned to 1
            for (int i = 0; i < bitArray.Length; i++)
            {
                if (bitArray[i] == '1')
                {
                    k = i;
                    break;
                }
            }

            return k;
        }

      

        // Function to find the elements that  
        // appeared only once in the array 
        //Time Complexity: O(Nlogn)
        //Space Complexity: O(1)
        static void occurredOnce(int[] arr, int n)
        {
            // Sort the array 
            Array.Sort(arr);

            // Check for first element 
            if (arr[0] != arr[1])
                Console.Write(arr[0] + " ");

            // Check for all the elements  
            // if it is different 
            // its adjacent elements 
            for (int i = 1; i < n - 1; i++)
                if (arr[i] != arr[i + 1] &&
                    arr[i] != arr[i - 1])
                    Console.Write(arr[i] + " ");

            // Check for the last element 
            if (arr[n - 2] != arr[n - 1])
                Console.Write(arr[n - 1] + " ");
        }
    }
}
