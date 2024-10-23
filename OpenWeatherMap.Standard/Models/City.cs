using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace OpenWeatherMap.Standard.Models
{
    /// <summary>
    ///     city model
    /// </summary>
    [Serializable]
    public class City : BaseModel
    {
        public City()
        {
            coordinates = new Coordinates();
        }
        private Coordinates coordinates;
        private int id, timezone;
        private string name, country;
        private long population;
        private DateTime sunrise, sunset;

        /// <summary>
        ///     id
        /// </summary>
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        /// <summary>
        ///     name
        /// </summary>
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        /// <summary>
        ///     coordinates
        /// </summary>
        [JsonProperty("coord")]
        public Coordinates Coordinates
        {
            get => coordinates;
            set => SetProperty(ref coordinates, value);
        }

        /// <summary>
        ///     country code
        /// </summary>
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }

        /// <summary>
        ///     population
        /// </summary>
        public long Population
        {
            get => population;
            set => SetProperty(ref population, value);
        }

        /// <summary>
        ///     timezone (shift in seconds from UTC)
        /// </summary>
        public int Timezone
        {
            get => timezone;
            set => SetProperty(ref timezone, value);
        }

        /// <summary>
        ///     sunrise
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunrise
        {
            get => sunrise;
            set => SetProperty(ref sunrise, value);
        }

        /// <summary>
        ///     sunset
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunset
        {
            get => sunset;
            set => SetProperty(ref sunset, value);
        }
    }
}