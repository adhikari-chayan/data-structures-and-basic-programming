using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<int> { 1, 2, 3 };
            var result = GetPowerSet(input);
            foreach (var subset in result)
            {
                subset.ForEach(s => Console.Write(s));
                Console.WriteLine();
            }

            Console.ReadKey();

            
        }

        public static List<List<int>> GetPowerSet(List<int> array)
        {
            List<List<int>> subsets = new List<List<int>>();
            subsets.Add(new List<int>());
            foreach (int element in array)
            {
                int length = subsets.Count;
                for(int i=0;i<length;i++)
                {
                    //List<int> newSubset = new List<int>();
                    //newSubset=newSubset.Concat(subsets[i]).ToList();
                    //newSubset.Add(element);
                    //subsets.Add(newSubset);

                    List<int> newSubset = new List<int>(subsets[i]);
                    newSubset.Add(element);
                    subsets.Add(newSubset);
                }
            }
            return subsets;
            
        }
    }
}
