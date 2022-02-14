using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OpenWeatherMap.Standard.Enums;
using OpenWeatherMap.Standard.Models;

namespace OpenWeatherMap.Standard.Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var key = "USE_YOUR_KEY_PLEASE";
            var current = new Current(key)
            {
                Languages = Languages.German,
                FetchIcons = true,
                ForecastTimestamps = 5
            };

            WeatherData data = null;
            ForecastData forecastData = null;

            var getWeather = Task.Run(async () => { data = await current.GetWeatherDataByZipAsync("32927", "us"); });
            getWeather.Wait();
            Console.WriteLine(
                $"[zip code]: current temperature in area zip-coded 32927 US is: {data.WeatherDayInfo.Temperature}");

            var getWeatherCity = Task.Run(async () =>
            {
                data = await current.GetWeatherDataByCityNameAsync("berlin", "de");
            });
            getWeatherCity.Wait();
            Console.WriteLine(
                $"[city, country code]: current temperature in Berlin, Germany is: {data.WeatherDayInfo.Temperature}");

            var getWeatherCityWOCountry = Task.Run(async () =>
            {
                data = await current.GetWeatherDataByCityNameAsync("baghdad");
            });
            getWeatherCityWOCountry.Wait();
            Console.WriteLine($"[city]: current temperature in Baghdad is: {data.WeatherDayInfo.Temperature}");

            var getWeatherCoords = Task.Run(async () =>
            {
                data = await current.GetWeatherDataByCoordinatesAsync(-33.865143, 151.209900);
            });
            getWeatherCoords.Wait();
            Console.WriteLine($"[lat, lon]: current temperature in Sydney is: {data.WeatherDayInfo.Temperature}");

            var saveIcon = Task.Run(async () =>
            {
                await using var fs = new FileStream($"{data?.Weathers[0]?.Icon}.png", FileMode.Create);
                await fs.WriteAsync(data?.Weathers[0]?.IconData);
            });
            saveIcon.Wait();
            
            var getForecastWeather = Task.Run(async () =>
            {
                forecastData = await current.GetForecastDataByCityNameAsync("Schnelsen");
            });
            getForecastWeather.Wait();
            foreach (var weatherDayInfo in forecastData.WeatherData.Select(a => new
                     {
                         a.WeatherDayInfo,
                         a.AcquisitionDateTime
                     }))
                Console.WriteLine(
                    $"[forecast]: Forecast for Schnelsen, Germany at {weatherDayInfo.AcquisitionDateTime}, maximum temp: {weatherDayInfo.WeatherDayInfo.MaximumTemperature}, minimum temp: {weatherDayInfo.WeatherDayInfo.MinimumTemperature}");

            var forecastDataSync = current.GetForecastDataByCityName("schnelsen");

            Console.ReadLine();
        }
    }
}