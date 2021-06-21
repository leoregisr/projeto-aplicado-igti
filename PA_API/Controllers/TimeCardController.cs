using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PA_API.Models.TimeCard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PA.Core.Contracts.TransferObjects;
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
        public async Task<IActionResult> ClockIn([FromBody] int projectId)
        {
            if (!User.Identity.IsAuthenticated)
                return new UnauthorizedResult();

            var timeCardRegister = await _timeCardService.AddTimeCardRegister(new TimeCardRegisterDto()
            {
                StartDate = DateTime.Now,
                ProjectId = projectId,
                UserEmail = User.Identity.Name 
            });

            return new JsonResult(timeCardRegister);
        }

        [HttpPut]
        [Route("EditTimeCardRegister")]
        public async Task<IActionResult> EditTimeCardRegister([FromBody] TimeCardRegisterDto timeCardRegister)
        {
            if (!User.Identity.IsAuthenticated)
                return new UnauthorizedResult();

            var user = _userService.GetUserByEmail(User.Identity.Name);

            if (timeCardRegister.UserId != user.Id || !User.IsInRole("DP_ADMIN"))
                return new ForbidResult();

            timeCardRegister = await _timeCardService.EditTimeCardRegister(timeCardRegister);

            return new JsonResult(timeCardRegister);
        }

        [HttpDelete]
        [Route("DeleteTimeCardRegister/{id}")]
        public async Task<IActionResult> DeleteTimeCardRegister([FromRoute] int id)
        {
            if (!User.Identity.IsAuthenticated)
                return new UnauthorizedResult();

            var user = _userService.GetUserByEmail(User.Identity.Name);

            var timeCardRegister = _timeCardService.GetTimeCardModelById(id);

            if (timeCardRegister.UserId != user.Id || !User.IsInRole("DP_ADMIN"))
                return new ForbidResult();

            await _timeCardService.DeleteTimeCardRegister(timeCardRegister.Id);

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

            var user = _userService.GetUserByEmail(userName);

            if (User.Identity.Name != user.Email || !User.IsInRole("DP_ADMIN"))
                return new ForbidResult();

            var timeCardRegisters = _timeCardService.ListTimeCardRegisterByDate(user.Email, date);

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

            var user = _userService.GetUserByEmail(userName);

            if (User.Identity.Name != user.Email || !User.IsInRole("DP_ADMIN"))
                return new ForbidResult();

            var timeCardRegisters = _timeCardService.ListTimeCardRegisterByYearAndMonth(user.Email, year, monthNumber);

            return new JsonResult(timeCardRegisters);
        }
    }
}
