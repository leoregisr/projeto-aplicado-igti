using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PA_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string username, string password)
        {
            return new JsonResult("");
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            return new JsonResult("");
        }

        [HttpPost]
        [Route("SendNewPassword")]
        public IActionResult SendNewPassword(string username)
        {
            return new JsonResult("");
        }

        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(string username, string oldPassword, string newPassword)
        {
            return new JsonResult("");
        }
    }
}
