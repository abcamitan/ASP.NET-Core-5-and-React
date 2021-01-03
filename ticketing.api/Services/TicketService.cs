using Microsoft.Azure.Cosmos;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Api.Models;

namespace Ticketing.Api.Services
{
    public class TicketService : ITicketService
    {
        private readonly Container _container;

        public TicketService(CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task InitializeContainerAsync()
        {
            var random = new Random();
            string[] description =
            {
                "Fix light from reception",
                "Require toiletries supply",
                "Hire new staff",
                "Pay needed for supplier",
                "Fix network issues"
            };

            string[] categories =
            {
                "Facilities",
                "Procurement",
                "Human Resource",
                "Finance",
                "IT"
            };

            string[] user =
            {
                "Marches.Chard", 
                "Jeff.Prosise", 
                "Dave.McCarter", 
                "Allen.Warren",
                "Monica.Rathbun",
                "Royce.Hunt"
            };

            string[] activities =
            {
                "Replaced light from reception",
                "Bought toiletries supply",
                "Hired new staff",
                "Paid supplier",
                "Restored network connection"
            };

            string[] status =
            {
                "Active",
                "In progress",
                "Completed"
            };

            for (int i = 0; i < 20; i++)
            {
                var index = random.Next(5);
                var statusIndex = random.Next(3);
                var date = DateTime.Now.AddDays(statusIndex * -1);
                Ticket ticket = new Ticket
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = description[index],
                    CreatedDate = date,
                    WhenNeeded = date.AddDays(1 + index),
                    RequestedBy = user[index],
                    Category = new Category()
                    {
                        Name = categories[index],
                    },
                    Job = new Job()
                    {
                        Status = status[statusIndex],
                        Activity = activities[index],
                        AssignedTo = user[(index - 5)* -1],
                        WhenCompleted = (status[statusIndex] == "Completed") ? DateTime.Now : default
                    },
                };

                await AddAsync(ticket);
            }
            
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _container.CreateItemAsync(ticket, new PartitionKey(ticket.Id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Ticket>(id, new PartitionKey(id));
        }

        public async Task UpdateAsync(string id, Ticket ticket)
        {
            await _container.UpsertItemAsync(ticket, new PartitionKey(id));
        }

        public async Task<Ticket> GetAsync(string id)
        {
            try
            {
                ItemResponse<Ticket> response = await _container.ReadItemAsync<Ticket>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        // Use Cosmos DB Parameterized Query to avoid SQL Injection.
        public async Task<IEnumerable<Ticket>> GetByUserAsync(string userId)
        {
            string query = @$"SELECT * FROM Ticket t "
                           + @"WHERE t.RequestedBy = @RequestedBy";

            QueryDefinition queryDefinition = new QueryDefinition(query)
                .WithParameter("@RequestedBy", userId);

            var results = await GetByQueryAsync(queryDefinition);

            return results;
        }

        // Use Cosmos DB Parameterized Query to avoid SQL Injection.
        public async Task<IEnumerable<Ticket>> GetJobByUserAsync(string userId)
        {
            string query = @$"SELECT * FROM Ticket t "
                           + @"WHERE t.Job.AssignedTo = @AssignedTo";

            QueryDefinition queryDefinition = new QueryDefinition(query)
                .WithParameter("@AssignedTo", userId);

            var results = await GetByQueryAsync(queryDefinition);

            return results;
        }

        private async Task<IEnumerable<Ticket>> GetByQueryAsync(QueryDefinition queryDefinition)
        {
            var query = _container.GetItemQueryIterator<Ticket>(queryDefinition);
            List<Ticket> results = new List<Ticket>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}