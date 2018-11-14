using Microsoft.Extensions.DependencyInjection;

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
        }

        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="services">Service collection</param>
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IService, Service>();
            services.AddSingleton<IRepository, Repository>();
        }
    }
}