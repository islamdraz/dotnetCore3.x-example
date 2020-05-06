using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace AspNetCore3.Upgrade.Services
{
    public interface IStatisticsApiService
    {
        Task<StatisticsModel> GetStatistics();
    }
}
