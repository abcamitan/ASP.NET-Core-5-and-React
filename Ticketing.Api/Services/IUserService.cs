using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Api.Models;

namespace Ticketing.Api.Services
{
    public interface IUserService
    {
        public Task InitializeContainerAsync();
        public Task AddAsync(User user);
        public Task DeleteAsync(string id);
        public Task UpdateAsync(string id, User user);
        public Task<User> GetAsync(string id);
        public Task<IEnumerable<User>> GetByUserGroupAsync(string userGroup);
    }
}
