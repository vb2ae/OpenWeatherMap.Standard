using System;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "yourkeygoeshere";
            Forecast forecast = new Forecast();
            WeatherData data = null;
            Task getWeather = Task.Run(async () => { data = await forecast.GetWeatherDataByZipAsync(key, "32927", "us", WeatherUnits.metric); });
            getWeather.Wait();

            WeatherData dataCity = null;
            Task getWeatherCity = Task.Run(async () => { dataCity = await forecast.GetWeatherDataByCityNameAsync(key, "cocoa,fl"); });
            getWeatherCity.Wait();
            //4151440

            WeatherData dataId = null;
            Task getWeatherId = Task.Run(async () => { dataId = await forecast.GetWeatherDataByCityIdAsync(key, 4151440); });
            getWeatherId.Wait();
            Console.WriteLine(dataCity.weather[0].description);
        }
    }
}
