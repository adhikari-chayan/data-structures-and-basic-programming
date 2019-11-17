using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PassingDataToThreadTypeSafe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the target number");
            
            int target = Convert.ToInt32(Console.ReadLine());

            Number number = new Number(target);
            Thread T1 = new Thread(new ThreadStart(number.PrintNumbers));
            T1.Start();
            Console.ReadKey();
        }


    }

    class Number
    {
        int _target;
        public Number(int target)
        {
            _target = target;
        }

        public void PrintNumbers()
        {
            for(int i=1;i<=_target;i++)
                Console.WriteLine(i);
        }
    }
}
