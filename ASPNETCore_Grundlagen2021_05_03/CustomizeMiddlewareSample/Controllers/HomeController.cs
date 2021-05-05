using CustomizeMiddlewareSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizeMiddlewareSample.Controllers
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

        public IActionResult PictureUpload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PictureUpload(IFormFile datei)
        {
            FileInfo fileInfo = new FileInfo(datei.FileName);

            var speicherPfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;

            using (var fs = new FileStream(speicherPfad, FileMode.Create))
            {
                datei.CopyTo(fs);
            }


            return RedirectToAction(nameof(Index));
        }


        public IActionResult PictureGallery()
        {
            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";

            string[] bilder = Directory.GetFiles(pfad);

            return View(bilder);
        }


        public IActionResult PictureThumbNailGallery()
        {
            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";

            string[] bilder = Directory.GetFiles(pfad);

            return View(bilder);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
