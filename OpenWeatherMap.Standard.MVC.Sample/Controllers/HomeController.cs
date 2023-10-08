using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenWeatherMap.Standard.Enums;
using OpenWeatherMap.Standard.MVC.Sample.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard.MVC.Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiSettings _configuration;

        public HomeController(ILogger<HomeController> logger, IApiSettings configurationData)
        {
            _configuration = configurationData;

            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Current current = new Current(_configuration.ApiKey);
            current.Units = WeatherUnits.Imperial;
            var data = await current.GetWeatherDataByZipAsync("32927", "us");
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}