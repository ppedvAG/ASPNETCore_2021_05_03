using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionIntroSample.BadSample
{
    public class Car //Programmierer A benötigt 5 Tage
    {
        public string Model { get; set; }
        public string Type { get; set; }
        public DateTime ConstructionYear { get; set; }
    }

    public class CarService // Programmierer B benötigt 3 Tage
    {
        public void Repair(Car car) //Achtung feste Kopplung
        {
            //Mach was
        }
    }
}
