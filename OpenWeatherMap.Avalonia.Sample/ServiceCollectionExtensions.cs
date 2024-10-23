using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenWeatherMap.Avalonia.Sample.Models;
using OpenWeatherMap.Avalonia.Sample.ViewModels;

namespace OpenWeatherMap.Avalonia.Sample
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection collection)
        {
            var config = new ConfigurationBuilder()
             .AddUserSecrets<Program>()
             .Build();
            string key = config["Weather:ApiKey"];
            collection.AddSingleton<IApiSettings>(new ApiSettings() { ApiKey = key });
            collection.AddTransient<MainWindowViewModel>();
        }
    }
}