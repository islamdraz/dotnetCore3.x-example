using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore3.Upgrade.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace AspNetCore3.Upgrade.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IConferenceService _conferenceService;

        public StatisticsController(IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _conferenceService.GetStatistics());
        }
    }
}