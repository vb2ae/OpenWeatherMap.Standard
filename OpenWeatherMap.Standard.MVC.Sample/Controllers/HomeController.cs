using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenWeatherMap.Standard.Enums;
using OpenWeatherMap.Standard.MVC.Sample.Models;

namespace OpenWeatherMap.Standard.MVC.Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Configuration _configuration;
        
        public HomeController(ILogger<HomeController> logger, IOptions<Configuration> configurationData)
        {
            _configuration = configurationData.Value;
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}