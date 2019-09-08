using Newtonsoft.Json;

namespace OpenWeatherMap.Standard.Models
{
    /// <summary>
    /// coordinates model
    /// </summary>
    public class Coordinates : BaseModel
    {
        private float lon, lat;

        /// <summary>
        /// longitude
        /// </summary>
        [JsonProperty("lon")]
        public float Longitude
        {
            get => lon;
            set => SetProperty(ref lon, value);
        }

        /// <summary>
        /// latitude
        /// </summary>
        [JsonProperty("lat")]
        public float Latitude
        {
            get => lat;
            set => SetProperty(ref lat, value);
        }
    }

}
