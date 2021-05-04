using Microsoft.AspNetCore.Mvc;
using MVCWithViewModelsAndEFCore.Data;
using MVCWithViewModelsAndEFCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWithViewModelsAndEFCore.Controllers
{
    public class PlaceController : Controller
    {
        private readonly WorldDbContext _context;

        public PlaceController(WorldDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allHumans = _context.Menschen.ToList();
            var allAnimals = _context.Tiere.ToList();

            PlaceVM placeVM = new PlaceVM
            {
                Animals = allAnimals,
                Humans = allHumans,
                PlaceName = "Walt Disney",
                Time = DateTime.Now
            };


            return View(placeVM);
        }
    }
}
