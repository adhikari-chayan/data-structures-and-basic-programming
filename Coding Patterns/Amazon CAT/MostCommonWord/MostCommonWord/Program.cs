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
            string paragraph = "a, a, a, a, b,b,b,c, c";//"Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = new string[] { "a" };

            Console.WriteLine(MostCommonWord(paragraph,banned));

            paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            banned = new string[] { "hit" };
            Console.WriteLine(MostCommonWord(paragraph, banned));
            Console.ReadKey();
        }

        public static string MostCommonWord(string paragraph,string[] bannedList)
        {
            paragraph = Regex.Replace(paragraph, @"[^\w\s]", " ");
            paragraph = paragraph.ToLower();
            string[] words = paragraph.Split(' ');
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach(var item in words)
            {
                if(!bannedList.Contains(item))
                {
                    if (!wordCount.ContainsKey(item) && !item.Equals(String.Empty))
                        wordCount.Add(item, 1);
                    else if(!item.Equals(String.Empty))
                        wordCount[item]++;
                }
            }

            
            return wordCount.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        #region Better Solution
        public string MostCommonWord1(string paragraph, string[] banned)
        {
            paragraph += ".";
            var bannedSet = new HashSet<string>();
            foreach (var s in banned)
            {
                bannedSet.Add(s);
            }

            var returnWord = "";
            var maxRepeatWordCount = 0;

            var wordDict = new Dictionary<string, int>();

            var word = new StringBuilder();
            foreach (var c in paragraph)
            {
                if (char.IsLetter(c))
                {
                    word.Append(c);
                }
                else if (word.Length > 0)
                {
                    var newWord = word.ToString().ToLower();
                    if (!banned.Contains(newWord))
                    {
                        if (wordDict.ContainsKey(newWord))
                        {
                            wordDict[newWord] = wordDict[newWord] + 1;
                        }
                        else
                        {
                            wordDict[newWord] = 1;
                        }

                        if (wordDict[newWord] >= maxRepeatWordCount)
                        {
                            maxRepeatWordCount = wordDict[newWord];
                            returnWord = newWord;
                        }
                    }
                    word.Clear();
                }

            }
            return returnWord;

        }

        #endregion
    }
}
