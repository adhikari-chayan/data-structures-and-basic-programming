using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleCycleCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 2, 3, 1, -4, -4, 2 };
            var result = HasSingleCycle(input);
            Console.WriteLine(result);
            Console.ReadKey();

        }

        public static bool HasSingleCycle(int[] array)
        {
            int currentIdx = 0;
            int numVisitedElements = 0;
            while(numVisitedElements < array.Length)
            {
                if (numVisitedElements > 0 && currentIdx == 0)
                    return false;

                numVisitedElements++;
                currentIdx = GetNextIndex(currentIdx, array);
            }

            return currentIdx == 0;
        }

        private static int GetNextIndex(int currentIdx, int[] array)
        {
            int jump = array[currentIdx];
            int nextIdx = (currentIdx + jump) % array.Length;
            return nextIdx >= 0 ? nextIdx : nextIdx + array.Length;
        }
    }
}
