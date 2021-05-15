using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sameworks.ConsoleApp.Repositories;
using System;

namespace Sameworks.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var worker = ActivatorUtilities.CreateInstance<Worker>(host.Services);
            worker.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration.Sources.Clear();
                    var environmentName = Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT");
                    configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    configuration.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
                    configuration.AddCommandLine(args);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<ISampleRepository, SampleRepository>();
                });
    }
}
