using Microsoft.EntityFrameworkCore;
using MVCWithViewModelsAndEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWithViewModelsAndEFCore.Data
{
    public class WorldDbContext :DbContext
    {

        public WorldDbContext(DbContextOptions<WorldDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animals> Tiere { get; set; }
        public DbSet<Human> Menschen { get; set; }
    }
}
