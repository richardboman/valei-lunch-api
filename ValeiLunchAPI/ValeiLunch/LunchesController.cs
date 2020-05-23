using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValeiLunchAPI.Data;
using ValeiLunchAPI.Lunches.Models;
using Microsoft.EntityFrameworkCore;
using ValeiLunchAPI.Restaurants.Models;
using System.Text.RegularExpressions;

namespace ValeiLunchAPI.Lunches
{
    [Route("api/[controller]")]
    public class LunchesController : Controller

    {
        private readonly LunchDbContext _context;

        public LunchesController(LunchDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lunch>> GetLunch(int id)
        {
            var lunch = await _context.Lunches.FindAsync(id);

            if (lunch == null)
            {
                return NotFound();
            }

            return lunch;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<Lunch>> Get()
        {
            return await _context.Lunches.Include(l => l.Restaurant).ToListAsync();
        }


        // POST api/<controller>/
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Lunch _lunch)
        {

            if (_lunch == null) { return BadRequest(); }

            var lunch = new Lunch()
            {
                Rating = _lunch.Rating,
                Date = DateTime.Now.Date,
                Comment = _lunch.Comment,
                Restaurant = new Restaurant() { Name = _lunch.Restaurant.Name }
            };

            //Check if restaurant with same name exists
            var restaurants = await _context.Restaurants.ToListAsync();
            var restaurant = restaurants.FirstOrDefault(r => string.Compare(r.Name.Trim(), _lunch.Restaurant.Name.Trim(), true) == 0);

            if (restaurant != null)
            {
                lunch.Restaurant = restaurant;
                lunch.RestaurantId = restaurant.RestaurantId;
            }
            //Save new lunch
            _context.Add(lunch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLunch", new { id = lunch.LunchId }, lunch);
        }
    }
}
