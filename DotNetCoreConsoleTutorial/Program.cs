using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace DotNetCoreConsoleTutorial
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            // Register services to service collection
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            // Get instance
            var service = serviceProvider.GetRequiredService<IService>();

            service.DoWork();
        }

        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="services">Service collection</param>
        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Register configuration
            services.AddSingleton(configuration);
            services.AddSingleton<IService, Service>();
            services.AddSingleton<IRepository, Repository>();
        }
    }
}