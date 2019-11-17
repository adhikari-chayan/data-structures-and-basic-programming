using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParameterizedThreadStartDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the target number");
            object target = Console.ReadLine();
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(Number.PrintNumbers);

            Thread T1 = new Thread(parameterizedThreadStart);
            T1.Start(target);
            Console.ReadKey();
        }
    }

    class Number
    {
        public static void PrintNumbers(object target)
        {
            int number = 0;
            if(int.TryParse(target.ToString(),out number))
            for(var i=1;i<=number;i++)
                Console.WriteLine(i);
        }
    }
}
