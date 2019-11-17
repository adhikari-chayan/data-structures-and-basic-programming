using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearchAlgorithm
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

        public class BreadthFirstAlgorithm
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

            public Employee Search(Employee root,string nameForSearch)
            {
                Queue<Employee> queue = new Queue<Employee>();
                HashSet<Employee> s = new HashSet<Employee>();

                queue.Enqueue(root);
                s.Add(root);
                while(queue.Count!=0)
                {
                    Employee e = queue.Dequeue();
                    if (e.Name == nameForSearch)
                        return e;
                    foreach(var employee in e.Employees)
                    {
                        if(!s.Contains(employee))
                        {
                            queue.Enqueue(employee);
                            s.Add(employee);
                        }
                    }
                }
                return null;
            }

            public void Traverse(Employee root)
            {
                Queue<Employee> queue = new Queue<Employee>();
                HashSet<Employee> s = new HashSet<Employee>();

                queue.Enqueue(root);
                s.Add(root);
                while (queue.Count != 0)
                {
                    Employee e = queue.Dequeue();
                    Console.Write(e.Name + " ");
                    foreach (var employee in e.Employees)
                    {
                        if (!s.Contains(employee))
                        {
                            queue.Enqueue(employee);
                            s.Add(employee);
                        }
                    }
                }
               
            }
        }
        static void Main(string[] args)
        {
            BreadthFirstAlgorithm b = new BreadthFirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);

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
