using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MostCommonWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = new string[] { "hit" };
            var result = MostCommonWord(paragraph, banned);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string MostCommonWord(string paragraph,string[] banned)
        {
            HashSet<string> bannedWords = new HashSet<string>();
            foreach(string bannedWord in banned)
            {
                bannedWords.Add(bannedWord);
            }

            paragraph = Regex.Replace(paragraph, "[^a-zA-Z]", " ").ToLower();
            string[] words = paragraph.Split(' ');
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach(var word in words)
            {
                if(!bannedWords.Contains(word))
                {
                    if (!counts.ContainsKey(word))
                        counts.Add(word, 1);
                    else
                        counts[word]++;
                }
            }

            string result = "";
            foreach(string key in counts.Keys)
            {
                if (result == "" || (counts[key] > counts[result]))
                    result = key;
            }

            return result;
        }
    }
}
