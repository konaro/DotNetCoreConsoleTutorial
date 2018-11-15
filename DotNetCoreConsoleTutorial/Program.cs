using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
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

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            // Configure NLog
            loggerFactory.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true });
            NLog.LogManager.LoadConfiguration("nlog.config");

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

            // Register logger factory
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Information));

            services.AddSingleton<IService, Service>();
            services.AddSingleton<IRepository, Repository>();
        }
    }
}