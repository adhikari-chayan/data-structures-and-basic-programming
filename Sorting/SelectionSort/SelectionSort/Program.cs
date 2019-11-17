using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n;
            int[] a = new int[20];

            Console.Write("Enter the number of elements: ");
            n = Convert.ToInt32(Console.ReadLine());

            for(i=0;i<n;i++)
            {
                Console.Write("Enter element "+(i+1)+" :");
                a[i]= Convert.ToInt32(Console.ReadLine());
            }

            Sort(a, n);
            Console.WriteLine("Sorted array is: ");

            for(i=0;i<n;i++)
                Console.Write(a[i]+" ");

            Console.WriteLine();
            Console.ReadKey();
        }

        private static void Sort(int[] a, int n)
        {
            //minIndex is the index of the smallest element in the rest of the array that needs to be swapped with i
            int minIndex, i, j, temp;
            for (i=0;i<n-1;i++)
            {
                minIndex = i;
                for(j=i+1;j<n;j++)
                {
                    if (a[j] < a[minIndex])
                        minIndex = j;
                }
                if(i!=minIndex)
                {
                    temp = a[i];
                    a[i] = a[minIndex];
                    a[minIndex] = temp;
                }

            }
        }
    }
}
