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
        private readonly IStatisticsApiService _statisticsApiService;


        public StatisticsViewComponent(IStatisticsApiService statisticsApiService)
        {
            _statisticsApiService = statisticsApiService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string stateCaption)
        {
            ViewBag.Caption = stateCaption;

           return  View(await _statisticsApiService.GetStatistics());

        }
    }
}
