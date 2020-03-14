using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.DatabaseModels
{
    public class RestaurantsOrderItems
    {
        //CREATE TABLE RESTAURANTS_ORDER_ITEMS
        //(
        //ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
        //RESTAURANTS_ID UNIQUEIDENTIFIER NOT NULL,
        //NAME VARCHAR(500),
        //PORTION VARCHAR(500),
        //DESCRIPTION VARCHAR(500),
        //IMAGE VARCHAR(500),
        //PRICE DECIMAL,
        //FOREIGN KEY(RESTAURANTS_ID) REFERENCES RESTAURANTS(ID)
        //)

        public RestaurantsOrderItems()
        {
        }

        public RestaurantsOrderItems(Guid id, Guid restaurantId, string name, string portion, string description, string image, decimal price)
        {
            this.ID = id;
            this.RESTAURANTS_ID = restaurantId;
            this.NAME = name;
            this.PORTION = portion;
            this.DESCRIPTION = description;
            this.IMAGE = image;
            this.PRICE = price;
        }

        public Guid ID { get; set; }
        public Guid RESTAURANTS_ID { get; set; }
        public string NAME { get; set; }
        public string PORTION { get; set; }
        public string DESCRIPTION { get; set; }
        public string IMAGE { get; set; }
        public decimal PRICE { get; set; }
    }
}
