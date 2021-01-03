using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ticketing.Api.Models;
using Ticketing.Api.Services;

namespace Ticketing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        // GET: api/user/initialize
        // will initialize single record in user container
        [HttpGet]
        [Route("/api/[controller]/initialize")]
        public string Initialize()
        {
            _userService.InitializeContainerAsync();
            var message = "User container has been initialized with value";
            _logger.LogInformation(message);
            return message;
        }

        // GET: api/<UserController>
        [HttpGet("ByGroup")]
        public async Task<IEnumerable<User>> GetByUser([FromQuery] string userGroup)
        {
            var users = await _userService.GetByUserGroupAsync(userGroup);
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            var user = await _userService.GetAsync(id);
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            await _userService.AddAsync(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] User user)
        {
            await _userService.UpdateAsync(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _userService.DeleteAsync(id);
        }
    }
}
