using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegate
{
    public delegate void SampleDelegate();
    public delegate int SampleReturnDelegate();
    public delegate void SampleOutDelegate(out int number);
    class Program
    {
        static void Main(string[] args)
        {

            //SampleDelegate del1, del2, del3, del4;
            //del1 = new SampleDelegate(SampleMethodOne);
            //del2 = new SampleDelegate(SampleMethodTwo);
            //del3 = new SampleDelegate(SampleMethodThree);

            //del4 = del1 + del2 + del3;
            //del4 = del1 + del2 + del3 -del2;

            SampleDelegate del = new SampleDelegate(SampleMethodOne);
            del += SampleMethodTwo;
            del += SampleMethodThree;
            del -= SampleMethodOne;

            del();

            SampleReturnDelegate retDel = new SampleReturnDelegate(ReturnMethod1);
            retDel += ReturnMethod2;

            int result = retDel();
            Console.WriteLine(result);

            SampleOutDelegate outDel = new SampleOutDelegate(OutMethod1);
            outDel += OutMethod2;

            int resultOut = -1;
            outDel(out resultOut);
            Console.WriteLine(resultOut);

            Console.ReadKey();


            
        }

        public static void SampleMethodOne()
        {
            Console.WriteLine("SampleMethodOne Invoked");
        }

        public static void SampleMethodTwo()
        {
            Console.WriteLine("SampleMethodTwo Invoked");
        }

        public static void SampleMethodThree()
        {
            Console.WriteLine("SampleMethodThree Invoked");
        }

        public static int ReturnMethod1()
        {
            return 1;
        }

        public static int ReturnMethod2()
        {
            return 2;
        }

        public static void OutMethod1(out int number)
        {
            number = 1;
        }

        public static void OutMethod2(out int number)
        {
            number = 2;
        }
    }
}
