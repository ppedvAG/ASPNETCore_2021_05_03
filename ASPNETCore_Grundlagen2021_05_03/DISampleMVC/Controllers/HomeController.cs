using DependencyInjectionIntroSample.GoodSample;
using DISampleMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DISampleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly SampleWebSettings _settings;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IOptions<SampleWebSettings> settingOptions)
        {
            _logger = logger;
            _configuration = configuration;

            _settings = settingOptions.Value;
        }

        public IActionResult Index()
        {
            PositionOptions positionOptions = new(); //C# 9 
            _configuration.GetSection(PositionOptions.stringPosition).Bind(positionOptions);


            return View();
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
