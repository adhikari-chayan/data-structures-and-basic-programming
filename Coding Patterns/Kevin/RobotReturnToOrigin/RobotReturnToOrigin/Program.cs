using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotReturnToOrigin
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "LL";
            var result = Judge(input);
            Console.WriteLine(result);
            Console.ReadKey();

        }

        public static bool Judge(string moves)
        {
            //U is complement of D
            int UD = 0;//UD is +1 for moving up and -1 for moving down
            //L is complement of R
            int LR = 0;//LR is +1 for moving left and -1 for moving right

            for(var i=0;i<moves.Length;i++)
            {
                var currentMove = moves[i];
                if (currentMove == 'U')
                    UD++;
                else if (currentMove == 'D')
                    UD--;
                else if (currentMove == 'L')
                    LR++;
                else if (currentMove == 'R')
                    LR--;
            }

            return UD == 0 && LR == 0;
        }
    }
}
