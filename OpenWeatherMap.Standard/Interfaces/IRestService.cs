using System.Collections.Generic;
using System.Threading.Tasks;
using OpenWeatherMap.Standard.Models;

namespace OpenWeatherMap.Standard.Interfaces
{
    /// <summary>
    ///     interface to have the required method to call the REST API
    /// </summary>
    public interface IRestService
    {
        /// <summary>
        /// Get air pollution data and deserialize them
        /// </summary>
        Task<AirPollution> GetAirPollutionAsync(string url);

        /// <summary>
        ///     get weather data and deserialize them
        /// </summary>
        /// <param name="url">the url to perform the request</param>
        /// <param name="iconDataBaseUrl">the base url to the icon's data</param>
        /// <param name="fetchIconData">whether to fetch icon's data or not</param>
        /// <returns><see cref="WeatherData"/> object</returns>
        Task<WeatherData> GetAsync(string url, string iconDataBaseUrl = "https://openweathermap.org/img/wn", bool fetchIconData = false);

        /// <summary>
        ///     get forecast data and deserialize them
        /// </summary>
        /// <param name="url">the url to perform the request</param>
        /// <param name="iconDataBaseUrl">the base url to the icon's data</param>
        /// <param name="fetchIconData">whether to fetch icon's data or not</param>
        /// <returns><see cref="ForecastData" /> object</returns>
        Task<ForecastData> GetForecastAsync(string url, string iconDataBaseUrl = "https://openweathermap.org/img/wn", bool fetchIconData = false);

        /// <summary>
        /// Get cordinates of a city
        /// </summary>
        Task<List<GeoLocation>> GetGeoLocationAsync(string url);
    }
}