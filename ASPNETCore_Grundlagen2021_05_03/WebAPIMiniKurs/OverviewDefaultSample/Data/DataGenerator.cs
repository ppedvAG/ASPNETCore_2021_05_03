using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverviewDefaultSample.Data
{
    public class DataGenerator
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            using (PersonDbContext ctx = new PersonDbContext(serviceProvider.GetRequiredService<DbContextOptions<PersonDbContext>>()))
            {
                ctx.Personen.Add(new Models.Person { Id = 1, FirstName = "Frauke", LastName = "Musterfrau", Birthday = DateTime.Now });
                ctx.Personen.Add(new Models.Person { Id = 2, FirstName = "Peter", LastName = "Mustermann",  Birthday = DateTime.Now });
                ctx.Personen.Add(new Models.Person { Id = 3, FirstName = "Benedikt", LastName = "Muster",   Birthday = DateTime.Now });
                ctx.Personen.Add(new Models.Person { Id = 4, FirstName = "Kevin", LastName = "Winter",      Birthday = DateTime.Now });
                ctx.Personen.Add(new Models.Person { Id = 5, FirstName = "Hannes", LastName = "Preishuber", Birthday = DateTime.Now });
                ctx.SaveChanges();
            }
        }
    }
}
