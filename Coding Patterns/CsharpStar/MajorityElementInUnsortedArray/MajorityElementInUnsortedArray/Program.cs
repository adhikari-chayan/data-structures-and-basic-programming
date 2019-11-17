using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorityElementInUnsortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2, 3, 4, 5, 2, 2, 2, 2};
            var result = FindMajorElement(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static int FindMajorElement(int[] input)
        {
            int majorityCount = 0;
            int result = int.MinValue;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i=0;i<input.Length;i++)
            {
                if (dict.ContainsKey(input[i]))
                {
                    dict[input[i]]++;
                    if (majorityCount < dict[input[i]])
                    {
                        result = input[i];
                        majorityCount = dict[input[i]];
                    }
                }
                else
                    dict.Add(input[i], 1);
            }

            return result;
        }
    }
}
