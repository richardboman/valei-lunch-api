using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValeiLunchAPI.Data;
using ValeiLunchAPI.Lunches.Models;
using Microsoft.EntityFrameworkCore;
using ValeiLunchAPI.Restaurants.Models;


namespace ValeiLunchAPI.Lunches
{
    [Route("api/[controller]")]
    public class ValeiLunchController : Controller

    {
        private readonly LunchDbContext _context;

        public ValeiLunchController(LunchDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _context.Restaurants.Include(r=>r.Lunches).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>/
        [HttpPost]
        public ActionResult Post([FromBody]Lunch lunch)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Name.ToLower() == lunch.Restaurant.Name.ToLower());

            if(restaurant != null)
            {
                lunch.Restaurant = restaurant;
                lunch.RestaurantId = restaurant.RestaurantId;
            }

            _context.Add(lunch);
            _context.SaveChanges();
            return Ok(restaurant);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
