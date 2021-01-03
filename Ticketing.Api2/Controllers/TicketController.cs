using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ticketing.Api.Models;
using Ticketing.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ticketing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketService _ticketService;

        public TicketController(ILogger<TicketController> logger,
            ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        // GET: api/ticket/initialize
        // will initialize single record in ticket container
        [HttpGet]
        [Route("/api/[controller]/initialize")]
        public string Initialize()
        {
            _ticketService.InitializeContainerAsync();
            var message = "Ticket container has been initialized with value";
            _logger.LogInformation(message);
            return message;
        }

        // GET: api/<TicketController>
        [HttpGet("ByUser")]
        public async Task<IEnumerable<Ticket>> GetByUser([FromQuery] string userId)
        {
            var tickets = await _ticketService.GetByUserAsync(userId);
            return tickets;
        }

        [HttpGet("ByJob")]
        public async Task<IEnumerable<Ticket>> GetByJob([FromQuery] string userId)
        {
            var tickets = await _ticketService.GetJobByUserAsync(userId);
            return tickets;
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public async Task<Ticket> Get(string id)
        {
            var ticket = await _ticketService.GetAsync(id);
            return ticket;
        }

        // POST api/<TicketController>
        [HttpPost]
        public async Task Post([FromBody] Ticket ticket)
        {
            await _ticketService.AddAsync(ticket);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] Ticket ticket)
        {
            await _ticketService.UpdateAsync(id, ticket);
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _ticketService.DeleteAsync(id);
        }
    }
}
