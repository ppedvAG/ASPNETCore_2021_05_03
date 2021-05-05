using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.DomainModel.Entities;

namespace MovieService.Data
{
    public class MovieServiceContext : DbContext
    {
        public MovieServiceContext (DbContextOptions<MovieServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Shared.DomainModel.Entities.Movie> Movie { get; set; }
    }
}
