using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OpenWeatherMap.Standard
{
    public class WeatherDayInfo
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        [JsonProperty("temp_min")]
        public float MinimumTemperature { get; set; }
        [JsonProperty("temp_max")]
        public float MaximumTemperature { get; set; }
    }

}
