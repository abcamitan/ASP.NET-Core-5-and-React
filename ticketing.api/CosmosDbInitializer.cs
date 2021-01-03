using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Ticketing.Api
{
    public class CosmosDbInitializer
    {
        /// <summary>
        /// Creates a Cosmos DB database and a container with the specified partition key. 
        /// </summary>
        /// <returns></returns>
        public async Task<T> InitializeServiceAsync<T>(IConfigurationSection configurationSection, string containerName)
        {
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string account = configurationSection.GetSection("Url").Value;
            string key = configurationSection.GetSection("Key").Value;
            Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
            T cosmosDbService = (T)Activator.CreateInstance(typeof(T), client, databaseName, containerName);
            Microsoft.Azure.Cosmos.DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");
            return cosmosDbService;
        }


    }
}
