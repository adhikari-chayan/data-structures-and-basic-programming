using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverSizes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[,] {
                   {1,0,0,1,0 },
                   {1,0,1,0,0 },
                   {0,0,1,0,1 },
                   {1,0,1,0,1 },
                   {1,0,1,1,0 }
            };

            var result = RiverSizes(input);

            foreach(var item in result)
                Console.Write(item+" ");

            Console.ReadKey();
        }

        public static List<int> RiverSizes(int[,] matrix)
        {
            List<int> sizes = new List<int>();
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            bool[,] visited = new bool[row, col];

            for(int i=0;i<row;i++)
            {
                for(int j=0;j<col;j++)
                {
                    if (visited[i, j])
                        continue;

                    TraverseNodes(i, j, matrix, visited, sizes);
                }
            }
            return sizes;
        }

        private static void TraverseNodes(int i, int j, int[,] matrix, bool[,] visited, List<int> sizes)
        {
            int currentRiverSize = 0;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { i, j });
            while(queue.Count!=0)
            {
                int[] currentNode = queue.Dequeue();
                i = currentNode[0];
                j = currentNode[1];
                if (visited[i, j])
                    continue;

                visited[i, j] = true;
                if (matrix[i, j] == 0)
                    continue;

                currentRiverSize++;
                List<int[]> unvisitedNeighbours = GetUnvisitedNeighbours(i, j, matrix, visited);
                foreach(int[] neighbour in unvisitedNeighbours)
                {
                    queue.Enqueue(neighbour);
                }
            }
            if (currentRiverSize > 0)
                sizes.Add(currentRiverSize);

        }

        private static List<int[]> GetUnvisitedNeighbours(int i, int j, int[,] matrix, bool[,] visited)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            List<int[]> unvisitedNeighbours = new List<int[]>();
            List<List<int>> directions = new List<List<int>> { new List<int> { 0, 1 }, new List<int> { 0, -1 }, new List<int> { 1, 0 }, new List<int> { -1, 0 } };
            foreach(var direction in directions)
            {
                int x = i + direction[0];
                int y = j + direction[1];
                if ( x < 0 || x >= row || y < 0 || y >= col|| visited[x, y])
                    continue;
                unvisitedNeighbours.Add(new int[] { x, y });
            }

            return unvisitedNeighbours;
        }
    }
}
