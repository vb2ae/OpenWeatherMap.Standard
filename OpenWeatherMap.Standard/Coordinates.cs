using Newtonsoft.Json;

namespace OpenWeatherMap.Standard
{
    public class Coordinates
    {
        [JsonProperty("Longitude")]
        public float Longitude { get; set; }
        [JsonProperty("Latitude")]
        public float Latitude { get; set; }
    }

}
