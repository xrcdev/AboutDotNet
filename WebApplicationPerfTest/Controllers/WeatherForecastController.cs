using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplicationPerfTest.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        static int _conNum = 0;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet]
        public int Get()
        {
            //_conNum += 1;
            return 0;
            /* var rng = new Random();
             return Enumerable.Range(1, 5).Select(index => new WeatherForecast
             {
                 Date = DateTime.Now.AddDays(index),
                 TemperatureC = rng.Next(-20, 55),
                 Summary = Summaries[rng.Next(Summaries.Length)]
             })
             .ToArray();*/
        }
        static string dtFmt = "yyyy-MM-dd HH:mm:ss.fff";

        [HttpGet("{id}")]
        public int GetName(int id)
        {
            var num = Interlocked.Increment(ref _conNum);
            var begin = DateTime.Now;
            //_logger.Log(LogLevel.Information)
            _logger.LogInformation($"{begin.ToString(dtFmt)}, 收到请求序号{id},目前总共收到{num}个请求");
             Thread.Sleep(TimeSpan.FromMinutes(3));
            var end = DateTime.Now;
            _logger.LogDebug($"{end.ToString(dtFmt)},请求序号{id}, 第{num}个请求,处理完毕,耗时:{(end - begin).ToString()}");
            return id;
            /* var rng = new Random();
             return Enumerable.Range(1, 5).Select(index => new WeatherForecast
             {
                 Date = DateTime.Now.AddDays(index),
                 TemperatureC = rng.Next(-20, 55),
                 Summary = Summaries[rng.Next(Summaries.Length)]
             })
             .ToArray();*/
        }
    }
}
