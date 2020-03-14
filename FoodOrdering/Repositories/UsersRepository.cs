using Dapper;
using FoodOrdering.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Repositories
{
    public class UsersRepository
    {
        private IDbConnection _db = new AppSettings().GetDBSring();
        private string accessSalt = new AppSettings().GetHashe("accessSalt");

        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();
            users = _db.Query<Users>("SELECT * FROM USERS", new Users()).ToList();
            return users;

        }

        public Users GetUser(Guid userId)
        {
            Users user = _db.Query<Users>("SELECT * FROM USERS WHERE ID = @ID", new Users() { ID = userId }).SingleOrDefault();
            return user;
        }

        public bool AddUser(Users user)
        {
            if (user != null)
            {
                if (user.ID == Guid.Empty)
                    user.ID = Guid.NewGuid();

                _db.Query<Users>("INSERT INTO USERS(ID, USER_ROLE, FIRST_NAME, LAST_NAME, EMAIL, DATE_TIME, IS_ACTIVE) VALUES(@ID, @USER_ROLE, @FIRST_NAME, @LAST_NAME, @EMAIL, @DATE_TIME, @IS_ACTIVE)", user).SingleOrDefault();
                return true;
            }
            return false;
        }

        public bool AddUser(List<Users> users)
        {
            if (users != null && users.Count != 0)
            {
                foreach (var user in users)
                {

                    if (user.ID == Guid.Empty)
                        user.ID = Guid.NewGuid();

                    _db.Query<Users>("INSERT INTO USERS(ID, USER_ROLE, FIRST_NAME, LAST_NAME, EMAIL, DATE_TIME, IS_ACTIVE) VALUES(@ID, @USER_ROLE, @FIRST_NAME, @LAST_NAME, @EMAIL, @DATE_TIME, @IS_ACTIVE)", user).SingleOrDefault();

                }
                return true;
            }
            return false;
        }

        public bool UpdateUser(Users user)
        {
            if (user != null)
            {
                int count = _db.Execute("UPDATE USERS SET USER_ROLE = @USER_ROLE, FIRST_NAME = @FIRST_NAME , LAST_NAME = @LAST_NAME, EMAIL = @EMAIL, DATE_TIME = @DATE_TIME, IS_ACTIVE = @IS_ACTIVE WHERE ID = @ID", user);
                if (count == 1)
                    return true;

            }

            return false;
        }
    }
}
