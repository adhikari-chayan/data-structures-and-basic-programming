using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUniqueCharacterInString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "leetcode";
            var result = FirstUniqueCharacter(input);
            Console.WriteLine(result);
            Console.ReadKey();

        }

        public static int FirstUniqueCharacter(string str)
        {
            Dictionary<char, int> maps = new Dictionary<char, int>();

            for(var i=0;i<str.Length;i++)
            {
                char current = str[i];
                if (!maps.ContainsKey(current))
                    maps.Add(current, i);
                else
                    maps[current] = -1;//Invalidate as we have seen this character earlier and it is not unique
            }

            int minIdx = int.MaxValue;
            foreach(var character in maps.Keys)
            {
                if(maps[character]!=-1 && maps[character] < minIdx)
                {
                    minIdx = maps[character];
                }
            }
           return minIdx == int.MaxValue ? -1 : minIdx;
            
        }

    }
}
