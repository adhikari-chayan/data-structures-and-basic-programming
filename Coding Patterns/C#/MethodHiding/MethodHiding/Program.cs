using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodHiding
{
    public class Employee
    {
        public string FirstName;
        public string LastName;

        public void PrintFullName()
        {
            Console.WriteLine(FirstName+" "+LastName);
        }
    }

    public class PartTimeEmployee:Employee
    {
        public new  void PrintFullName()
        {
            //base.PrintFullName();
            Console.WriteLine(FirstName + " " + LastName+" -Contractor");
        }
    }

    public class FullTimeEmployee:Employee
    {
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            FullTimeEmployee fte = new FullTimeEmployee();
            fte.FirstName = "FullTime";
            fte.LastName = "Employee";
            fte.PrintFullName();

            PartTimeEmployee pte = new PartTimeEmployee();
            //Employee pte = new PartTimeEmployee(); //calls base class method
            pte.FirstName = "PartTime";
            pte.LastName = "Employee";
            pte.PrintFullName();
            //((Employee)pte).PrintFullName();Way to call base class method

            Console.ReadKey();
        }
    }
}
