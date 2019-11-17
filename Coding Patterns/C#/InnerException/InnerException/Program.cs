using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    Console.WriteLine("Enter First Number");
                    int fn = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Second Number");
                    int sn = Convert.ToInt32(Console.ReadLine());

                    int result = fn / sn;
                    Console.WriteLine("Result={0}", result);
                }
                catch (Exception ex)
                {
                    string filePath = @"C:\My Stuff\Practise Projects\Kudvenkat\C#\InnerException\InnerException\Log.txt";
                    if (File.Exists(filePath))
                    {
                        StreamWriter sw = new StreamWriter(filePath);
                        sw.Write(ex.GetType().Name);
                        sw.WriteLine();
                        sw.Write(ex.Message);
                        sw.Close();
                        Console.WriteLine("There is a problem, please try later.");
                    }
                    else
                    {
                        throw new FileNotFoundException(filePath + " is not present",ex);
                    }
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine("Current exception: {0}",exp.GetType().Name);
                if(exp.InnerException!=null)
                    Console.WriteLine("Inner exception: {0}",exp.InnerException.GetType().Name);
                Console.ReadKey();

            }
            
        }
        
    }
   
}
