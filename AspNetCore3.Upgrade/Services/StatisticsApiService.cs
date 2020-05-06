using AspNetCore3.Upgrade.Extensions;
using Shared;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetCore3.Upgrade.Services
{
    public class StatisticsApiService : IStatisticsApiService
    {
        private readonly HttpClient _client;
        public StatisticsApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("baseHttpClient");
        }
        public async Task<StatisticsModel> GetStatistics()
        {
            var response = await _client.GetAsync($"v1/statistics");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadModelAsAsync<StatisticsModel>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }
    }


}
