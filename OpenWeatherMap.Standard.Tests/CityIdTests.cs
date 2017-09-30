using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard.Tests
{
    [TestClass]
    public class CityIdTests
    {
        string cloudy = "{\"coord\":{\"lon\":-80.8,\"lat\":28.46},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02n\"}],\"base\":\"stations\",\"main\":{\"temp\":76.37,\"pressure\":1014,\"humidity\":83,\"temp_min\":73.4,\"temp_max\":78.8},\"visibility\":16093,\"wind\":{\"speed\":5.82,\"deg\":340},\"clouds\":{\"all\":20},\"dt\":1505642280,\"sys\":{\"type\":1,\"id\":643,\"message\":0.0038,\"country\":\"US\",\"sunrise\":1505646573,\"sunset\":1505690690},\"id\":0,\"name\":\"Cocoa\",\"cod\":200}";

        [TestMethod]
        public void TestCloudy()
        {
            var fake = A.Fake<IRestService>();
            A.CallTo(() => fake.GetAsync("http://api.openweathermap.org/data/2.5/weather?zip=32927,USA&appid=UnitTest&units=imperial")).Returns(Task.FromResult(cloudy));
            var weather = new OpenWeatherMap.Standard.Forecast();
            string actual = weather.GetWeatherDataByCityIdAsync("UnitTest", 1234,  WeatherUnits.Standard).Result.weather[0].description;
            Assert.AreEqual("few clouds", actual);
        }
    }
}
