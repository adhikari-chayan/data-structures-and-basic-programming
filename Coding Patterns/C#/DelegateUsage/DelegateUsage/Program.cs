using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();

            empList.Add(new Employee() { Id = 101, Name = "Mary", Salary = 5000, Experience = 5 });
            empList.Add(new Employee() { Id = 102, Name = "Mike", Salary = 6000, Experience = 3 });
            empList.Add(new Employee() { Id = 103, Name = "Jason", Salary = 9000, Experience = 7 });
            empList.Add(new Employee() { Id = 104, Name = "Craig", Salary = 3000, Experience = 2 });
            empList.Add(new Employee() { Id = 105, Name = "Todd", Salary = 4000, Experience = 3 });

            //IsPromotable isPromotable = new IsPromotable(Promote);

            Employee.PromoteEmployee(empList,emp=>emp.Experience>=5);

            Console.ReadKey();

             
        }

        //public static bool Promote(Employee emp)
        //{
        //    if (emp.Experience >= 5)
        //        return true;
        //    else
        //        return false;
        //}
    }

    delegate bool IsPromotable(Employee emp);
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Salary { get; set; }

        public int Experience { get; set; }

        public static void PromoteEmployee(List<Employee> employeeList,IsPromotable isEligibleToPromote)
        {
            foreach(Employee employee in employeeList)
            {
                //if(employee.Experience >= 5)
                if(isEligibleToPromote(employee))
                {
                    Console.WriteLine(employee.Name+" promoted");
                }
            }
        }
    }
}
