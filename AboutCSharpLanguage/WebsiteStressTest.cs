using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
namespace AboutCSharpLanguage
{
    public class WebsiteStressTest
    {
        static string dtFmt = "yyyy-MM-dd HH:mm:ss.fff";
        public static void TestCon()
        {

            var tasks = Enumerable.Range(0, 100).Select(t =>
            {
                return new Task(() =>
                {
                    RestClient client = new RestClient("http://localhost:8501");
                    var request = new RestRequest("weatherforecast/get", Method.GET);
                    IRestResponse response = client.Execute(request);
                    var contentGet = response.Content;
                    Console.WriteLine("GET方式获取结果：" + contentGet);
                });
            }).ToArray();
            tasks.ToList().ForEach(t => t.Start());
            Task.WaitAll(tasks);
            Console.WriteLine("get 全部结束");
            // Define other methods, classes and namespaces here


        }
        public static void TestRespone()
        {
            Console.WriteLine("设置100个线程");
            var tasks = Enumerable.Range(0, 100).Select(t =>
             {
                 return new Task((i) =>
                 {
                     var id = (int)i;
                     RestClient client = new RestClient("http://localhost:8501");
                     client.Timeout = 10 * 60 * 1000;
                     var request = new RestRequest("weatherforecast/getname/{id}", Method.GET);
                     request.AddUrlSegment("id", id);
                     Console.WriteLine($"{DateTime.Now.ToString(dtFmt)}, 请求序号{id}个,开始发起请求");
                     IRestResponse response = client.Execute(request);
                     var contentGet = response.Content;
                     Console.WriteLine($"{DateTime.Now.ToString(dtFmt)}, 请求序号{id},返回数据:{contentGet}");
                 }, t);
             }).ToArray();
            tasks.ToList().ForEach(t => t.Start());
            Task.WaitAll(tasks);
            Console.WriteLine("getname 全部结束");
            // Define other methods, classes and namespaces here


        }
    }
}
