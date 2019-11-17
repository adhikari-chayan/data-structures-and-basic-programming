using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourNumberSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 7, 6, 4, -1, 1, 2 };
            var target = 16;

            var result = FourNumberSum(input, target);
            foreach(var item in result)
            {
                Console.WriteLine($"{item[0]},{item[1]},{item[2]},{item[3]}");
            }
            Console.ReadKey();
        }

        public static List<int[]> FourNumberSum(int[] arr,int target)
        {
            List<int[]> quadruplets = new List<int[]>();
            Dictionary<int, List<int[]>> allPairSums = new Dictionary<int, List<int[]>>();

            for(var i=0;i<arr.Length-1;i++)
            {
                for(var j=i+1;j<arr.Length;j++)
                {
                    var currentSum = arr[i] + arr[j];
                    var difference = target - currentSum;
                    if(allPairSums.ContainsKey(difference))
                    {
                        foreach(int[] pair in allPairSums[difference])
                        {
                            int[] newQuadruplet = new int[] { pair[0], pair[1], arr[i], arr[j] };
                            quadruplets.Add(newQuadruplet);
                        }
                    }
                }
                for(var k=0;k<i;k++)
                {
                    var currentSumForBeforeElements = arr[k] + arr[i];
                    int[] pair = new int[] { arr[k], arr[i] };

                    if(!allPairSums.ContainsKey(currentSumForBeforeElements))
                    {
                        List<int[]> pairGroup = new List<int[]>();
                        pairGroup.Add(pair);
                        allPairSums.Add(currentSumForBeforeElements, pairGroup);
                    }
                    else
                    {
                        allPairSums[currentSumForBeforeElements].Add(pair);
                    }
                }
            }

            return quadruplets;
        }

        public static List<int[]> FourNumberSumBruteForce(int[] arr, int target)
        {
            List<int[]> quadruplets = new List<int[]>();
            for(var i=0;i<arr.Length-3;i++)
            {
                for(var j=i+1;j<arr.Length-2;j++)
                {
                    for(var k=j+1;k<arr.Length-1;k++)
                    {
                        for(var l = k + 1; l < arr.Length; l++)
                        {
                            var sum = arr[i] + arr[j] + arr[k] + arr[l];
                            if(sum==target)
                            {
                                int[] newQuadruplet = new int[] {  arr[i], arr[j],arr[k],arr[l] };
                                quadruplets.Add(newQuadruplet);
                            }
                        }
                    }
                }
            }

            return quadruplets;
        }
    }
}
