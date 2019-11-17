using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinRewards
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 8, 4, 2, 1, 3, 6, 7, 9, 5 };
            var result = MinRewards3(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int MinRewards1(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            for(int i=0;i<scores.Length;i++)
            {
                rewards[i] = 1;
            }

            for(int i=1;i<scores.Length;i++ )
            {
                int j = i - 1;
                if(scores[i] > scores[j])
                {
                    rewards[i] = rewards[j] + 1;
                }
                else
                {
                    while(j>=0 && scores[j]>scores[j+1])
                    {
                        rewards[j] = Math.Max(rewards[j], rewards[j + 1] + 1);
                        j--;
                    }
                }
            }
            return rewards.Sum();
        }

        public static int MinRewards2(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            for (int i = 0; i < scores.Length; i++)
            {
                rewards[i] = 1;
            }
            List<int> localMinIdxs = new List<int>();
            localMinIdxs = GetLocalMinIndexes(scores);
            foreach(var localMinIdx in localMinIdxs)
            {
                ExpandFromLocalMinIdx(localMinIdx, scores, rewards);
            }
            return rewards.Sum();
        }

        public static int MinRewards3(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            for(int i=0;i<scores.Length;i++)
            {
                rewards[i] = 1;
            }
            for(int i=1;i<scores.Length;i++)
            {
                if (scores[i] > scores[i - 1])
                    rewards[i] = rewards[i - 1] + 1;
            }
            for(int i=scores.Length-2;i>=0;i--)
            {
                if (scores[i] > scores[i + 1])
                    rewards[i] = Math.Max(rewards[i], rewards[i + 1] + 1);
            }
            return rewards.Sum();
        }

        private static void ExpandFromLocalMinIdx(int localMinIdx, int[] scores, int[] rewards)
        {
            int leftIdx = localMinIdx - 1;
            while (leftIdx >= 0 && scores[leftIdx]>scores[leftIdx+1])
            {
                rewards[leftIdx] = Math.Max(rewards[leftIdx], rewards[leftIdx + 1] + 1);
                leftIdx--;
            }
            int rightIdx = localMinIdx + 1;
            while (rightIdx <scores.Length && scores[rightIdx]>scores[rightIdx-1])
            {
                rewards[rightIdx] = rewards[rightIdx-1] + 1;
                rightIdx++;
            }
        }

        private static List<int> GetLocalMinIndexes(int[] scores)
        {
            List<int> localMinIdxs = new List<int>();
            if (scores.Length == 1)
            {
                localMinIdxs.Add(0);
                return localMinIdxs;
            }
            for(var i=0;i<scores.Length;i++)
            {
                if (i == 0 && scores[i] < scores[i + 1])
                    localMinIdxs.Add(i);
                if (i == scores.Length - 1 && scores[i] < scores[i - 1])
                    localMinIdxs.Add(i);
                if (i == 0 || i == scores.Length - 1)
                    continue;
                if (scores[i] < scores[i + 1] && scores[i] < scores[i - 1])
                    localMinIdxs.Add(i);
            }
            return localMinIdxs;
        }
    }
}
