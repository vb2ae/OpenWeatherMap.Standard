using OpenWeatherMap.Standard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard.Interfaces
{
    /// <summary>
    /// interface to have the required method to call the REST API
    /// </summary>
    public interface IRestService
    {
        /// <summary>
        /// get data and deserialize them
        /// </summary>
        /// <param name="url">the url to perform the request</param>
        /// <param name="iconDataBaseUrl">the base url to the icon's data</param>
        /// <returns>WeatherData object</returns>
        Task<WeatherData> GetAsync(string url, string iconDataBaseUrl);
    }
}
