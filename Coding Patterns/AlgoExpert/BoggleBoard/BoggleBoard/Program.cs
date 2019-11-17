using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleBoard
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

            var words = new string[] { "san", "sana", "at", "vomit", "yours", "help", "end", "been", "bed", "danger", "calm", "ok", "chaos", "complete", "rear", "going", "storm", "face", "epual", "dangerous" };

            var result = BoggleBoard(board, words);
            foreach(var word in result)
            {
                Console.WriteLine(word);
            }

            Console.ReadKey();
        }

        public static List<string> BoggleBoard(char[,] board, string[] words)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);

            Trie trie = new Trie();
            foreach(var word in words)
            {
                trie.Add(word);
            }

            Dictionary<string, bool> finalWords = new Dictionary<string, bool>();
            bool[,] visited = new bool[row, col];

            for(var i=0;i<row;i++)
            {
                for(var j=0;j<col;j++)
                {
                    Explore(i, j, board,trie.root ,visited, finalWords); 
                }
            }

            List<string> finalWordsArray = new List<string>();
            foreach(string key in finalWords.Keys)
            {
                finalWordsArray.Add(key);
            }

            return finalWordsArray;
        }

        private static void Explore(int i, int j, char[,] board,TrieNode trieNode ,bool[,] visited, Dictionary<string, bool> finalWords)
        {
            if(visited[i,j])
            {
                return;
            }

            char letter = board[i, j];
            if (!trieNode.children.ContainsKey(letter))
                return;

            visited[i, j] = true;
            trieNode = trieNode.children[letter];
            if(trieNode.children.ContainsKey('*'))
            {
                finalWords.Add(trieNode.word, true);
            }

            List<int[]> neighbours = GetNeighbours(i, j, board);
            foreach(var neighbour in neighbours)
            {
                Explore(neighbour[0], neighbour[1], board, trieNode, visited, finalWords);
            }

            visited[i, j] = false;
        }

        private static List<int[]> GetNeighbours(int i, int j, char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);
            List<int[]> neighbours = new List<int[]>();
            List<List<int>> directions = new List<List<int>> { new List<int> { 0, 1 }, new List<int> { 0, -1 }, new List<int> { 1, 0 }, new List<int> { -1, 0 }, new List<int> { -1, -1 }, new List<int> { -1, 1 }, new List<int> { 1, -1 }, new List<int> { 1, 1 } };
            foreach (var direction in directions)
            {
                int x = i + direction[0];
                int y = j + direction[1];
                if (x < 0 || x >= row || y < 0 || y >= col)
                    continue;
                neighbours.Add(new int[] { x, y });
            }

            return neighbours;
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public string word = "";
        }

        public class Trie
        {
            public TrieNode root;
            char endSymbol;

            public Trie()
            {
                this.root = new TrieNode();
                this.endSymbol = '*';
            }

            public void Add(string str)
            {
                TrieNode node = this.root;
                for(int i=0;i<str.Length;i++)
                {
                    char letter = str[i];
                    if (!node.children.ContainsKey(letter))
                    {
                        TrieNode newNode = new TrieNode();
                        node.children.Add(letter, newNode);
                    }
                    node = node.children[letter];
                }
                node.children.Add(this.endSymbol, null);
                node.word = str;
            }
        }
    }
}
