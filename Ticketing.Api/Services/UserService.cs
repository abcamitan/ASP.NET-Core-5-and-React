using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using User = Ticketing.Api.Models.User;

namespace Ticketing.Api.Services
{
    public class UserService : IUserService
    {
        private readonly Container _container;

        public UserService(CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task InitializeContainerAsync()
        {
            var random = new Random();
            string[] department =
            {
                "Facilities",
                "Procurement",
                "Human Resource",
                "Finance",
                "IT",
                "Admin"
            };

            string[] userid =
            {
                "Jeff.Prosise",
                "Dave.McCarter",
                "Allen.Warren",
                "Monica.Rathbun",
                "Royce.Hunt",
                "Marches.Chard"
            };

            for (int i = 0; i < 6; i++)
            {
                var userIdData = userid[i];
                User user = new User()
                {
                    Id = userIdData,
                    Department = department[i],
                    FirstName = userIdData.Split(".")[0],
                    LastName = userIdData.Split(".")[1],
                    MiddleName = null,
                    GroupName = userIdData == "Marches.Chard" ? "Admin" : "User"
                };

                await AddAsync(user);
            }

        }

        public async Task AddAsync(User user)
        {
            await _container.CreateItemAsync(user, new PartitionKey(user.Id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<User>(id, new PartitionKey(id));
        }

        public async Task UpdateAsync(string id, User user)
        {
            await _container.UpsertItemAsync(user, new PartitionKey(id));
        }

        public async Task<User> GetAsync(string id)
        {
            try
            {
                ItemResponse<User> response = await _container.ReadItemAsync<User>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        // Use Cosmos DB Parameterized Query to avoid SQL Injection.
        public async Task<IEnumerable<User>> GetByUserGroupAsync(string groupName)
        {
            string query = @$"SELECT * FROM User u "
                           + @"WHERE u.GroupName = @GroupName";

            QueryDefinition queryDefinition = new QueryDefinition(query)
                .WithParameter("@GroupName", groupName);

            var results = await GetByQueryAsync(queryDefinition);

            return results;
        }

        private async Task<IEnumerable<User>> GetByQueryAsync(QueryDefinition queryDefinition)
        {
            var query = _container.GetItemQueryIterator<User>(queryDefinition);
            List<User> results = new List<User>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
