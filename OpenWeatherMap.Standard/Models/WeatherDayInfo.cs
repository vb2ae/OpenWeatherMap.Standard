using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OpenWeatherMap.Standard.Models
{
    /// <summary>
    /// weatherdayinfo model
    /// </summary>
    [Serializable]
    public class WeatherDayInfo : BaseModel
    {
        private float temp, maxTemp, minTemp, pressure, seaLevel, grndLevel, feelsLike;
        private int humidity;

        /// <summary>
        /// current temperature
        /// </summary>
        [JsonProperty("temp")]
        public float Temperature
        {
            get => temp;
            set => SetProperty(ref temp, value);
        }

        /// <summary>
        /// atmosphere pressure
        /// </summary>
        public float Pressure
        {
            get => pressure;
            set => SetProperty(ref pressure, value);
        }
        
        /// <summary>
        /// humidity
        /// </summary>
        public int Humidity
        {
            get => humidity;
            set => SetProperty(ref humidity, value);
        }

        /// <summary>
        /// minimum temperature
        /// </summary>
        [JsonProperty("temp_min")]
        public float MinimumTemperature
        {
            get => minTemp;
            set => SetProperty(ref minTemp, value);
        }

        /// <summary>
        /// maximum temperature
        /// </summary>
        [JsonProperty("temp_max")]
        public float MaximumTemperature
        {
            get => maxTemp;
            set => SetProperty(ref maxTemp, value);
        }

        /// <summary>
        /// Atmospheric pressure on the sea level, hPa
        /// </summary>
        [JsonProperty("sea_level")]
        public float SeaLevel
        {
            get => seaLevel;
            set => SetProperty(ref seaLevel, value);
        }

        /// <summary>
        /// Atmospheric pressure on the ground level, hPa
        /// </summary>
        [JsonProperty("grnd_level")]
        public float GroundLevel
        {
            get => grndLevel;
            set => SetProperty(ref grndLevel, value);
        }

        /// <summary>
        /// Atmospheric pressure on the ground level, hPa
        /// </summary>
        [JsonProperty("feels_like")]
        public float FeelsLike
        {
            get => feelsLike;
            set => SetProperty(ref feelsLike, value);
        }
    }
}
