using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.DatabaseModels;
using FoodOrdering.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : Controller
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllRestaurants()
        {
            return Json(new RestaurantsRepository().GetRestaurants());
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllWithItems()
        {
            return Json(new RestaurantsRepository().GetRestaurantsWithItems());
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetRestaurant(Guid id)
        {
            if (id != Guid.Empty)
                return Json(new RestaurantsRepository().GetRestaurant(id));

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetWithItems(Guid id)
        {
            if (id != Guid.Empty)
                return Json(new RestaurantsRepository().GetRestaurantWithOrderItems(id));

            return Json(null);
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult FindRestaurants(Restaurants restaurant)
        {
            if (restaurant != null)
            {
                if (restaurant.ID != Guid.Empty)
                    return Json(new RestaurantsRepository().GetRestaurant(restaurant.ID));

                if (restaurant.NAME != null && restaurant.NAME.Trim() != "")
                    return Json(new RestaurantsRepository().GetRestaurant(restaurant.NAME));
            }

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult UpdateRestaurant(Restaurants restaurant)
        {
            if (restaurant != null)
            {
                return Json(new RestaurantsRepository().UpdateRestaurant(restaurant));

            }

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult DeleteRestaurant(Restaurants restaurant)
        {
            if (restaurant != null && restaurant.ID != Guid.Empty)
            {
                return Json(new RestaurantsRepository().DeleteRestaurant(restaurant.ID));

            }

            return Json(null);
        }

        // POST api/values
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddRestaurant(Restaurants restaurants)
        {
            var added = new RestaurantsRepository().AddRestaurant(restaurants);

            if (added)
                return Json(new RestaurantsRepository().GetRestaurant(restaurants.ID));

            return Json(null);
        }

        // DELETE api/values/5
        [HttpPost]
        [Route("[action]")]
        public IActionResult DeleteRestaurants(Guid id)
        {
            if (id != Guid.Empty)
                return Json(new RestaurantsRepository().DeleteRestaurant(id));

            return Json(null);
        }
    }
}
