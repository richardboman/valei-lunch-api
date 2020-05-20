using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeiLunchAPI.Lunches.Models;

namespace ValeiLunchAPI.Restaurants.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public List<Lunch> Lunches { get; set; }
    }
}
