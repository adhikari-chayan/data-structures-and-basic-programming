using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftUtilization
{
    class Program
    {
        static void Main(string[] args)
        {

            var fwdList = new List<List<int>> { new List<int> { 1, 3000 }, new List<int> { 2, 5000 }, new List<int> { 3, 7000 }, new List<int> { 4, 10000 } };
            var returnList = new List<List<int>> { new List<int> { 1, 2000 }, new List<int> { 2, 3000 }, new List<int> { 3, 4000 }, new List<int> { 4, 5000 } };

            var maxTravelDistance = 10000;
            var result = AircraftUtilization(maxTravelDistance, fwdList, returnList);

            foreach(var item in result)
            {
                Console.WriteLine($"[{item[0]},{item[1]}]");
            }

            Console.WriteLine("-------------------------------------------");

            fwdList = new List<List<int>> { new List<int> { 1, 2000 }, new List<int> { 2, 4000 }, new List<int> { 3, 6000 } };
            returnList = new List<List<int>> { new List<int> { 1, 2000 }};

            maxTravelDistance = 7000;
            result = AircraftUtilization(maxTravelDistance, fwdList, returnList);

            foreach (var item in result)
            {
                Console.WriteLine($"[{item[0]},{item[1]}]");
            }

            Console.ReadKey();
        }

        public static List<List<int>> AircraftUtilization(int maxTravelDistance, List<List<int>> forwardRouteList, List<List<int>> returnRouteList)
        {
            List<List<int>> result = new List<List<int>>();
            int len1 = forwardRouteList.Count();
            int len2 = returnRouteList.Count();

            if (len1 == 0 || len2 == 0) return result;

            forwardRouteList.Sort(new CustomComparer());
            returnRouteList.Sort(new CustomComparer());

            int left = 0, right = len2 - 1, maxVal = -1;
            Dictionary<int, List<List<int>>> map = new Dictionary<int, List<List<int>>>();

            while (left < len1 && right >= 0)
            {
                int sum = forwardRouteList[left][1] + returnRouteList[right][1];
                if (sum > maxTravelDistance)
                {
                    --right;
                    continue;
                }
                if (sum >= maxVal)
                {
                    int r = right;
                    if (!map.ContainsKey(sum))
                        map.Add(sum, new List<List<int>>());

                    // check the duplicates 
                    while (r >= 0 && returnRouteList[r][1] == returnRouteList[right][1])
                    {
                        List<int> list = new List<int>();
                        list.Add(forwardRouteList[left][0]);
                        list.Add(returnRouteList[r][0]);
                        map[sum].Add(list);
                        --r;
                    }
                    maxVal = sum;
                }
                ++left;
            }
            return map[maxVal];
        }
    }
    public class CustomComparer : IComparer<List<int>>
    {


        public int Compare(List<int> x, List<int> y)
        {
           return x[1] - y[1];
        }
    }
}
