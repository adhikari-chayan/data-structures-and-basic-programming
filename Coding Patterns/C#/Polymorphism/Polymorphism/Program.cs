using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Employee
    {
        public string FirstName = "FN";
        public string LastName = "LN";

        public virtual void PrintFullName()
        {
            Console.WriteLine(FirstName+" "+LastName);
        }
    }

    public class PartTimeEmployee:Employee
    {
        public override void PrintFullName()
        {
            Console.WriteLine(FirstName + " " + LastName + " - Part Time");
        }
    }

    public class FullTimeEmployee:Employee
    {
        public override void PrintFullName()
        {
            Console.WriteLine(FirstName + " " + LastName+ " - Full Time");
        }
    }

    public class TemporaryEmployee:Employee
    {
        public override void PrintFullName()
        {
            Console.WriteLine(FirstName + " " + LastName+ " - Temporary");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            Employee[] employees = new Employee[4];

            employees[0] = new Employee();
            employees[1] = new PartTimeEmployee();
            employees[2] = new FullTimeEmployee();
            employees[3] = new TemporaryEmployee();

            foreach(Employee e in employees)
            {
                //Instead of override if we use hiding, Since the reference variable is of type Base class, the base class method is called for all instances
                e.PrintFullName();
            }

            Console.ReadKey();
        }
    }
}
