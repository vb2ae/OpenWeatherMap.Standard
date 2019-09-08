using OpenWeatherMap.Standard.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard.Implementations
{
    /// <summary>
    /// "default" implementation of IRestService
    /// </summary>
    internal class RestServiceCaller : Interfaces.IRestService
    {
        private static HttpClient httpClient;
        /// <summary>
        /// the HttpClient to be used
        /// </summary>
        private static HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                    httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(10) };
                return httpClient;
            }
        }

        /// <summary>
        /// get data and deserialize them
        /// </summary>
        /// <param name="url">the url to perform the request</param>
        /// <returns>WeatherData object</returns>
        public async Task<WeatherData> GetAsync(string url)
        {
            try
            { 
                var json = await HttpClient.GetStringAsync(url);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(json);
            }
#if DEBUG
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
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
