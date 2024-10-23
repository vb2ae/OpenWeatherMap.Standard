namespace OpenWeatherMap.Avalonia.Sample.Models
{
    public class ApiSettings : IApiSettings
    {
        public ApiSettings()
        {
            ApiKey = string.Empty;
        }
        public string ApiKey { get; set; }
    }
}
