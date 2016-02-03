using System;
using NServiceBus;

namespace Issue39.HasSagas.Host
{
    public class EndpointConfiguration : IConfigureThisEndpoint, AsA_Worker
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseTransport<AzureServiceBusTransport>().ConnectionString(ConnectionString);

            configuration.Transactions()
                .DisableDistributedTransactions()
                .DoNotWrapHandlersExecutionInATransactionScope();

            configuration.AzureConfigurationSource();

            configuration.UsePersistence<InMemoryPersistence>();
        }

        private static string ConnectionString
        {
            get
            {
                var connectionString = Environment.GetEnvironmentVariable("AzureServiceBus.ConnectionString");
                if (connectionString != null)
                {
                    return connectionString;
                }

                throw new InvalidOperationException("Failed to get a value from `AzureServiceBus.ConnectionString`. Please add it to your environment variables to run tests.");
            }
        }
    }
}
