using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSelect
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int QuickSelect(int [] array,int k)
        {
           int position = k - 1;
           return QuickSelect(array, 0, array.Length - 1, position);
        }

        private static int QuickSelect(int[] array, int startIdx, int endIdx, int position)
        {
            while (true)
            {
                if (startIdx > endIdx)
                    throw new Exception("invalid operation");

                int pivotIdx = startIdx;
                int leftIdx = startIdx + 1;
                int rightIdx = endIdx;

                while (rightIdx >= leftIdx)
                {
                    if (array[leftIdx] > array[pivotIdx] && array[rightIdx] < array[pivotIdx])
                    {
                        Swap(leftIdx, rightIdx, array);
                    }
                    if (array[leftIdx] <= array[pivotIdx])
                        leftIdx++;
                    if (array[rightIdx] >= array[pivotIdx])
                        rightIdx++;
                }
                Swap(pivotIdx, rightIdx, array);

                if (rightIdx == position)
                {
                    return array[rightIdx];
                }
                else if (rightIdx < position)
                    startIdx = rightIdx + 1;
                else
                    endIdx = rightIdx - 1;
            }
        }

        private static void Swap(int i, int j, int[] array)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] =temp;
        }
    }
}
