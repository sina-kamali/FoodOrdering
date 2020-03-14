using Dapper;
using FoodOrdering.DatabaseModels;
using FoodOrdering.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Repositories
{
    public class RestaurantsRepository
    {
        private IDbConnection _db = new AppSettings().GetDBSring();
        private string accessSalt = new AppSettings().GetHashe("accessSalt");

        public List<Restaurants> GetRestaurants()
        {
            List<Restaurants> rstaurant = new List<Restaurants>();
            rstaurant = _db.Query<Restaurants>("SELECT * FROM RESTAURANTS", new Restaurants()).ToList();
            return rstaurant;

        }

        public List<RestaurantView> GetRestaurantsWithItems()
        {
            List<RestaurantView> restaurantsWithOrderItems = new List<RestaurantView>();

            List<Restaurants> retaurant = GetRestaurants();

            var repo = new RestaurantsOrderItemsRepository();

            foreach (var res in retaurant)
            {
                List<RestaurantsOrderItems> orderItems = new List<RestaurantsOrderItems>();
                orderItems = repo.GetRestaurantsOrderItems(res.ID);
                RestaurantView view = new RestaurantView(res, orderItems);
                restaurantsWithOrderItems.Add(view);
            }


            return restaurantsWithOrderItems;

        }

        public Restaurants GetRestaurant(Guid id)
        {
            Restaurants restaurants = new Restaurants();
            if (id != Guid.Empty)
                restaurants = _db.Query<Restaurants>("SELECT * FROM RESTAURANTS WHERE ID = @ID", new Restaurants() { ID = id }).SingleOrDefault();

            return restaurants;

        }

        public RestaurantView GetRestaurantWithOrderItems(Guid id)
        {
            RestaurantView restaurantWithOrderItems = new RestaurantView();
            var repo = new RestaurantsOrderItemsRepository();
            if (id != Guid.Empty)
            {
                Restaurants restaurant = GetRestaurant(id);
                List<RestaurantsOrderItems> orderItems = repo.GetRestaurantsOrderItems(id);
                restaurantWithOrderItems.Restaurant = restaurant;
                restaurantWithOrderItems.OrderItems = orderItems;

            }


            return restaurantWithOrderItems;

        }

        public Restaurants GetRestaurant(string name)
        {
            if (name != null && name.Trim() != "")
            {

                Restaurants restaurants = new Restaurants();
                restaurants = _db.Query<Restaurants>("SELECT * FROM RESTAURANTS WHERE NAME = @NAME", new Restaurants() { NAME = name }).SingleOrDefault();
                return restaurants;
            }
            return null;

        }

        public bool AddRestaurant(Restaurants restaurant)
        {
            if (restaurant != null && restaurant.NAME != null && restaurant.NAME.Trim() != "")
            {
                if (restaurant.ID == Guid.Empty)
                    restaurant.ID = Guid.NewGuid();

                _db.Query<Restaurants>("INSERT INTO RESTAURANTS(ID, NAME) VALUES(@ID, @NAME)", restaurant).SingleOrDefault();
                return true;
            }
            return false;
        }

        public bool AddRestaurants(List<Restaurants> restaurants)
        {
            if (restaurants != null && restaurants.Count != 0)
            {
                foreach (var restaurant in restaurants)
                {

                    if (restaurant.ID == Guid.Empty)
                        restaurant.ID = Guid.NewGuid();

                    _db.Query<Restaurants>("INSERT INTO RESTAURANTS(ID, NAME) VALUES(@ID, @NAME)", restaurant).SingleOrDefault();

                }
                return true;
            }
            return false;
        }

        public bool UpdateRestaurant(Restaurants restaurant)
        {
            if (restaurant != null)
            {
                int count = _db.Execute("UPDATE RESTAURANTS SET NAME=@NAME WHERE ID = @ID", restaurant);
                if (count == 1)
                    return true;

            }

            return false;
        }

        public bool DeleteRestaurant(Guid id)
        {
            if (id != Guid.Empty)
            {
                _db.Execute("Delete FROM RESTAURANTS WHERE ID = @ID", new Restaurants() { ID = id });
                return true;

            }

            return false;
        }
    }
}
