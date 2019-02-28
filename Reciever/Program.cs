using Common.Services;
using Common.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Reciever
{
    class Program
    {
        private static IConnectionService _connectionService;

        public static void Main()
        {
            InitializeContainer();

            _connectionService.ReceiveMessage("darth"); 
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
