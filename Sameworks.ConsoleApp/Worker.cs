using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sameworks.ConsoleApp.Models;

namespace Sameworks.ConsoleApp
{
    public class Worker
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;
        private ProgramSettings _programSettings = new ProgramSettings();

        public void Run()
        {
            _logger.LogInformation("Starting Run Method In Worker Class.");
            _logger.LogInformation($"Title: {_programSettings.Title}");
        }

        public Worker(IConfiguration configuration, ILogger<Worker> logger)
        {
            _configuration = configuration;
            _configuration.GetSection("ProgramSettings").Bind(_programSettings);
            _logger = logger;
        }
    }
}
