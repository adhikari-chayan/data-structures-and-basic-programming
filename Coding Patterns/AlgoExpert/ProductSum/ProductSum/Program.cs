using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<object>
            {
                5,2,new List<object>{7,-1},3,new List<object>{6,new List<object> { -13,8},4 }
            };
            var result = ProductSum(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int ProductSum(List<object> specialArray)
        {
            return GetProductSum(specialArray, 1);
        }
        public static int GetProductSum(List<object> specialArray,int multiplier)
        {
            int sum = 0;
            
            foreach(var entry in specialArray)
            {
                if(entry is List<object>)
                {
                    sum = sum + GetProductSum((List<object>)entry, multiplier + 1);
                }
                else
                {
                    sum = sum + (int)entry;
                }
            }
            return sum * multiplier;
        }

        
    }
}
