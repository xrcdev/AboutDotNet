using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1NFW
{
    class Program
    {
        /// <summary>
        /// 得到的
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ValPoint vPoint;
            vPoint.x = 1;
            ValPoint vPoint2;
            vPoint2.x = 10;
            vPoint2.Equals(vPoint);
            List<ValPoint> points = new List<ValPoint>();
            points.Add(vPoint);
            
            System.Diagnostics.Debugger.Break(); // breakpoint
            Console.WriteLine(vPoint.x);

            var r= SlowMultiply(10, 5);
            Console.WriteLine(r);
            Console.Read();
        }

        /// <summary>
        ///
        /// 如果方法被内联，我们将无法单独反汇编它
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        static int SlowMultiply(int x, int y)
        {
            if (y < 0)
            {
                x *= -1;
                y *= -1;
            }

            var result = 0;
            for (var i = 0; i < y; i++)
            {
                result += x;
            }

            return result;
        }
    }
    public struct ValPoint
    {
        public int x;

        public ValPoint(int x)
        {
            this.x = x;
        }
    }
}
