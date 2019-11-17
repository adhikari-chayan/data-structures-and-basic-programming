using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritanceUsingInterface
{
    public interface IA
    {
        void AMethod();

    }
    public interface IB
    {
        void BMethod();
    }

    public class A : IA
    {
        public void AMethod()
        {
            Console.WriteLine("A");
        }
    }

    public class B : IB
    {
        public void BMethod()
        {
            Console.WriteLine("B");
        }
    }

    public class AB : IA, IB
    {

        A a = new A();
        B b = new B();
        public void AMethod()
        {
            a.AMethod();
        }

        public void BMethod()
        {
            b.BMethod();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            AB ab = new AB();
            ab.AMethod();
            ab.BMethod();

            Console.ReadKey();
        }
    }
}
