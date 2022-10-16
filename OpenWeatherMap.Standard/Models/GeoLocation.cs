using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMap.Standard.Models
{

    public class GeoLocation
    {
        public string name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }

}
