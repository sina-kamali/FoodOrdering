using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.DatabaseModels
{
    public class Restaurants
    {
        //CREATE TABLE RESTAURANTS
        //(
        //ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
        //NAME VARCHAR(500),
        //)

        public Restaurants()
        {
        }

        public Restaurants(Guid id, string name)
        {
            this.ID = id;
            this.NAME = name;
        }

        public Guid ID { get; set; }
        public string NAME { get; set; }
    }
}
