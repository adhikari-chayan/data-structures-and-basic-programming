using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.geeksforgeeks.org/array-rotation/
namespace LeftRotate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            LeftRotateArray(arr, 2, arr.Length);
            //LeftRotateArrayByOne(arr, arr.Length);
            PrintArray(arr);
            Console.ReadKey();
        }

        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }

        private static void LeftRotateArray(int[] arr, int d, int n)
        {
           
            for(var i=0;i<d;i++)
            {
                LeftRotateArrayByOne(arr, arr.Length);
            }

            //Alternate by reverse algorithm

            //int n = arr.Length;
            //RvereseArray(arr, 0, d - 1);
            //RvereseArray(arr, d, n - 1);
            //RvereseArray(arr, 0, n - 1);
            

        }

        private static void LeftRotateArrayByOne(int[] arr, int length)
        {
            int temp = arr[0];
            int i;//imp(i declared earlier so that it can hold final value of i outside loop)
                        //imp(length-1 instead of length)
            for(i=0;i<length-1;i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[i] = temp;

        
        }

        private static void ReverseArray(int[] arr, int start, int end)
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
        }
    }
}
