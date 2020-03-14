using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.DatabaseModels
{
    public class UsersOrder
    {
        //CREATE TABLE USERS_ORDER
        //(
        //ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
        //RESTAURANTS_ORDER_ID UNIQUEIDENTIFIER NOT NULL,
        //USER_ID UNIQUEIDENTIFIER NOT NULL,
        //DATE_TIME DATETIME DEFAULT GETDATE(),
        //FOREIGN KEY (USER_ID) REFERENCES USERS(ID),
        //FOREIGN KEY (RESTAURANTS_ORDER_ID) REFERENCES RESTAURANTS_ORDER_ITEMS(ID)
        //)

        public UsersOrder()
        {
        }

        public UsersOrder(Guid id, Guid restaurantsOrderId, Guid userId, DateTime dateTime)
        {
            this.ID = id;
            this.RESTAURANTS_ORDER_ID = restaurantsOrderId;
            this.USER_ID = userId;
            this.DATE_TIME = dateTime;
        }

        public Guid ID { get; set; }
        public Guid RESTAURANTS_ORDER_ID { get; set; }
        public Guid USER_ID { get; set; }
        public DateTime DATE_TIME { get; set; }
    }
}
