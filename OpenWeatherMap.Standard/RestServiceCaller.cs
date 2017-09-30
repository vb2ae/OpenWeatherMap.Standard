using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard
{
    class RestServiceCaller : IRestService
    {
        HttpClient http = new HttpClient();

        public async Task<WeatherData> GetAsync(string url)
        {
            WeatherData weather = null;

            HttpClient http = new HttpClient();
            string json = "";
            json = await http.GetStringAsync(url);
            weather = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(json);

            return weather;
        }
    }
}
