using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.DatabaseModels
{
    public class Users
    {
        //CREATE TABLE USERS
        //(
        //ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
        //USER_ROLE UNIQUEIDENTIFIER NOT NULL,
        //FIRST_NAME VARCHAR(300),
        //LAST_NAME VARCHAR(300),
        //EMAIL VARCHAR(300) NOT NULL,
        //DATE_TIME DATETIME DEFAULT GETDATE(), 
        //IS_ACTIVE BIT DEFAULT 0
        //FOREIGN KEY(USER_ROLE) REFERENCES USER_ROLES(ID)
        //)

        public Users()
        {
        }

        public Users(Guid id, Guid role, string firstName, string lastName, string email, DateTime dateTime, bool isAvtive)
        {
            this.ID = id;
            this.USER_ROLE = role;
            this.FIRST_NAME = firstName;
            this.LAST_NAME = lastName;
            this.EMAIL = email;
            this.DATE_TIME = dateTime;
            this.IS_ACTIVE = isAvtive;
        }

        public Guid ID { get; set; }
        public Guid USER_ROLE { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string EMAIL { get; set; }
        public DateTime DATE_TIME { get; set; }
        public bool IS_ACTIVE { get; set; }

    }
}
