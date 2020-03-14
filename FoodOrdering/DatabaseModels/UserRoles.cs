using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FoodOrdering.Helpers.Enumerators;

namespace FoodOrdering.DatabaseModels
{
    public class UserRoles
    {
        //CREATE TABLE USER_ROLES
        //(
        //ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
        //ROLE VARCHAR(10)
        //IDENTIFIER INT
        //)

        public UserRoles()
        {
        }

        public UserRoles(Guid id, string role, int identifier)
        {
            this.ID = id;
            this.ROLE = role;
            this.IDENTIFIER = identifier;
        }

        public UserRole getRoleName(int identifier)
        {
            return (UserRole)identifier;
        }

        public Guid ID { get; set; }
        public string ROLE { set; get; }
        public int IDENTIFIER { get; set; }
    }
}
