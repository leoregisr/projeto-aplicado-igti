using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PA_API.Models.TimeCard;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using PA.Core.Domain.Services;

namespace PA_API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TimeCardController : ControllerBase
    {
        private readonly ILogger<TimeCardController> _logger;
        private readonly TimeCardService _timeCardService;
        private readonly UserService _userService;

        public TimeCardController(ILogger<TimeCardController> logger, TimeCardService timeCardService, UserService userService)
        {
            _logger = logger;
            _timeCardService = timeCardService;
            _userService = userService;
        }

        [HttpPost]
        [Route("ClockIn")]
        public IActionResult ClockIn(string projectName)
        {
            if (!User.Identity.IsAuthenticated)
                return new UnauthorizedResult();

            var user = _userService.GetByUserName(User.Identity.Name);

            var timeCardRegister = _timeCardService.SaveCardRegister(user.Id, DateTime.Now, projectName);

            return new JsonResult(timeCardRegister);
        }

        [HttpPut]
        [Route("EditTimeCardRegister")]
        public IActionResult EditTimeCardRegister(int id, DateTime time, string projectName)
        {
            if (!User.Identity.IsAuthenticated)
                return new UnauthorizedResult();

            var user = _userService.GetByUserName(User.Identity.Name);

            var timeCardRegister = _timeCardService.GetTimeCardModelById(id);

            if (timeCardRegister.UserId != user.Id || !User.IsInRole("DP_ADMIN"))
                return new ForbidResult();

            timeCardRegister = _timeCardService.EditTimeCardRegister(timeCardRegister.ID, time, projectName);

            return new JsonResult(timeCardRegister);
        }

        [HttpDelete]
        [Route("DeleteTimeCardRegister")]
        public IActionResult DeleteTimeCardRegister(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return new UnauthorizedResult();

            var user = _userService.GetByUserName(User.Identity.Name);

            var timeCardRegister = _timeCardService.GetTimeCardModelById(id);

            if (timeCardRegister.UserId != user.Id || !User.IsInRole("DP_ADMIN"))
                return new ForbidResult();

            _timeCardService.DeleteTimeCardRegister(timeCardRegister.ID);

            return Ok();
        }

        [HttpGet]
        [Route("ListTimeCardRegisterByDate")]
        [ProducesResponseType(200, Type = typeof(List<TimeCardRegisterViewModel>))]
        public IActionResult ListTimeCardRegisterByDate([FromQuery] DateTime date, [FromQuery] string userName)
        {
            if (!User.Identity.IsAuthenticated)
                return new UnauthorizedResult();

            if (string.IsNullOrEmpty(userName))
                userName = User.Identity.Name;

            var user = _userService.GetByUserName(userName);

            if (User.Identity.Name != user.Username || !User.IsInRole("DP_ADMIN"))
                return new ForbidResult();

            var timeCardRegisters = _timeCardService.ListTimeCardRegisterByDate(user.Id, date);

            return new JsonResult(timeCardRegisters);
        }

        [HttpGet]
        [Route("ListTimeCardRegisterByYearAndMonth")]
        [ProducesResponseType(200, Type = typeof(List<TimeCardRegisterViewModel>))]
        public IActionResult ListTimeCardRegisterByYearAndMonth([FromQuery] int year, [FromQuery] int monthNumber, [FromQuery] string userName)
        {
            if (!User.Identity.IsAuthenticated)
                return new UnauthorizedResult();

            if (string.IsNullOrEmpty(userName))
                userName = User.Identity.Name;

            var user = _userService.GetByUserName(userName);

            if (User.Identity.Name != user.Username || !User.IsInRole("DP_ADMIN"))
                return new ForbidResult();

            var timeCardRegisters = _timeCardService.ListTimeCardRegisterByYearAndMonth(user.Id, year, monthNumber);

            return new JsonResult(timeCardRegisters);
        }
    }
}
