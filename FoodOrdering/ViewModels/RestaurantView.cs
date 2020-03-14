using FoodOrdering.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.ViewModels
{
    public class RestaurantView
    {
        public RestaurantView()
        {
        }

        public RestaurantView(Restaurants restaurant, List<RestaurantsOrderItems> orderItems)
        {
            this.Restaurant = restaurant;
            this.OrderItems = orderItems;
        }

        public Restaurants Restaurant { get; set; }
        public List<RestaurantsOrderItems> OrderItems { get; set; }
    }
}
