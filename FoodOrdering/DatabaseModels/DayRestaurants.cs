using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.DatabaseModels
{
    public class DayRestaurants
    {
        //CREATE TABLE DAY_RESTAURANTS
        //(
        //ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
        //RESTAURANTS_ID UNIQUEIDENTIFIER NOT NULL,
        //DATE_TIME DATETIME DEFAULT GETDATE()
        //FOREIGN KEY (RESTAURANTS_ID) REFERENCES RESTAURANTS(ID)
        //)

        public DayRestaurants()
        {
        }

        public DayRestaurants(Guid id, Guid restaurantId, DateTime dateTime)
        {
            this.ID = id;
            this.RESTAURANTS_ID = restaurantId;
            this.DATE_TIME = dateTime;
        }

        public Guid ID { get; set; }
        public Guid RESTAURANTS_ID { get; set; }
        public DateTime DATE_TIME { get; set; }

    }
}
