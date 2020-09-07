using System;

namespace AboutCSharpLanguage
{
    class Program
    {
        //static void Main(string[] args)
        //{
            //引用类型,值类型测试;
            /* ValPoint p1;
             p1.x = 1;
             Console.WriteLine(p1.x);*/

            //日志测试
            //TestLog.WriteMsg("Nice Day");

            //网站压力测试
            //testConn.TestCon();
            //WebsiteStressTest.TestRespone();
        //    Console.Read();
        //}
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
