using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Net5.LogAndTrace.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
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
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var activitySource = new ActivitySource("MyApplicationActivitySource");
            var meter = new Meter("MyApplicationMetrics");
            var requestCounter = meter.CreateCounter<int>("compute_requests");
            var httpClient = new HttpClient();
            requestCounter.Add(1);

            using (var activity = activitySource.StartActivity("Get data"))
            {
                // Add data the the activity
                // You can see these data in Zipkin
                activity?.AddTag("sample", "value");

                // Http calls are tracked by AddHttpClientInstrumentation
                var str1 = await httpClient.GetStringAsync("https://example.com");
                var str2 = await httpClient.GetStringAsync("https://www.meziantou.net");

                _logger.LogInformation("Response1 length: {Length}", str1.Length);
                _logger.LogInformation("Response2 length: {Length}", str2.Length);
            }


            var activitySourceSample = new ActivitySource("SampleActivitySource");

            var name = "IEnumerable<WeatherForecast> Get()";

            using (var sampleActivity = activitySourceSample.StartActivity("Sample", ActivityKind.Server))
            {
                // note that "sampleActivity" can be null here if nobody listen events generated
                // by the "SampleActivitySource" activity source.
                sampleActivity?.AddTag("Name", name);
                sampleActivity?.AddBaggage("SampleContext", name);

                // Simulate a long running operation
                await Task.Delay(1000);
            }


            var meter2 = new Meter("MyApplication");

            var counter = meter2.CreateCounter<int>("Requests");
            var histogram = meter2.CreateHistogram<float>("RequestDuration", unit: "ms");
            meter2.CreateObservableGauge("ThreadCount", () => new[] { new Measurement<int>(ThreadPool.ThreadCount) });
            counter.Add(1, KeyValuePair.Create<string, object?>("name", name));

            var httpClient2 = new HttpClient();
            var stopwatch = Stopwatch.StartNew();
            await httpClient2.GetStringAsync("https://www.meziantou.net");

            // Measure the duration in ms of requests and includes the host in the tags
            histogram.Record(stopwatch.ElapsedMilliseconds,
                tag: KeyValuePair.Create<string, object?>("Host", "www.meziantou.net"));

            _logger.LogInformation("Esto es un dato informativo");
            _logger.LogWarning("Esto es un dato de advertencia");
            _logger.LogError("Esto es un dato de error");


            var rng = new Random();
            MyMethod();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        private void MyMethod()
        {
            Console.WriteLine("MyMethod");
        }
    }
}
