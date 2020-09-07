using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyAndReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = GetResult();//n=1
            var n2 = GetResult2();//n2=1
        }
        static int GetResult()
        {
            int a = 1, b = 2, n = 1;
            try
            {
                int k = a / b;
                return n;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                n++;
            }

        }

        static Person GetResult2()
        {
            int a = 1, b = 2;
            Person p = new Person();
            try
            {
                int k = a / b;
                return p;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                p.Age++;
            }

        }
    }
    public class Person
    {
        public int Age { get; set; }
    }

}
