using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PA_API.Services;

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
        public IActionResult Login(string username, string password)
        {
            var user = _userService.Login(username, password);

            var token = TokenService.GenerateToken(user);

            return Ok(new
            {
                user = user,
                token = token
            });
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
