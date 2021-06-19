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
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly UserService _userService;

        public LoginController(ILogger<LoginController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var user = _userService.Login(email, password);

                var token = TokenService.GenerateToken(user);

                return Ok(new
                {
                    user = user,
                    token = token
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            return new JsonResult("");
        }

        [HttpPost]
        [Route("SendNewPassword")]
        public IActionResult SendNewPassword()
        {
            return new JsonResult("");
        }

        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(string oldPassword, string newPassword)
        {
            return new JsonResult("");
        }
    }
}
