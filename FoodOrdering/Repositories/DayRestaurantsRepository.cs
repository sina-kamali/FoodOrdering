using FoodOrdering.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Repositories
{
    public class DayRestaurantsRepository
    {
        private IDbConnection _db = new AppSettings().GetDBSring();
        private string accessSalt = new AppSettings().GetHashe("accessSalt");
    }
}
