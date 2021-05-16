using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sameworks.ConsoleApp.Models;
using Sameworks.ConsoleApp.Repositories;
using System;

namespace Sameworks.ConsoleApp
{
    public class Worker
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;
        private ProgramSettings _programSettings = new ProgramSettings();

        public void Run()
        {
            _logger.LogInformation("Starting Run Method In Worker Class.");
            _logger.LogInformation($"Title: {_programSettings.Title}");
            _sampleRepository.DoSomething();

            Console.WriteLine($"key1: {_configuration["key1"]}");
            Console.WriteLine($"key2: {_configuration["key2"]}");
        }

        public Worker(ISampleRepository sampleRepository, IConfiguration configuration, ILogger<Worker> logger)
        {
            _sampleRepository = sampleRepository;
            _configuration = configuration;
            _configuration.GetSection("ProgramSettings").Bind(_programSettings);
            _logger = logger;
        }
    }
}
