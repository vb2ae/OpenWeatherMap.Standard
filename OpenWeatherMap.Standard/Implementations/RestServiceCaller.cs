using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeatherMap.Standard.Interfaces;
using OpenWeatherMap.Standard.Models;

namespace OpenWeatherMap.Standard.Implementations
{
    /// <summary>
    ///     "default" implementation of IRestService
    /// </summary>
    internal class RestServiceCaller : IRestService
    {
        private static HttpClient httpClient;

        /// <summary>
        ///     the HttpClient to be used
        /// </summary>
        private static HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                    httpClient = new HttpClient {Timeout = TimeSpan.FromSeconds(10)};
                return httpClient;
            }
        }

        /// <summary>
        ///     get data and deserialize them
        /// </summary>
        /// <param name="url">the url to perform the request</param>
        /// <param name="iconDataBaseUrl">the root url to the weather icons</param>
        /// <returns>WeatherData object</returns>
        public async Task<WeatherData> GetAsync(string url, string iconDataBaseUrl)
        {
            try
            {
                var json = await HttpClient.GetStringAsync(url);
                var wd = JsonConvert.DeserializeObject<WeatherData>(json);

                //Get weather-icons as byte-arrays
                await FetchIconData(wd, iconDataBaseUrl);

                return wd;
            }
#if DEBUG
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
#else
            catch
            {
                return null;
            }
#endif
        }

        /// <summary>
        ///     fetches the corresponding icon of the current weather-condition and adds it
        ///     to the <see cref="Weather.IconData" />-Property of the <see cref="WeatherData" />-array
        /// </summary>
        /// <param name="weatherData">a filled <see cref="WeatherData" /> object</param>
        /// <param name="iconDataBaseUrl">the base-url where the images are stored</param>
        /// <returns></returns>
        private static async Task FetchIconData(WeatherData weatherData, string iconDataBaseUrl)
        {
            foreach (var weather in weatherData.Weathers)
            {
                try
                {
                    var iconUrl = $"{iconDataBaseUrl}/{weather.Icon}.png";
                    var iconData = await HttpClient.GetByteArrayAsync(iconUrl);
                    weather.IconData = iconData;
                }
#if DEBUG
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
#else
            catch
            {
                return null;
            }
#endif
            }
        }
    }
}