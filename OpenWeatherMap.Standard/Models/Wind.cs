using Newtonsoft.Json;
using System;

namespace OpenWeatherMap.Standard.Models
{
    /// <summary>
    /// wind model
    /// </summary>
    [Serializable]
    public class Wind : BaseModel
    {
        private float speed, gust, deg;

        /// <summary>
        /// wind speed
        /// </summary>
        public float Speed
        {
            get => speed;
            set => SetProperty(ref speed, value);
        }

        /// <summary>
        /// wind degree
        /// </summary>
        [JsonProperty("deg")]
        public float Degree
        {
            get => deg;
            set => SetProperty(ref deg, value);
        }
        
        /// <summary>
        /// gust
        /// </summary>
        public float Gust
        {
            get => gust;
            set => SetProperty(ref gust, value);
        }
    }

}
