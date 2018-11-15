using Microsoft.Extensions.Configuration;
using System;

namespace DotNetCoreConsoleTutorial
{
    public class Repository : IRepository
    {
        private readonly IConfigurationRoot _configuration;

        public Repository(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public void DoWork()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");

            var input = Console.ReadLine();

            Console.WriteLine($"Input value: {input}, Connection: {connection}");
        }
    }
}