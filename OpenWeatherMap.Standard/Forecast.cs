using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard
{
    public class Forecast
    {
        IRestService service = null;
        public Forecast(IRestService rest)
        {
            service = rest;
        }

        public Forecast()
        {
            service = new RestServiceCaller();
        }

        public async Task<WeatherData> GetWeatherDataByZipAsync(string appId, string zipCode, string countryCode="USA", WeatherUnits units = WeatherUnits.Standard)
        {
            WeatherData weather = null;
            try
            {
                string url = $"http://api.openweathermap.org/data/2.5/weather?zip={zipCode},{countryCode}&appid={appId}&units={units.ToString()}";
                weather = await service.GetAsync(url);
            }
            catch
            {
                weather = null;
            }

            return weather;
        }

        public async Task<WeatherData> GetWeatherDataByCityNameAsync(string appId, string cityName, string countryCode = "USA", WeatherUnits units = WeatherUnits.Standard)
        {
            WeatherData weather = null;
            try
            {
                string url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName},{countryCode}&appid={appId}&units={units.ToString()}";
                weather = await service.GetAsync(url);
            }
            catch
            {
                weather = null;
            }

            return weather;
        }

        public async Task<WeatherData> GetWeatherDataByCityIdAsync(string appId, int cityId,  WeatherUnits units = WeatherUnits.Standard)
        {
            WeatherData weather = null;
            try
            {
                string url = $"http://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={appId}&units={units.ToString()}";
                weather = await service.GetAsync(url);
            }
            catch
            {
                weather = null;
            }

            return weather;
        }

    }
}
