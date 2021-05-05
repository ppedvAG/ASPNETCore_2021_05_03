using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingSample.Controllers
{

    //[Area("Blog")]
    public class RouteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Route/About")]

        //[HttpGet("/Route/About")]
        public IActionResult About()
        {
            return View();
        }
    }
}
