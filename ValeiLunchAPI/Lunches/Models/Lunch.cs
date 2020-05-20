using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeiLunchAPI.Restaurants.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace ValeiLunchAPI.Lunches.Models
{
    public class Lunch
    {
        public int LunchId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
