using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PA.Core.Domain.Services;

namespace PA_API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ClientService _clientService;

        public ClientController(ILogger<ClientController> logger, ClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpGet]
        [Route("Clients")]
        public IActionResult ListClients()
        {
            var timeCardRegisters = _clientService.ListAll();

            return new JsonResult(timeCardRegisters);
        }

        [HttpGet]
        [Route("{clientId}/Projects")]
        public IActionResult Projects(int clientId)
        {
            var timeCardRegisters = _clientService.ListProjectsByClientId(clientId);

            return new JsonResult(timeCardRegisters);
        }
    }
}
