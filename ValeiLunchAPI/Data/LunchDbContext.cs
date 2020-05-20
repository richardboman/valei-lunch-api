using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeiLunchAPI.Lunches.Models;
using ValeiLunchAPI.Restaurants.Models;

namespace ValeiLunchAPI.Data
{
    public class LunchDbContext: DbContext

    {
        public DbSet<Lunch> Lunches { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public LunchDbContext(DbContextOptions<LunchDbContext> options)
            : base(options)
        { }
    }
}
