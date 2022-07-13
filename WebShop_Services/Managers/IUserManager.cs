using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public interface IUserManager
    {
        public User? GetUserFromDb(string username, string password);

        public void AddUser(User user);

        public bool IsUsernameValid(string username);

        public bool IsEmailValid(string email);
    }
}
