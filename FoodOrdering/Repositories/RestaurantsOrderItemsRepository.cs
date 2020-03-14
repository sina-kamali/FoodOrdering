using Dapper;
using FoodOrdering.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Repositories
{
    public class RestaurantsOrderItemsRepository
    {
        private IDbConnection _db = new AppSettings().GetDBSring();
        private string accessSalt = new AppSettings().GetHashe("accessSalt");

        public List<RestaurantsOrderItems> GetOrderItems()
        {
            List<RestaurantsOrderItems> orderItems = new List<RestaurantsOrderItems>();
            orderItems = _db.Query<RestaurantsOrderItems>("SELECT * FROM RESTAURANTS_ORDER_ITEMS", new RestaurantsOrderItems()).ToList();
            return orderItems;

        }

        public RestaurantsOrderItems GetOrderItem(Guid id)
        {
            RestaurantsOrderItems orderItem = new RestaurantsOrderItems();
            orderItem = _db.Query<RestaurantsOrderItems>("SELECT * FROM RESTAURANTS_ORDER_ITEMS WHERE ID = @ID", new RestaurantsOrderItems() { ID = id }).SingleOrDefault();
            return orderItem;

        }

        public List<RestaurantsOrderItems> GetRestaurantsOrderItems(Guid restaurantsId)
        {
            List<RestaurantsOrderItems> restaurantsOrderItems = new List<RestaurantsOrderItems>();
            restaurantsOrderItems = _db.Query<RestaurantsOrderItems>("SELECT * FROM RESTAURANTS_ORDER_ITEMS WHERE RESTAURANTS_ID = @RESTAURANTS_ID", new RestaurantsOrderItems() { RESTAURANTS_ID = restaurantsId }).ToList();
            return restaurantsOrderItems;

        }

        public bool AddRestaurantsOrderItem(RestaurantsOrderItems restaurantsOrderItem)
        {
            if (restaurantsOrderItem != null && restaurantsOrderItem.RESTAURANTS_ID != Guid.Empty)
            {
                if (restaurantsOrderItem.ID == Guid.Empty)
                    restaurantsOrderItem.ID = Guid.NewGuid();

                _db.Query<RestaurantsOrderItems>("INSERT INTO RESTAURANTS_ORDER_ITEMS(ID, RESTAURANTS_ID, NAME, PORTION, DESCRIPTION, IMAGE, PRICE) VALUES(@ID, @RESTAURANTS_ID, @NAME, @PORTION, @DESCRIPTION, @IMAGE, @PRICE)", restaurantsOrderItem).SingleOrDefault();
                return true;
            }
            return false;
        }

        public bool AddRestaurantsOrderItems(List<RestaurantsOrderItems> restaurantsOrderItems)
        {
            if (restaurantsOrderItems != null && restaurantsOrderItems.Count != 0)
            {
                foreach (var orderItem in restaurantsOrderItems)
                {

                    if (orderItem.ID == Guid.Empty)
                        orderItem.ID = Guid.NewGuid();

                    if (orderItem.RESTAURANTS_ID != Guid.Empty)
                        _db.Query<RestaurantsOrderItems>("INSERT INTO RESTAURANTS_ORDER_ITEMS(ID, RESTAURANTS_ID, NAME, PORTION, DESCRIPTION, IMAGE, PRICE) VALUES(@ID, @RESTAURANTS_ID, @NAME, @PORTION, @DESCRIPTION, @IMAGE, @PRICE)", orderItem).SingleOrDefault();


                }
                return true;
            }
            return false;
        }

        public bool UpdateRestaurantsOrderItem(RestaurantsOrderItems restaurantsOrderItem)
        {
            if (restaurantsOrderItem != null)
            {
                int count = _db.Execute("UPDATE RESTAURANTS_ORDER_ITEMS SET RESTAURANTS_ID=@RESTAURANTS_ID, NAME=@NAME, PORTION=@PORTION, DESCRIPTION=@DESCRIPTION, IMAGE=@IMAGE, PRICEWHERE=@PRICEWHERE WHERE ID = @ID", restaurantsOrderItem);
                if (count == 1)
                    return true;

            }

            return false;
        }

        public bool DeleteOrderItem(Guid id)
        {
            if (id != Guid.Empty)
            {
                _db.Execute("Delete FROM RESTAURANTS_ORDER_ITEMS WHERE ID = @ID", new RestaurantsOrderItems() { ID = id });
                return true;

            }

            return false;
        }

        public bool DeleteRestaurantsOrderItems(Guid restaurantsId)
        {
            if (restaurantsId != Guid.Empty)
            {
                _db.Execute("Delete FROM RESTAURANTS_ORDER_ITEMS WHERE RESTAURANTS_ID = @RESTAURANTS_ID", new RestaurantsOrderItems() { RESTAURANTS_ID = restaurantsId });
                return true;

            }

            return false;
        }
    }
}
