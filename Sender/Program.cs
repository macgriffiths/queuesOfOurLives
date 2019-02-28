using Common.Services;
using Common.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sender
{
    public class Program
    {
        private static IConnectionService _connectionService;

        public static void Main(string[] args)
        {
            InitializeContainer();

            Console.WriteLine("Please enter your name to continue");

            var name = Console.ReadLine().Trim();

            var message = $"Hello my name is, {name}";

            _connectionService.PublishMessage(message, "darth");

            Console.ReadLine();
        }

        /// <summary>
        /// Create dependency injection container.
        /// </summary>
        private static void InitializeContainer()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConnectionService, ConnectionService>();

            var buildServiceProvider = serviceCollection.BuildServiceProvider();

            _connectionService = buildServiceProvider.GetService<IConnectionService>();
        }
    }
}
