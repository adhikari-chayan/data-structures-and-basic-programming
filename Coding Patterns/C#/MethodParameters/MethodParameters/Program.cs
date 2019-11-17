using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            SimpleMethod(ref i);
            Console.WriteLine(i);

            int total = 0;
            int product = 0;
            Calculate(10, 20, out total, out product);
            Console.WriteLine($"Sum={total},Product{product}");

            int[] numbers = new int[3];
            numbers[0] = 101;
            numbers[1] = 102;
            numbers[2] = 103;

            //1.params array has to be the last parameter to a method
            //2. There cannot be two params array parameters to a method
            ParamsMethod();
            ParamsMethod(numbers);
            ParamsMethod(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Console.ReadKey();
        }

        public static void SimpleMethod( ref int j)
        {
            j = 101;
        }

        public static void Calculate(int firstNumber,int secondNumber,out int sum,out int prod)
        {
            sum = firstNumber + secondNumber;
            prod = firstNumber * secondNumber;
        }

        public static void ParamsMethod(params int[] numbers)
        {
            Console.WriteLine($"There are {numbers.Length} numbers passed to this method");

            int sum = 0;
            foreach(int i in numbers)
            {
                sum = sum + i;
            }
            Console.WriteLine($"Sum={sum}");
        }
    }
}
