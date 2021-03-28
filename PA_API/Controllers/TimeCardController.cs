using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PA_API.Models.TimeCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PA_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeCardController : ControllerBase
    {
        private readonly ILogger<TimeCardController> _logger;

        public TimeCardController(ILogger<TimeCardController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("ClockIn")]
        public IActionResult ClockIn()
        {
            return new JsonResult("");
        }

        [HttpPut]
        [Route("EditTimeCardRegister")]
        public IActionResult EditTimeCardRegister(int id, DateTime time)
        {
            return new JsonResult("");
        }

        [HttpDelete]
        [Route("DeleteTimeCardRegister")]
        public IActionResult DeleteTimeCardRegister(int id)
        {
            return new JsonResult("");
        }

        [HttpGet]
        [Route("ListTimeCardRegisterByDate")]
        [ProducesResponseType(200, Type = typeof(List<TimeCardRegisterViewModel>))]
        public IActionResult ListTimeCardRegisterByDate([FromQuery] DateTime date)
        {
            return new JsonResult("");
        }

        [HttpGet]
        [Route("ListTimeCardRegisterByYearAndMonth")]
        [ProducesResponseType(200, Type = typeof(List<TimeCardRegisterViewModel>))]
        public IActionResult ListTimeCardRegisterByYearAndMonth([FromQuery] int year, [FromQuery] int monthNumber)
        {
            return new JsonResult("");
        }
    }
}
