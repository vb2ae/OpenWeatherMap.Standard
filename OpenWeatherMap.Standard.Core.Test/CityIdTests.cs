using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Newtonsoft.Json;
using OpenWeatherMap.Standard.Enums;
using OpenWeatherMap.Standard.Interfaces;
using OpenWeatherMap.Standard.Models;

namespace OpenWeatherMap.Standard.Core.Test
{
    [TestClass()]
    public class CityIdTests
    {
        private const string cloudy = "{\"coord\":{\"lon\":145.77,\"lat\":-16.92},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"base\":\"stations\",\"main\":{\"temp\":300.15,\"pressure\":1007,\"humidity\":74,\"temp_min\":300.15,\"temp_max\":300.15},\"visibility\":10000,\"wind\":{\"speed\":3.6,\"deg\":160},\"clouds\":{\"all\":40},\"dt\":1485790200,\"sys\":{\"type\":1,\"id\":8166,\"message\":0.2064,\"country\":\"AU\",\"sunrise\":1485720272,\"sunset\":1485766550},\"id\":2172797,\"name\":\"Cairns\",\"cod\":200}";
        private readonly WeatherData expected;

        public CityIdTests()
        {
            expected = JsonConvert.DeserializeObject<WeatherData>(cloudy);
        }

        [TestMethod()]
        public void TestCloudy()
        {
            var fake = A.Fake<IRestService>();
            A.CallTo(() => fake.GetAsync("https://api.openweathermap.org/data/2.5/weather?id=2172797&units=Standard&appid=YOUR_API_KEY&lang=en", "https://openweathermap.org/img/wn/", true)).Returns(Task.FromResult(expected));
            var weather = new Current(Consts.API_KEY, fake, Enums.WeatherUnits.Standard, Languages.English);
            var res = weather.GetWeatherDataByCityIdAsync(2172797).Result;
            string actual = res.Weathers[0].Description;
            Assert.AreEqual("scattered clouds", actual);
        }
    }
}
