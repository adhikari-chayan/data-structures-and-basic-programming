using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveObstacle
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[,] {
                   {1,0,0 },
                   {1,0,0 },
                   {1,9,1 }
            };

            var result = removeObstacle(3, 3, input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int removeObstacle(int numRows, int numColumns, int[,] lot)
        {
            //if parking lot has no data we return -1
            if (numRows == 0 || numColumns == 0 || lot[0, 0] == 0)
                return -1;
            //if the obstacle is in the starting position itself then no distance is traversed
            if (lot[0, 0] == 9)
                return 0;

            //We will apply BFS and hence we will use this queue to store coordinates for each element in lot array
            Queue<int[]> queue = new Queue<int[]>();
            //This is a list of possible directions traversed in one move. This will be needed in later calculations
            List<List<int>> directions = new List<List<int>> { new List<int> { 0, 1 }, new List<int> { 0, -1 }, new List<int> { 1, 0 }, new List<int> { -1, 0 } };
            //intializing the distance/steps counter
            int steps = 1;

            //adding the root node in queue as per visited
            queue.Enqueue(new int[] { 0, 0 });
            //Marking the visited node. We could have used another array to store reference to visited nodes,but I think this will save space.
            lot[0, 0] = 0;

            while (queue.Count != 0)
            {
                int size = queue.Count();

                for (int i = 0; i < size; ++i)
                {
                    //Taking out the node from the front of the queue
                    int[] pos = queue.Dequeue();
                    foreach (List<int> direction in directions)
                    {
                        //Calculating coordinates after first move
                        int x = pos[0] + direction[0];
                        int y = pos[1] + direction[1];

                        //Checking if the calculated coordinate of the move is trench or flat or outside of parking lot
                        if (x < 0 || x >= numRows || y < 0 || y >= numColumns || lot[x, y] == 0)
                            continue;
                        //If we find the obstacle we return the distance counter
                        if (lot[x, y] == 9)
                            return steps;
                        //putting the next node where the robot has moved succesfully to the queue
                        queue.Enqueue(new int[] { x, y });
                        //Marking the node as visited as mentioned above.
                        lot[x, y] = 0;
                    }
                }
                ++steps;
            }
            return -1;
        }
    }
}
