using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore3.Upgrade.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore3.Upgrade.ViewComponents
{
    public class StatisticsViewComponent:ViewComponent
    {
        private readonly IConferenceService _conferenceMemoryService;

        public StatisticsViewComponent(IConferenceService conferenceMemoryService)
        {
            _conferenceMemoryService = conferenceMemoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string stateCaption)
        {
            ViewBag.Caption = stateCaption;

           return  View(await _conferenceMemoryService.GetStatistics());

        }
    }
}
