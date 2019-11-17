using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.geeksforgeeks.org/program-for-array-rotation-continued-reversal-algorithm/
namespace ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            ReverseArray(arr,0,arr.Length-1);
            PrintArray(arr);
            Console.ReadKey();
        }

        private static void ReverseArray(int[] arr,int start,int end)
        {
            
            int temp;
            while (start < end)
            {
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }

							//imp(loop only till half the length)
            //for(var i=0;i<arr.Length/2;i++)
            //{
            //    temp = arr[i];
            //    arr[i] = arr[arr.Length - 1 - i];
            //    arr[arr.Length - 1 - i] = temp;
            //}
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }
    }
}
