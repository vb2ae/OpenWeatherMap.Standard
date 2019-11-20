using OpenWeatherMap.Standard.Enums;
using System;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard.Sample
{
using OpenWeatherMap.Standard.Models;
    internal class Program
    {
        private static void Main(string[] args)
        {
            string key = "USE_YOUR_KEY_PLEASE";
            Current current = new Current(key);
            WeatherData data = null;
            Task getWeather = Task.Run(async () => { data = await current.GetWeatherDataByZipAsync("32927", "us"); });
            getWeather.Wait();
            Console.WriteLine($"[zip code]: current temperature in area zip-coded 32927 US is: {data.WeatherDayInfo.Temperature}");

            Task getWeatherCity = Task.Run(async () => { data = await current.GetWeatherDataByCityNameAsync("berlin", "de"); });
            getWeatherCity.Wait();
            Console.WriteLine($"[city, country code]: current temperature in Berlin, Germany is: {data.WeatherDayInfo.Temperature}");

            Task getWeatherCityWOCountry = Task.Run(async () => { data = await current.GetWeatherDataByCityNameAsync("baghdad"); });
            getWeatherCityWOCountry.Wait();
            Console.WriteLine($"[city]: current temperature in Baghdad is: {data.WeatherDayInfo.Temperature}");

            Task getWeatherCoords = Task.Run(async () => { data = await current.GetWeatherDataByCoordinatesAsync(-33.865143, 151.209900); });
            getWeatherCoords.Wait();
            Console.WriteLine($"[lat, lon]: current temperature in Sydney is: {data.WeatherDayInfo.Temperature}");

            Console.ReadLine();

        }
    }
}
