using MVCWithViewModelsAndEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWithViewModelsAndEFCore.ViewModel
{
    public class PlaceVM
    {
        public string PlaceName { get; set; }
        public DateTime Time { get; set; }

        public IList<Human> Humans { get; set; }
        public IList<Animals> Animals { get; set; }
    }
}
