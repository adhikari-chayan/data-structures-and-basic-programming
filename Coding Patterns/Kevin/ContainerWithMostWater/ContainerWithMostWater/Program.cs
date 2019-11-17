using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerWithMostWater
{
    class Program
    {
        //https://leetcode.com/problems/container-with-most-water/description/
        static void Main(string[] args)
        {
            var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var result = MaxArea(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int MaxArea(int[] heights)
        {
            int maxArea = int.MinValue;
            for(int i = 0;i<heights.Length-1;i++)
            {
                for(int j=i+1;j<heights.Length;j++)
                {
                    int minHeightBetweenTwo = Math.Min(heights[i], heights[j]);
                    maxArea = Math.Max(maxArea, minHeightBetweenTwo * (j - i));
                }
            }
            return maxArea;
        }

        public static int MaxAreaAlternate(int[] heights)
        {
            int maxArea = int.MinValue;
            int left = 0;
            int right = heights.Length - 1;
            while(left<right)
            {
                int minHeightBetweenTwo = Math.Min(heights[left], heights[right]);
                maxArea = Math.Max(maxArea, minHeightBetweenTwo * (right - left));

                //the lower one in height is the limiting factor so pointer of the lower one is moved to centre in search for higher one
                if (heights[left] < heights[right])
                    left++;
                else
                    right--;

            }
            return maxArea;
        }
    }
}
