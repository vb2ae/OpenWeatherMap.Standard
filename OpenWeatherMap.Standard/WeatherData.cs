using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenWeatherMap.Standard
{
    public class WeatherData
    {
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }
        [JsonProperty("weather")]
        public Weather[] Weathers { get; set; }
        [JsonProperty("_base")]
        public string Base { get; set; }
        [JsonProperty("main")]
        public WeatherDayInfo WeatherDayInfo { get; set; }
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Dt { get; set; }
        [JsonProperty("sys")]
        public DayInfo DayInfo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("cod")]
        public int HttpStatusCode { get; set; }
    }

}
