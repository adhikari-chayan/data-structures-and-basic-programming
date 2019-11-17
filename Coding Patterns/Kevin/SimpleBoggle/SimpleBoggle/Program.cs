using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBoggle
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new[,] {
                   {'y', 'g', 'f', 'y', 'e', 'i'},
                   {'c', 'o', 'r', 'p', 'o', 'u'},
                   {'j', 'u', 'z', 's', 'e', 'l'},
                   {'s', 'y', 'u', 'r', 'h', 'p'},
                   {'e', 'a', 'e', 'g', 'n', 'd'},
                   {'h', 'e', 'l', 's', 'a', 't'},
            };
            var word = "help";

            var result = SimpleBoggle(board, word);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static bool SimpleBoggle(char[,] board, string word)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);
            
            for(int i=0;i<row;i++)
            {
                for(int j=0;j<col;j++)
                {
                    if (board[i, j] == word[0] && Dfs(i, j, board, 0, word))
                        return true;
                }
            }
            return false;

        }

        private static bool Dfs(int i, int j, char[,] board, int count, string word)
        {

            if (count == word.Length)
                return true;

            int row = board.GetLength(0);
            int col = board.GetLength(1);

            if (i < 0 || i >= row || j < 0 || j >= col || board[i, j] != word[count])
                return false;

            char temp = board[i, j];
            board[i, j] = ' ';

            bool found = Dfs(i + 1, j, board, count + 1, word) || Dfs(i - 1, j, board, count + 1, word) || Dfs(i, j + 1, board, count + 1, word) || Dfs(i, j - 1, board, count + 1, word)|| Dfs(i + 1, j+1, board, count + 1, word)|| Dfs(i - 1, j+1, board, count + 1, word)|| Dfs(i + 1, j-1, board, count + 1, word)|| Dfs(i - 1, j-1, board, count + 1, word);

            board[i, j] = temp;
            return found;
        }
    }
}
