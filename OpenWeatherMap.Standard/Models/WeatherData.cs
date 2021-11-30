using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenWeatherMap.Standard.Models
{
    /// <summary>
    /// weatherdata model
    /// </summary>
    [Serializable]
    public class WeatherData : BaseModel
    {
        private string _base, name;
        private int vis, id, statusCode;

        private Coordinates coords;
        private Weather[] weathers;
        private WeatherDayInfo weatherDayInfo;
        private Wind wind;
        private Clouds clouds;
        private Rain rain;
        private Snow snow;
        private DateTime dt;
        private DayInfo dayInfo;

        /// <summary>
        /// coordinates
        /// </summary>
        [JsonProperty("coord")]
        public Coordinates Coordinates
        {
            get => coords;
            set => SetProperty(ref coords, value);
        }

        /// <summary>
        /// array of weather
        /// </summary>
        [JsonProperty("weather")]
        public Weather[] Weathers
        {
            get => weathers;
            set => SetProperty(ref weathers, value);
        }

        /// <summary>
        /// Base
        /// </summary>
        [JsonProperty("base")]
        public string Base
        {
            get => _base;
            set => SetProperty(ref _base, value);
        }

        /// <summary>
        /// main weather day info
        /// </summary>
        [JsonProperty("main")]
        public WeatherDayInfo WeatherDayInfo
        {
            get => weatherDayInfo;
            set => SetProperty(ref weatherDayInfo, value);
        }

        /// <summary>
        /// visibility
        /// </summary>
        [JsonProperty("visibility")]
        public int Visibility
        {
            get => vis;
            set => SetProperty(ref vis, value);
        }

        /// <summary>
        /// wind info
        /// </summary>
        public Wind Wind
        {
            get => wind;
            set => SetProperty(ref wind, value);
        }

        /// <summary>
        /// clouds info
        /// </summary>
        public Clouds Clouds
        {
            get => clouds;
            set => SetProperty(ref clouds, value);
        }

        /// <summary>
        /// rain info
        /// </summary>
        public Rain Rain
        {
            get => rain;
            set => SetProperty(ref rain, value);
        }

        /// <summary>
        /// snow info
        /// </summary>
        public Snow Snow
        {
            get => snow;
            set => SetProperty(ref snow, value);
        }

        /// <summary>
        /// acquisiton datatime
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter)), JsonProperty("dt")]
        public DateTime AcquisitionDateTime
        {
            get => dt;
            set => SetProperty(ref dt, value);
        }

        /// <summary>
        /// day info
        /// </summary>
        [JsonProperty("sys")]
        public DayInfo DayInfo
        {
            get => dayInfo;
            set => SetProperty(ref dayInfo, value);
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        /// <summary>
        /// name
        /// </summary>
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        
        /// <summary>
        /// response code
        /// </summary>
        [JsonProperty("cod")]
        public int HttpStatusCode
        {
            get => statusCode;
            set => SetProperty(ref statusCode, value);
        }
    }

}
