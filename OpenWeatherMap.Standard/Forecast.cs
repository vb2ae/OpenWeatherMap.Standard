using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard
{
    public class Forecast
    {
        private IRestService service = new RestServiceCaller();

        public Forecast()
        {
            
        }
        public Forecast(IRestService rest)
        {
            service = rest;
        }
        private string GetWeatherDataByZipUrl(string appId, string zipCode, string countryCode, WeatherUnits units)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?zip={zipCode},{countryCode}&appid={appId}&units={units.ToString()}";
        }

        private string GetWeatherDataByCityNameUrl(string appId, string cityName, string countryCode, WeatherUnits units)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?q={cityName},{countryCode}&appid={appId}&units={units.ToString()}";
        }

        private string GetWeatherDataByCityIdUrl(string appId, int cityId, WeatherUnits units)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?Id={cityId}&appid={appId}&units={units.ToString()}";
        }

        public async Task<WeatherData> GetWeatherDataByZipAsync(string appId, string zipCode, string countryCode = "us", WeatherUnits units = WeatherUnits.Standard)
        {
            try
            {
                string url = GetWeatherDataByZipUrl(appId, zipCode, countryCode, units);
                return await service.GetAsync(url);
            }
            catch
            {
                return null;
            }
        }

        public async Task<WeatherData> GetWeatherDataByCityNameAsync(string appId, string cityName, string countryCode = "us", WeatherUnits units = WeatherUnits.Standard)
        {
            try
            {
                string url = GetWeatherDataByCityNameUrl(appId, cityName, countryCode, units);
                return await service.GetAsync(url);
            }
            catch
            {
                return null;
            }
        }

        public async Task<WeatherData> GetWeatherDataByCityIdAsync(string appId, int cityId, WeatherUnits units = WeatherUnits.Standard)
        {
            try
            {
                string url = GetWeatherDataByCityIdUrl(appId, cityId, units);
                return await service.GetAsync(url);
            }
            catch
            {
                return null;
            }
        }

    }
}
