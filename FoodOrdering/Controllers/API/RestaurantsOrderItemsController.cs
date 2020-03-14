using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.DatabaseModels;
using FoodOrdering.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsOrderItemsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            return Json(new RestaurantsOrderItemsRepository().GetOrderItems());

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(Guid id)
        {
            if (id != Guid.Empty)
                return Json(new RestaurantsOrderItemsRepository().GetOrderItem(id));

            return Json(null);
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult GetRestaurantsOrderItems(Restaurants restaurant)
        {
            if (restaurant != null)
            {
                if (restaurant.ID != Guid.Empty)
                    return Json(new RestaurantsOrderItemsRepository().GetRestaurantsOrderItems(restaurant.ID));

            }

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetRestaurantsOrderItems(Guid restaurantId)
        {
            if (restaurantId != Guid.Empty)
                return Json(new RestaurantsOrderItemsRepository().GetRestaurantsOrderItems(restaurantId));

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(RestaurantsOrderItems restaurantsOrderItem)
        {
            if (restaurantsOrderItem != null && restaurantsOrderItem.RESTAURANTS_ID != Guid.Empty)
            {
                return Json(new RestaurantsOrderItemsRepository().UpdateRestaurantsOrderItem(restaurantsOrderItem));

            }

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(List<RestaurantsOrderItems> restaurantsOrderItems)
        {
            if (restaurantsOrderItems != null && restaurantsOrderItems.Count() != 0)
            {
                foreach (var restaurantsOrderItem in restaurantsOrderItems)
                {
                    if (restaurantsOrderItem != null && restaurantsOrderItem.RESTAURANTS_ID != Guid.Empty)
                    {
                        return Json(new RestaurantsOrderItemsRepository().UpdateRestaurantsOrderItem(restaurantsOrderItem));

                    }

                }
            }

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(Restaurants restaurant)
        {
            if (restaurant != null && restaurant.ID != Guid.Empty)
            {
                return Json(new RestaurantsOrderItemsRepository().DeleteRestaurantsOrderItems(restaurant.ID));

            }

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(RestaurantsOrderItems restaurantsOrderItem)
        {
            if (restaurantsOrderItem != null && restaurantsOrderItem.ID != Guid.Empty)
            {
                return Json(new RestaurantsOrderItemsRepository().DeleteOrderItem(restaurantsOrderItem.ID));

            }

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(List<RestaurantsOrderItems> restaurantsOrderItems)
        {
            if (restaurantsOrderItems != null && restaurantsOrderItems.Count() != 0)
            {
                var added = new RestaurantsOrderItemsRepository().AddRestaurantsOrderItems(restaurantsOrderItems);
                return Json(added);
            }

            return Json(null);
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post(RestaurantsOrderItems restaurantsOrderItem)
        {
            var added = new RestaurantsOrderItemsRepository().AddRestaurantsOrderItem(restaurantsOrderItem);

            if (added)
                return Json(new RestaurantsOrderItemsRepository().GetOrderItem(restaurantsOrderItem.ID));

            return Json(null);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(RestaurantsOrderItems restaurantsOrderItem)
        {
            if (restaurantsOrderItem != null)
                return Json(new RestaurantsOrderItemsRepository().UpdateRestaurantsOrderItem(restaurantsOrderItem));

            return Json(null);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult DeleteRestaurantsOrderItems(Restaurants restaurants)
        {
            if (restaurants != null)
            {
                return Json(new RestaurantsOrderItemsRepository().DeleteRestaurantsOrderItems(restaurants.ID));
            }

            return Json(null);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public JsonResult Delete(Guid id)
        {
            if (id != Guid.Empty)
                return Json(new RestaurantsOrderItemsRepository().DeleteOrderItem(id));

            return Json(null);
        }
    }
}
