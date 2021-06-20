using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PA.Core.Domain.Services;
using PA_API.Models.User;

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
        public IActionResult Login([FromBody]UserViewModel model)
        {
            try
            {
                var user = _userService.Login(model.Email, model.Password);

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
