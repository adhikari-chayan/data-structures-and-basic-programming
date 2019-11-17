using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = new int[] { -1, 5, 10, 20, 28, 3 };
            var input2 = new int[] { 26, 134, 135, 15, 17 };
            var result = SmallestDifference(input1, input2);

            foreach(var item in result)
                Console.WriteLine(item);

            Console.ReadKey();
        }

        public static int[] SmallestDifference(int[] arr1,int[] arr2)
        {
            Array.Sort(arr1);
            Array.Sort(arr2);

            int idxOne = 0;
            int idxTwo = 0;
            int[] smallestPair = new int[2];

            int smallestDifference = int.MaxValue;
            int currentDifference = int.MaxValue;

            while(idxOne < arr1.Length && idxTwo <arr2.Length)
            {
                int firstNum = arr1[idxOne];
                int secondNum = arr2[idxTwo];
                if (firstNum == secondNum)
                {
                    return new[] { firstNum, secondNum };
                }
                else if(firstNum < secondNum)
                {
                    currentDifference = secondNum - firstNum;
                    idxOne++;
                }
                else
                {
                    currentDifference = firstNum - secondNum;
                    idxTwo++;
                }
                if(smallestDifference> currentDifference )
                {
                    smallestDifference = currentDifference;
                    smallestPair = new[] { firstNum, secondNum };
                }
            }

            return smallestPair;
        }
    }
}
