using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Api.Models;

namespace Ticketing.Api.Services
{
    public interface ITicketService
    {
        public Task InitializeContainerAsync();
        public Task AddAsync(Ticket ticket);
        public Task DeleteAsync(string id);
        public Task UpdateAsync(string id, Ticket ticket);
        public Task<Ticket> GetAsync(string id);
        public Task<IEnumerable<Ticket>> GetByUserAsync(string userId);
        public Task<IEnumerable<Ticket>> GetJobByUserAsync(string userId);
    }
}
