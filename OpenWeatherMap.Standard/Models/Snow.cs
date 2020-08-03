using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMap.Standard.Models
{
    /// <summary>
    /// snow model
    /// </summary>
    [Serializable]
    public class Snow : BaseModel
    {
        private float lastHour, lastThreeHours;

        /// <summary>
        /// last hour, mm
        /// </summary>
        [JsonProperty("1h")]
        public float LastHour
        {
            get => lastHour;
            set => SetProperty(ref lastHour, value);
        }

        /// <summary>
        /// last three hours, mm
        /// </summary>
        [JsonProperty("3h")]
        public float LastThreeHours
        {
            get => lastThreeHours;
            set => SetProperty(ref lastThreeHours, value);
        } 
    }
}
