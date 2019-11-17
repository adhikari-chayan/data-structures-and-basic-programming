using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderScorifySubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "testthis is a testtest to see if testestest it works";
            var substring = "test";

            var result = UnderScorifySubstring(input, substring);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string UnderScorifySubstring(string str,string substring)
        {
            List<int[]> locations = Collapse(GetLocations(str, substring));
            return UnderScorify(str, locations);
        }

        private static string UnderScorify(string str, List<int[]> locations)
        {
            int flag = 0;
            for (int locationIdx = 0; locationIdx < locations.Count; locationIdx++)
            {
                
                for (int i = 0; i < 2; i++)
                {
                    int idx = locations[locationIdx][i];
                    str=str.Insert(idx+flag,"_");
                    flag++;
                }
            }
            return str;
        }
            
        

        private static List<int[]> Collapse(List<int[]> locations)
        {
            if (locations.Count == 0)
                return locations;

            List<int[]> newLocations = new List<int[]>();
            newLocations.Add(locations[0]);
            int[] previous = locations[0];
            for(int i=1;i<locations.Count;i++)
            {
                int[] current = locations[i];
                if(current[0] <= previous[1])
                {
                    previous[1] = current[1];
                }
                else
                {
                    newLocations.Add(current);
                    previous = current;
                }
            }
            return newLocations;
            
        }

        private static List<int[]> GetLocations(string str, string substring)
        {
            List<int[]> locations = new List<int[]>();
            int startIdx = 0;
            while(startIdx<str.Length)
            {
                int nextIdx = str.IndexOf(substring,startIdx);
                if(nextIdx!=-1)
                {
                    locations.Add(new int[] { nextIdx, (nextIdx + substring.Length) });
                    startIdx = nextIdx + 1; 
                }
                else
                {
                    break;
                }
            }

            return locations;
        }
    }
}
