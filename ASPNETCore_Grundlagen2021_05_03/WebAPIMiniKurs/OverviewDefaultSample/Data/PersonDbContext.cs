using Microsoft.EntityFrameworkCore;
using OverviewDefaultSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverviewDefaultSample.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            :base(options)
        {

        }

        public DbSet<Person> Personen { get; set; }
    }
}
