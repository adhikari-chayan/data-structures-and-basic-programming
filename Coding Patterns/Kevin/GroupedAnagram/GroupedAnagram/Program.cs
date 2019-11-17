using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupedAnagram
{
    class Program
    {

        //https://leetcode.com/problems/group-anagrams/
        static void Main(string[] args)
        {
        }

        public static List<List<string>> GroupedAnagrams(string[] strs)
        {
            List<List<string>> groupedAnagrams = new List<List<string>>();
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach(string str in strs)
            {
                char[] characters = str.ToCharArray();
                Array.Sort(characters);
                string sorted = new string(characters);

                if(!map.ContainsKey(sorted))
                {
                    map.Add(sorted, new List<string>());
                }

                map[sorted].Add(str);
            }
            groupedAnagrams.AddRange(map.Values);

            return groupedAnagrams;
        }
    }
}
