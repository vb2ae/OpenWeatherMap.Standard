using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard
{
    internal class RestServiceCaller : IRestService
    {
        private static HttpClient httpClient = new HttpClient();

        public async Task<WeatherData> GetAsync(string url)
        {
            var json = await httpClient.GetStringAsync(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(json);
        }
    }
}
