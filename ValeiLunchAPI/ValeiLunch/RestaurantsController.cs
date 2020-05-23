using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValeiLunchAPI.Data;
using ValeiLunchAPI.Restaurants.Models;

namespace ValeiLunchAPI.Restaurants
{
    [Route("api/[controller]/")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly LunchDbContext _context;

        public RestaurantsController(LunchDbContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            return await _context.Restaurants.Include(r => r.Lunches).ToListAsync();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // GET: api/<controller>/top/5
        [HttpGet("top/{amount}")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetTop(int amount)
        {

            var restaurants = await _context.Restaurants.Include(r=>r.Lunches).ToListAsync();

            restaurants.Sort();
            return Ok(restaurants.Take(amount));
        }


        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.RestaurantId }, restaurant);
        }
    }
}
