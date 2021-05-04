using Microsoft.EntityFrameworkCore;
using MVCWithViewModelsAndEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWithViewModelsAndEFCore.Data
{
    public class DataSeeder
    {
        public static void SeedWorldData(WorldDbContext context)
        {
            //Sind Datensätze in der Tabelle Person
            if (!context.Tiere.Any())
            {
                IList<Animals> animals = new List<Animals>();

                animals.Add(new Animals { Name = "Katze" });

                animals.Add(new Animals { Name = "aAus" });

                context.Tiere.AddRange(animals.ToArray());
                context.SaveChanges();
            }

            if (!context.Menschen.Any())
            {
                IList<Human> humans = new List<Human>();

                humans.Add(new Human {  Name = "Peter" });
                humans.Add(new Human {  Name = "Petra" });


                context.Menschen.AddRange(humans.ToArray());
                context.SaveChanges();
            }
        }
    }
}
