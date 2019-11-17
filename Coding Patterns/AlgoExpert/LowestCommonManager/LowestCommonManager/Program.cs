using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee A = new Employee();
            A.Name = 'A';
            Employee B = new Employee();
            B.Name = 'B';
            Employee C = new Employee();
            C.Name = 'C';
            Employee D = new Employee();
            D.Name = 'D';
            Employee E = new Employee();
            E.Name = 'E';
            Employee F = new Employee();
            F.Name = 'F';
            Employee G = new Employee();
            G.Name = 'G';
            Employee H = new Employee();
            H.Name = 'H';
            Employee I = new Employee();
            I.Name = 'I';

            A.DirectReports.Add(B);
            A.DirectReports.Add(C);

            B.DirectReports.Add(D);
            B.DirectReports.Add(E);

            D.DirectReports.Add(H);
            D.DirectReports.Add(I);

            C.DirectReports.Add(F);
            C.DirectReports.Add(G);

            var result = GetLowestCommonManager(A, E, I);
            Console.WriteLine(result.Name);
            Console.ReadKey();
        }

        public static Employee GetLowestCommonManager(Employee topManager,Employee reportOne,Employee reportTwo)
        {
            return GetLowestCommonMangerForImportantEmployees(topManager, reportOne, reportTwo).LowestCommonManager;
        }

        private static Result GetLowestCommonMangerForImportantEmployees(Employee manager, Employee reportOne, Employee reportTwo)
        {
            int numImportantReports = 0;
            foreach(var directReport in manager.DirectReports)
            {
                Result result = GetLowestCommonMangerForImportantEmployees(directReport, reportOne, reportTwo);
                if (result.LowestCommonManager != null)
                    return result;

                numImportantReports += result.NumImportantReports;
            }
            if (manager == reportOne || manager == reportTwo)
                numImportantReports++;

            Employee lowestCommonManager;
            if (numImportantReports == 2)
                lowestCommonManager = manager;
            else
                lowestCommonManager = null;

            var newResult = new Result();
            newResult.LowestCommonManager = lowestCommonManager;
            newResult.NumImportantReports = numImportantReports;
            return newResult;

        }
    }
   public class Employee
    {
        public char Name { get; set; }
        public List<Employee> DirectReports { get; set; }

        public Employee()
        {
            DirectReports = new List<Employee>();
        }
    }

    public class Result
    {
        public Employee LowestCommonManager { get; set; }
        public int NumImportantReports { get; set; }
    }
}
