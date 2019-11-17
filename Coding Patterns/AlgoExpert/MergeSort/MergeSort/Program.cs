using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 5, 2, 9, 5, 6, 3 };
            var result = MergeSort(input);
            foreach(var item in result)
                Console.Write(item + " ");

            Console.ReadKey();
        }

        public static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return array;

            int midIdx = array.Length / 2;
            int[] leftHalf = CopyOfRange(array, 0, midIdx);
            int[] rightHalf = CopyOfRange(array, midIdx, array.Length);
            return MergeSortedArrays(MergeSort(leftHalf), MergeSort(rightHalf));
            
        }

        private static int[] MergeSortedArrays(int[] leftHalf, int[] rightHalf)
        {
            int[] sortedArray = new int[leftHalf.Length + rightHalf.Length];
            int i = 0;
            int j = 0;
            int k = 0;

            while(i<leftHalf.Length && j<rightHalf.Length)
            {
                if(leftHalf[i]<=rightHalf[j])
                {
                    sortedArray[k] = leftHalf[i];
                    k++;
                    i++;
                }
                else
                {
                    sortedArray[k] = rightHalf[j];
                    k++;
                    j++;
                }
            }
            while(i<leftHalf.Length)
            {
                sortedArray[k] = leftHalf[i];
                k++;
                i++;
            }
            while(j<rightHalf.Length)
            {
                sortedArray[k] = rightHalf[j];
                k++;
                j++;
            }

            return sortedArray;
        }

        private static int[] CopyOfRange(int[] src, int start, int end)
        {
            int len = end - start;
            int[] dest = new int[len];
            Array.Copy(src, start, dest, 0, len);
            return dest;
        }
    }
}
