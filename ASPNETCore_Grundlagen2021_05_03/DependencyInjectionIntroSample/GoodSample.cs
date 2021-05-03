using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionIntroSample.GoodSample
{
    public interface ICar
    {
        string Model { get; set; }
        string Typ { get; set; }
        DateTime ConstructionYear { get; set; }
    }

    public interface ICarService
    {
        void RepaireService(ICar car); //ICar wird jetzt zum Parameter!!!
    }

    public class Car : ICar // ProgrammiererA benötigt 5 Tage
    {
        public string Model { get; set; }
        public string Typ { get; set; }
        public DateTime ConstructionYear { get; set; }
    }


   

    public class CarService : ICarService // ProgrammiererB benötigt 3 Tage
    {
        public void RepaireService(ICar car)
        {
            //Mach was
        }
    }

    public class MockCar : ICar
    {
        public string Model { get; set; } = "VW";
        public string Typ { get; set; } = "Polo";
        public DateTime ConstructionYear { get; set; } = DateTime.Now;
    }
}
