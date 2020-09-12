using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace GenericVarianceTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            ISalary<Programmer> s = new BaseSalaryCounter<Programmer>();
            PrintSalary(s);
            Console.ReadLine();
        }

        static void PrintSalary<T>(ISalary<T> s)
        {
            s.Pay();
        }
    }

    interface ISalary<in T>
    {
        void Pay();
    }

    class BaseSalaryCounter<T> : ISalary<T>
    {

        public void Pay()
        {
            Console.WriteLine("Pay base salary");
        }

    }

    class Employee
    {
        public string Name = "";
    }

    class Programmer : Employee { }

    class Manager : Employee { }
}
