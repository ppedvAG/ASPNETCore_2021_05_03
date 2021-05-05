using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateManagementSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateManagementSamples.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult SessionResult()
        {
            int? lottozahlen = HttpContext.Session.GetInt32("Lottozahlen");
            string lottogewinnerin = HttpContext.Session.GetString("Lottogewinnerin");

            string jsonString = HttpContext.Session.GetString("PersonObj");

            Person person = JsonSerializer.Deserialize<Person>(jsonString);
            return View();
        }
    }
}
