using System;
using System.Threading.Tasks;
using FakeItEasy;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenWeatherMap.Standard.Interfaces;
using OpenWeatherMap.Standard.Models;

namespace OpenWeatherMap.Standard.Test
{
    [TestFixture()]
    public class ZipCodeTests
    {
        private const string expectedJson = "{\"coord\":{\"lon\":-80.8,\"lat\":28.46},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"base\":\"stations\",\"main\":{\"temp\":297.54,\"pressure\":1016,\"humidity\":100,\"temp_min\":295.37,\"temp_max\":299.82},\"visibility\":16093,\"wind\":{\"speed\":1.5,\"deg\":270},\"clouds\":{\"all\":1},\"dt\":1567945131,\"sys\":{\"type\":1,\"id\":6077,\"message\":0.0099,\"country\":\"US\",\"sunrise\":1567940694,\"sunset\":1567985843},\"timezone\":-14400,\"id\":0,\"name\":\"Cocoa\",\"cod\":200}";
        private readonly WeatherData expected;

        public ZipCodeTests()
        {
            expected = JsonConvert.DeserializeObject<WeatherData>(expectedJson);
        }

        [Test()]
        public void TestByZipCode()
        {
            var fake = A.Fake<IRestService>();
            A.CallTo(() => fake.GetAsync("http://api.openweathermap.org/data/2.5/weather?zip=32927,USA&appid=UnitTest&units=Standard")).Returns(Task.FromResult(expected));
            var weather = new Current(Consts.API_KEY, Enums.WeatherUnits.Standard);
            var res = weather.GetWeatherDataByZipAsync("32927", "US").Result;
            Assert.AreEqual(expected.Coordinates.Latitude, res.Coordinates.Latitude);
        }
    }
}
