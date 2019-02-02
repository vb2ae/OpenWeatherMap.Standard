using System;
using System.Threading.Tasks;
using FakeItEasy;
using Newtonsoft.Json;
using NUnit.Framework;

namespace OpenWeatherMap.Standard.NUnit
{
    [TestFixture()]
    public class CityNameTests
    {
        private string cloudy = "{\"coord\":{\"Longitude\":-80.8,\"Latitude\":28.46},\"weather\":[{\"Id\":801,\"WeatherDayInfo\":\"Clouds\",\"Description\":\"few clouds\",\"Icon\":\"02n\"}],\"base\":\"stations\",\"WeatherDayInfo\":{\"Temperature\":76.37,\"Pressure\":1014,\"Humidity\":83,\"MinimumTemperature\":73.4,\"MaximumTemperature\":78.8},\"Visibility\":16093,\"wind\":{\"speed\":5.82,\"deg\":340},\"clouds\":{\"all\":20},\"AcquisitionDateTime\":1505642280,\"DayInfo\":{\"type\":1,\"Id\":643,\"message\":0.0038,\"country\":\"US\",\"sunrise\":1505646573,\"sunset\":1505690690},\"Id\":0,\"Name\":\"Cocoa\",\"HttpStatusCode\":200}";
        private WeatherData expect;

        public CityNameTests()
        {
            expect = JsonConvert.DeserializeObject<WeatherData>(cloudy);
        }
        [Test()]
        public void TestCloudy()
        {
            var fake = A.Fake<IRestService>();
            A.CallTo(() => fake.GetAsync("http://api.openweathermap.org/data/2.5/weather?q=Cocoa,FL,USA&appid=UnitTest&units=Standard")).Returns(Task.FromResult(expect));
            var weather = new Forecast(fake);
            string actual = weather.GetWeatherDataByCityNameAsync("UnitTest", "Cocoa,FL", "USA", WeatherUnits.Standard)
                .Result.Weathers[0].Description;
            Assert.AreEqual("few clouds", actual);
        }
    }
}
