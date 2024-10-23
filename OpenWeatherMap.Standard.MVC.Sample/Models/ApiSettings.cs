namespace OpenWeatherMap.Standard.MVC.Sample.Models
{
    public class ApiSettings : IApiSettings
    {
        public string ApiKey { get; set; } = string.Empty;
    }
}