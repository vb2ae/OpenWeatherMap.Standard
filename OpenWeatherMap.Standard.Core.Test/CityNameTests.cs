using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenWeatherMap.Standard.Enums;
using OpenWeatherMap.Standard.Interfaces;
using OpenWeatherMap.Standard.Models;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard.Core.Test
{
    [TestClass()]
    public class CityNameTests
    {
        private const string expectedJson = "{\"coord\":{\"lon\":-80.74,\"lat\":28.39},\"weather\":[{\"id\":701,\"main\":\"Mist\",\"description\":\"mist\",\"icon\":\"50d\"},{\"id\":721,\"main\":\"Haze\",\"description\":\"haze\",\"icon\":\"50d\"}],\"base\":\"stations\",\"main\":{\"temp\":297.36,\"pressure\":1016,\"humidity\":100,\"temp_min\":295.37,\"temp_max\":299.26},\"visibility\":8047,\"wind\":{\"speed\":0.85,\"deg\":335.948},\"clouds\":{\"all\":20},\"dt\":1567944353,\"sys\":{\"type\":1,\"id\":6286,\"message\":0.0095,\"country\":\"US\",\"sunrise\":1567940681,\"sunset\":1567985826},\"timezone\":-14400,\"id\":4151440,\"name\":\"Cocoa\",\"cod\":200}";
        private readonly WeatherData expected;

        public CityNameTests()
        {
            expected = JsonConvert.DeserializeObject<WeatherData>(expectedJson) ?? new WeatherData();
        }
        [TestMethod()]
        public void TestCloudy()
        {
            var fake = A.Fake<IRestService>();
            A.CallTo(() => fake.GetAsync("https://api.openweathermap.org/data/2.5/weather?q=Cocoa,FL,USA&units=Standard&appid=YOUR_API_KEY&lang=en", "https://openweathermap.org/img/wn", false)).Returns(Task.FromResult(expected));
            var weather = new Current(Consts.API_KEY, fake, Enums.WeatherUnits.Standard, Languages.English);
            var res = weather.GetWeatherDataByCityNameAsync("Cocoa,FL", "USA").Result;
            Assert.AreEqual(expected.Coordinates.Latitude, res.Coordinates.Latitude);
        }
    }
}
