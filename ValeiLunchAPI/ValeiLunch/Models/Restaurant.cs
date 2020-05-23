using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeiLunchAPI.Lunches.Models;

namespace ValeiLunchAPI.Restaurants.Models
{
    public class Restaurant: IComparable<Restaurant>
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public List<Lunch> Lunches { get; set; }

        //Compares by average lunch-rating first, earliest
        //date second and most reviews third
        public int CompareTo(Restaurant other)
        {
            if (other == null) return 1;

            var avgRating = Lunches.Average(l => l.Rating);
            var earliestDate = Lunches.Min(l => l.Date).Date;
            var numberOfReviews = Lunches.Count;

            var otherAvgRating = other.Lunches.Average(l => l.Rating);
            var otherEarliestDate = other.Lunches.Min(l => l.Date).Date;
            var otherNumberOfReviews = other.Lunches.Count;

            if (avgRating.Equals(otherAvgRating))
            {
                if(earliestDate.Equals(otherEarliestDate))
                {
                    return otherNumberOfReviews.CompareTo(numberOfReviews);
                }
                return (earliestDate.CompareTo(otherEarliestDate));
            }
            //Ratings are not equal, compare ratings
            return otherAvgRating.CompareTo(avgRating);
        }
    }
}
