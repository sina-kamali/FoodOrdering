using Dapper;
using FoodOrdering.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Repositories
{
    public class UsersOrderRepository
    {
        private IDbConnection _db = new AppSettings().GetDBSring();
        private string accessSalt = new AppSettings().GetHashe("accessSalt");

        public List<UsersOrder> GetUserOrders(Guid userId)
        {
            List<UsersOrder> UserOrders = new List<UsersOrder>();
            UserOrders = _db.Query<UsersOrder>("SELECT * FROM USERS_ORDER WHERE USER_ID = @USER_ID", new UsersOrder() { USER_ID = userId }).ToList();
            return UserOrders;

        }

        public UsersOrder GetUserOrder(Guid userId, Guid id)
        {
            UsersOrder userOrder = _db.Query<UsersOrder>("SELECT * FROM USERS_ORDER WHERE USER_ID = @USER_ID AND ID = @ID", new UsersOrder() { USER_ID = userId, ID = id }).SingleOrDefault();
            return userOrder;
        }
    }
}
