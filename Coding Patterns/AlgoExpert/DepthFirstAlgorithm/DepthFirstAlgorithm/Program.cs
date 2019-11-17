using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstAlgorithm
{
    class Program
    {
        public class Employee
        {
            private List<Employee> _employeeList = new List<Employee>();

            public Employee(string name)
            {
                Name = name;
            }
            public string Name { get; set; }
            public List<Employee> Employees
            {
                get
                {
                    return _employeeList;
                }
            }

            public void AddEmployee(Employee employee)
            {
                _employeeList.Add(employee);
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public class DepthFirstAlgorithm
        {
            public Employee BuildEmployeeGraph()
            {
                Employee Eva = new Employee("Eva");
                Employee Sophia = new Employee("Sophia");
                Employee Brian = new Employee("Brian");
                Eva.AddEmployee(Sophia);
                Eva.AddEmployee(Brian);

                Employee Lisa = new Employee("Lisa");
                Employee Tina = new Employee("Tina");
                Employee John = new Employee("John");
                Employee Mike = new Employee("Mike");
                Sophia.AddEmployee(Lisa);
                Sophia.AddEmployee(John);
                Brian.AddEmployee(Tina);
                Brian.AddEmployee(Mike);

                return Eva;
            }

            public Employee Search(Employee root,string nameToSearchFor)
            {
                if (root.Name == nameToSearchFor)
                    return root;

                Employee personFound = null;
                for (var i=0;i<root.Employees.Count;i++)
                {
                    personFound = Search(root.Employees[i], nameToSearchFor);
                    if (personFound != null)
                        break;
                }
                return personFound;

            }

            public void Traverse(Employee root)
            {
                Console.Write(root.Name+ " ");
                for(var i=0;i<root.Employees.Count;i++)
                {
                    Traverse(root.Employees[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            DepthFirstAlgorithm b = new DepthFirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);
            Console.WriteLine();
            Console.WriteLine("\nSearch in Graph\n------");
            Employee e = b.Search(root, "Eva");
            Console.WriteLine(e == null ? "Employee not found" : e.Name);
            e = b.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.Name);
            e = b.Search(root, "Soni");
            Console.WriteLine(e == null ? "Employee not found" : e.Name);

            Console.ReadKey();
        }


    }
}
