using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.DatabaseModels
{
    public class OrderLink
    {
        //CREATE TABLE ORDER_LINK
        //(
        //ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
        //USER_ID UNIQUEIDENTIFIER NOT NULL,
        //USERS_ORDER_ID UNIQUEIDENTIFIER,
        //LINK VARCHAR(500),
        //DATE_TIME DATETIME DEFAULT GETDATE(), 
        //EXPIRY_DATE DATETIME,
        //FOREIGN KEY(USER_ID) REFERENCES USERS(ID)
        //)

        public OrderLink()
        {
        }

        public OrderLink(Guid id, Guid userId, Guid usersOrderId, string link, DateTime dateTime, DateTime expiryDate)
        {
            this.ID = id;
            this.USER_ID = userId;
            this.USERS_ORDER_ID = usersOrderId;
            this.LINK = link;
            this.DATE_TIME = dateTime;
            this.EXPIRY_DATE = expiryDate;
        }

        public Guid ID { get; set; }
        public Guid USER_ID { get; set; }
        public Guid USERS_ORDER_ID { get; set; }
        public string LINK { get; set; }
        public DateTime DATE_TIME { get; set; }
        public DateTime EXPIRY_DATE { get; set; }

    }
}
