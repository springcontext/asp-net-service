using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspConsumer.Jobs
{
    public class IHealthCheckTask : IHostedService
    {
        private ILogger _logger;

        public IHealthCheckTask(ILogger<IHealthCheckTask> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(TaskRoutine, cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task TaskRoutine()
        {
            while (true)
            {
                HttpClient httpClient = new HttpClient();

                StreamReader reader = new StreamReader("./jobs/body.json");

                string content = reader.ReadToEnd();

                var info = await httpClient.PostAsync("http://localhost:8761/eureka/apps/asp-consumer-service", new StringContent(content, Encoding.UTF8, "application/json"));

                _logger.LogInformation("Status: heartbeat sent");

                DateTime nextStop = DateTime.Now.AddSeconds(10);

                var timeToWait = nextStop - DateTime.Now;
                var millisToWait = timeToWait.TotalMilliseconds;

                Thread.Sleep((int)millisToWait);
            }
        }
    }
}
