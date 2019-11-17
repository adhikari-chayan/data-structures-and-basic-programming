using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void HelloFunctionDelegate(string message);
    class Program
    {
        static void Main(string[] args)
        {
            HelloFunctionDelegate del = new HelloFunctionDelegate(Hello);
            del("Hello from delegate");
            Console.ReadKey();
        }

        public static void Hello(string message)
        {
            Console.WriteLine(message);
        }
    }
}
