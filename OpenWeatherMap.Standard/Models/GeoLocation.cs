namespace OpenWeatherMap.Standard.Models
{

    public class GeoLocation
    {
        public GeoLocation()
        {
            name = string.Empty;
            country = string.Empty;
            state = string.Empty;
        }
        public string name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }

}
