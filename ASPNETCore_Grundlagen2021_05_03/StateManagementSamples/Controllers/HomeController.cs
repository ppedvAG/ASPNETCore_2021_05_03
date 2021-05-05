using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StateManagementSamples.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateManagementSamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult ViewDataSample()
        {
            ViewData["Message"] = "Hallo liebe Teilnehmer :-)";
            return View();
        }

        public IActionResult ViewBagSample()
        {
            ViewBag.ABC = "HAllo liebe Teilnehmer";
            ViewBag.MessageDesTages = "LaLeLu";

            return View();
        }

        public IActionResult TempDataSample()
        {
            TempData["Msg"] = "Hallo liebe Teilnehmer :-)";
            TempData["Wetter"] = "Heute ist es windig";


            
            return View();
        }
        public IActionResult TempDataSecondSample()
        {
            return View();
        }
        public IActionResult TempDataThirdSample()
        {
            return View();
        }


        public IActionResult SessionInit()
        {
            //using Microsoft.AspNetCore.Http; -> für SetInt32
            HttpContext.Session.SetInt32("Lottozahlen", 1234567);
            HttpContext.Session.SetString("Lottogewinnerin", "Heike Musterfrau");

            Person person = new Person
            {
                Id = 123,
                Firstname = "Harry",
                Lastname = "Weinfuhrt"
            };

            string jsonString = JsonSerializer.Serialize(person);

            HttpContext.Session.SetString("PersonObj", jsonString);


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
