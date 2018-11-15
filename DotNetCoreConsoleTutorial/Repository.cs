using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace DotNetCoreConsoleTutorial
{
    public class Repository : IRepository
    {
        private readonly IConfigurationRoot _configuration;
        private readonly ILogger<Repository> _logger;

        public Repository(IConfigurationRoot configuration, ILogger<Repository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public void DoWork()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");

            var input = Console.ReadLine();

            Console.WriteLine($"Input value: {input}, Connection: {connection}");

            _logger.LogInformation("Doing work...");
        }
    }
}