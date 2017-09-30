using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard
{
    public interface IRestService
    {
        Task<WeatherData> GetAsync(string url);

    }
}
