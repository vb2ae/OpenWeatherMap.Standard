using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace OpenWeatherMap.Standard.Models
{
    /// <summary>
    /// day info model
    /// </summary>
    [Serializable]
    public class DayInfo : BaseModel
    {
        private int type, id;
        private float message;
        private string country;
        private DateTime sunrise, sunset;
        private char partOfDay;

        /// <summary>
        /// type
        /// </summary>
        public int Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        /// <summary>
        /// id
        /// </summary>
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        /// <summary>
        /// message
        /// </summary>
        public float Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        /// <summary>
        /// country code
        /// </summary>
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }

        /// <summary>
        /// part of day
        /// <para />
        /// Only filled by forecast-api.
        /// </summary>
        [JsonProperty("pod")]
        public char PartOfDay
        {
            get => partOfDay;
            set => SetProperty(ref partOfDay, value);
        }

        /// <summary>
        /// sunrise
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunrise
        {
            get => sunrise;
            set => SetProperty(ref sunrise, value);
        }

        /// <summary>
        /// sunset
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Sunset
        {
            get => sunset;
            set => SetProperty(ref sunset, value);
        }
    }

}
