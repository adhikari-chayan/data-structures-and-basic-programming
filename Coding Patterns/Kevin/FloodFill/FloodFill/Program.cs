using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFill
{
    class Program
    {

        //https://leetcode.com/problems/flood-fill/
        static void Main(string[] args)
        {
        }

        public static int[,] FloodFill(int[,] image,int sr,int sc,int newColor)
        {
            if (image[sr, sc] == newColor)
                return image;
            else
                Fill(image, sr, sc, image[sr, sc], newColor);

            return image;
        }

        private static void Fill(int[,] image, int i, int j, int color, int newColor)
        {
            if (i < 0 || i >= image.GetLength(0) || j < 0 || j >= image.GetLength(1) || image[i, j] != color)
                return;

            Fill(image, i + 1, j, color, newColor);//Down
            Fill(image, i - 1, j, color, newColor);//Up
            Fill(image, i, j + 1, color, newColor);//right
            Fill(image, i, j - 1, color, newColor);//left

        }
    }
}
