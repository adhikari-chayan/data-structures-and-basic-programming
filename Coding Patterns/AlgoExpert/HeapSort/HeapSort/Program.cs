using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 5, 2, 9, 5, 6, 3 };
            var result = HeapSort(input);
            foreach(var item in result)
            {
                Console.Write(item+" ");
            }

            Console.ReadKey();
        }

        public static int[] HeapSort(int[] arr)
        {
            BuildMaxHeap(arr);
            for(int endIndex=arr.Length-1;endIndex > 0;endIndex--)
            {
                Swap(0, endIndex, arr);
                ShiftDown(0, endIndex - 1, arr);
            }
            return arr;
        }

        private static void Swap(int i, int j, int[] arr)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static void ShiftDown(int currentIdx, int endIdx, int[] heap)
        {
            int childOneIdx = currentIdx * 2 + 1;
            while(childOneIdx<=endIdx)
            {
                int childTwoIdx = currentIdx * 2 + 2 <= endIdx ? currentIdx * 2 + 2 : -1;
                int idxToSwap;
                if(childTwoIdx!=-1 && heap[childTwoIdx]>heap[childOneIdx])
                {
                    idxToSwap = childTwoIdx;
                }
                else
                {
                    idxToSwap = childOneIdx;
                }
                if (heap[idxToSwap] > heap[currentIdx])
                {
                    Swap(currentIdx, idxToSwap, heap);
                    currentIdx = idxToSwap;
                    childOneIdx = currentIdx * 2 + 1;
                }
                else
                    return;
            }
        }

        private static void BuildMaxHeap(int[] arr)
        {
            int firstParentIdx = (arr.Length - 2) / 2;
            for(int currentIdx=firstParentIdx;currentIdx>=0;currentIdx--)
            {
                ShiftDown(currentIdx, arr.Length - 1, arr);
            }
        }
    }
}
