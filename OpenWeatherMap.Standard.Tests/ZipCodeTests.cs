using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace OpenWeatherMap.Standard.Tests
{
    [TestClass]
    public class ZipCodeTests
    {
        private const string SampleCloudyJsonData = @"{""coord"":{""Longitude"":-80.8,""Latitude"":28.46},
""weather"":[{""Id"":801,""WeatherDayInfo"":""Clouds"",
""Description"":""few clouds"",""Icon"":""02n""}],
""base"":""stations"",
""WeatherDayInfo"":{""Temperature"":76.37,""Pressure"":1014,""Humidity"":83,""MinimumTemperature"":73.4,""MaximumTemperature"":78.8},
""Visibility"":16093,""wind"":{""speed"":5.82,""deg"":340},
""clouds"":{""all"":20},""Dt"":1505642280,
""DayInfo"":{""type"":1,""Id"":643,""message"":0.0038,""country"":""US"",""sunrise"":1505646573,""sunset"":1505690690},""Id"":0,""Name"":""Cocoa"",""HttpStatusCode"":200}";

        private readonly WeatherData expected;

        public ZipCodeTests()
        {
            expected = JsonConvert.DeserializeObject<WeatherData>(SampleCloudyJsonData);
        }

        [TestMethod]
        public void TestCloudy()
        {
            var fake = A.Fake<IRestService>();
            A.CallTo(() => fake.GetAsync("http://api.openweathermap.org/data/2.5/weather?zip=32927,USA&appid=UnitTest&units=Standard")).Returns(Task.FromResult(expected));
            var weather = new Forecast(fake);

            var actual = weather.GetWeatherDataByZipAsync("UnitTest", "32927", "USA", WeatherUnits.Standard).Result.Weathers[0].Description;
            Assert.AreEqual("few clouds", actual);
        }

        [TestMethod]
        public void TestUrlCreation()
        {
            var fake = A.Fake<IRestService>();
            A.CallTo(() => fake.GetAsync("http://api.openweathermap.org/data/2.5/weather?zip=32927,USA&appid=UnitTest&units=Standard")).Returns(Task.FromResult(expected));
            var weather = new Forecast(fake);

            var actual = weather.GetWeatherDataByZipAsync("UnitTest", "32927", "USA", WeatherUnits.Standard).Result.Weathers[0].Description;
            Assert.AreEqual("few clouds", actual);
        }
    }
}
