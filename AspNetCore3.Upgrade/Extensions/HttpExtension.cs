using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspNetCore3.Upgrade.Extensions
{
    public static class HttpExtension
    {
        public static async Task<T> ReadModelAsAsync<T>(this HttpContent content)
        {
            var resultString = await content.ReadAsStringAsync();
            var resultModel = JsonSerializer.Deserialize<T>(resultString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return resultModel;
        }
    }
}
