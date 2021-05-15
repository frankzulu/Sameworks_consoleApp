using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sameworks.ConsoleApp.Models;
using System.Threading;

namespace Sameworks.ConsoleApp.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SampleRepository> _logger;
        private ProgramSettings _programSettings = new ProgramSettings();

        public void DoSomething()
        {
            _logger.LogInformation($"{nameof(SampleRepository)}.DoSomething just did something.");
            Thread.Sleep(_programSettings.SleepTimeInMs);
        }

        public SampleRepository(IConfiguration configuration, ILogger<SampleRepository> logger)
        {
            _configuration = configuration;
            _configuration.GetSection("ProgramSettings").Bind(_programSettings);
            _logger = logger;
        }
    }
}
