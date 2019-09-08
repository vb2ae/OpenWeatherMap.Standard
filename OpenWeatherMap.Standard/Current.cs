using Newtonsoft.Json;
using OpenWeatherMap.Standard.Enums;
using OpenWeatherMap.Standard.Interfaces;
using OpenWeatherMap.Standard.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard
{
    /// <summary>
    /// Forecast class
    /// </summary>
    public class Current
    {
        /// <summary>
        /// the API_ROOT
        /// </summary>
        private const string API_ROOT = "api.openweathermap.org/data";

        /// <summary>
        /// the API version
        /// </summary>
        private const string API_VERSION = "/2.5";

        /// <summary>
        /// weather request root
        /// </summary>
        private const string WEATHER_REQUESTS_ROOT = "/weather";

        /// <summary>
        /// the rest service to perform our web calls
        /// </summary>
        public IRestService Service { get; set; }

        private string appId;
        /// <summary>
        /// the OWM app id to be used
        /// </summary>
        public string AppId
        {
            get => appId;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("AppId must NOT be null or empty string");
                appId = value;
            }
        }

        /// <summary>
        /// the measurements system to be used as the default unless specified
        /// <para />
        /// its default is Metric
        /// </summary>
        public WeatherUnits Units { get; set; } = WeatherUnits.Metric;

        /// <summary>
        /// indicate weather to call the API through HTTPS or not.
        /// <para />
        /// it's highly recommended to leave it true
        /// </summary>
        public bool UseHTTPS { get; set; } = true;

        /// <summary>
        /// default constructor that uses the default IRestService implementation
        /// </summary>
        /// <param name="_appId">OWM app id</param>
        public Current(string _appId)
        {
            if (string.IsNullOrEmpty(_appId))
                throw new ArgumentNullException("_appId", "AppId must NOT be null or empty string");
            AppId = _appId;
            Service = new Implementations.RestServiceCaller();
        }

        /// <summary>
        /// a constructor that allows you to set your default measurements system
        /// </summary>
        /// <param name="_appId">OWM app id</param>
        /// <param name="_units">desired system</param>
        public Current(string _appId, WeatherUnits _units)
        {
            if (string.IsNullOrEmpty(_appId))
                throw new ArgumentNullException("_appId", "AppId must NOT be null or empty string");
            AppId = _appId;
            Service = new Implementations.RestServiceCaller();
            Units = _units;
        }

        /// <summary>
        /// a constructor that allows you to use your own IRestService implementation
        /// </summary>
        /// <param name="_appId">OWM app id</param>
        /// <param name="rest">your IRestService implementation</param>
        public Current(string _appId, IRestService rest)
        {
            if (string.IsNullOrEmpty(_appId))
                throw new ArgumentNullException("_appId", "AppId must NOT be null or empty string");
            AppId = _appId;
            Service = rest;
        }

        /// <summary>
        /// a constructor that allows you to use your own IRestService implementation and set default measurements system
        /// </summary>
        /// <param name="_appId">OWM app id</param>
        /// <param name="rest">your IRestService implementation</param>
        /// <param name="_units">desired system</param>
        public Current(string _appId, IRestService rest, WeatherUnits _units)
        {
            if (string.IsNullOrEmpty(_appId))
                throw new ArgumentNullException("_appId", "AppId must NOT be null or empty string");
            AppId = _appId;
            Service = rest;
            Units = _units;
        }

        /// <summary>
        /// get the API call url
        /// </summary>
        /// <param name="query">query parameters and values. ex: city=baghdad</param>
        /// <returns>string url</returns>
        private string GetUrl(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException("query", "query can NOT be null or empty string");
            return $"http{(UseHTTPS ? "s" : "")}://{API_ROOT}{API_VERSION}{WEATHER_REQUESTS_ROOT}?{query}&units={Units.ToString()}&appid={AppId}";
        }

        /// <summary>
        /// get the API call url to get weather data by zip code
        /// </summary>
        /// <param name="zipCode">zip code</param>
        /// <param name="countryCode">country code</param>
        /// <returns>string url</returns>
        private string GetWeatherDataByZipUrl(string zipCode, string countryCode)
        {
            if (string.IsNullOrEmpty(zipCode))
                throw new ArgumentNullException("zipCode", "zipCode can NOT be null or empty string");
            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentNullException("countryCode", "countryCode can NOT be null or empty string");
            return GetUrl($"zip={zipCode},{countryCode}");
        }

        /// <summary>
        /// get the API call url to get weather data by city name and country code
        /// </summary>
        /// <param name="cityName">city name</param>
        /// <param name="countryCode">country code</param>
        /// <returns>string url</returns>
        private string GetWeatherDataByCityNameUrl(string cityName, string countryCode)
        {
            if (string.IsNullOrEmpty(cityName))
                throw new ArgumentNullException("cityName", "cityName can NOT be null or empty string");
            string q = $"q={cityName}";
            if (!string.IsNullOrEmpty(countryCode))
                q += $",{countryCode}";
            return GetUrl(q);
        }

        /// <summary>
        /// get the API call url to get weather data by city id
        /// </summary>
        /// <param name="cityId">city id</param>
        /// <returns>string url</returns>
        private string GetWeatherDataByCityIdUrl(int cityId)
        {
            return GetUrl($"id={cityId}");
        }

        /// <summary>
        /// get the API call url to get weather data by latitude and longitude
        /// </summary>
        /// <param name="lat">latitude</param>
        /// <param name="lon"></param>
        /// <returns>string url</returns>
        private string GetWeatherDataByCoordsUrl(double lat, double lon)
        {
            return GetUrl($"lat={lat}&lon={lon}");
        }

        /// <summary>
        /// get weather data by zip code
        /// </summary>
        /// <param name="zipCode">zip code</param>
        /// <param name="countryCode">country code</param>
        /// <returns>WeatherData</returns>
        public async Task<WeatherData> GetWeatherDataByZipAsync(string zipCode, string countryCode)
        {
            if (string.IsNullOrEmpty(zipCode))
                throw new ArgumentNullException("zipCode", "zipCode can NOT be null or empty string");
            var url = GetWeatherDataByZipUrl(zipCode, countryCode);
            return await Service.GetAsync(url);
        }

        /// <summary>
        /// get weather data by zip code
        /// </summary>
        /// <param name="zipCode">zip code</param>
        /// <param name="countryCode">country code</param>
        /// <returns>Task of WeatherData</returns>
        public Task<WeatherData> GetWeatherDataByZip(string zipCode, string countryCode)
        {
            if (string.IsNullOrEmpty(zipCode))
                throw new ArgumentNullException("zipCode", "zipCode can NOT be null or empty string");
            var url = GetWeatherDataByZipUrl(zipCode, countryCode);
            return Service.GetAsync(url);
        }

        /// <summary>
        /// get weather data by city name and country code
        /// </summary>
        /// <param name="cityName">city name</param>
        /// <param name="countryCode">country code</param>
        /// <returns>WeatherData</returns>
        public async Task<WeatherData> GetWeatherDataByCityNameAsync(string cityName, string countryCode = "")
        {
            if (string.IsNullOrEmpty(cityName))
                throw new ArgumentNullException("cityName", "cityName can NOT be null or empty string");
            var url = GetWeatherDataByCityNameUrl(cityName, countryCode);
            return await Service.GetAsync(url);
        }

        /// <summary>
        /// get weather data by city name and country code
        /// </summary>
        /// <param name="cityName">city name</param>
        /// <param name="countryCode">country code</param>
        /// <returns>Task of WeatherData</returns>
        public Task<WeatherData> GetWeatherDataByCityName(string cityName, string countryCode = "")
        {
            if (string.IsNullOrEmpty(cityName))
                throw new ArgumentNullException("cityName", "cityName can NOT be null or empty string");
            var url = GetWeatherDataByCityNameUrl(cityName, countryCode);
            return Service.GetAsync(url);
        }

        /// <summary>
        /// get weather data by city id
        /// </summary>
        /// <param name="cityId">city id</param>
        /// <returns>WeatherData</returns>
        public async Task<WeatherData> GetWeatherDataByCityIdAsync(int cityId)
        {
            var url = GetWeatherDataByCityIdUrl(cityId);
            return await Service.GetAsync(url);
        }

        /// <summary>
        /// get weather data by city id
        /// </summary>
        /// <param name="cityId">city id</param>
        /// <returns>Task of WeatherData</returns>
        public Task<WeatherData> GetWeatherDataByCityId(int cityId)
        {
            var url = GetWeatherDataByCityIdUrl(cityId);
            return Service.GetAsync(url);
        }

        /// <summary>
        /// get weather data by coordinates
        /// </summary>
        /// <param name="lat">latitude</param>
        /// <param name="lon">longitude</param>
        /// <returns> WeatherData</returns>
        public async Task<WeatherData> GetWeatherDataByCoordinatesAsync(double lat, double lon)
        {
            var url = GetWeatherDataByCoordsUrl(lat, lon);
            return await Service.GetAsync(url);
        }

        /// <summary>
        /// get weather data by coordinates
        /// </summary>
        /// <param name="lat">latitude</param>
        /// <param name="lon">longitude</param>
        /// <returns>Task of WeatherData</returns>
        public Task<WeatherData> GetWeatherDataByCoordinates(double lat, double lon)
        {
            var url = GetWeatherDataByCoordsUrl(lat, lon);
            return Service.GetAsync(url);
        }

        /// <summary>
        /// get weather data by coordinates
        /// </summary>
        /// <param name="coordinates">coordinates object</param>
        /// <returns>WeatherData</returns>
        public async Task<WeatherData> GetWeatherDataByCoordinatesAsync(Coordinates coordinates)
        {
            return await GetWeatherDataByCoordinates(coordinates.Latitude, coordinates.Longitude);
        }

        /// <summary>
        /// get weather data by coordinates
        /// </summary>
        /// <param name="coordinates">coordinates object</param>
        /// <returns>Task of WeatherData</returns>
        public Task<WeatherData> GetWeatherDataByCoordinates(Coordinates coordinates)
        {
            return GetWeatherDataByCoordinates(coordinates.Latitude, coordinates.Longitude);
        }

    }
}
