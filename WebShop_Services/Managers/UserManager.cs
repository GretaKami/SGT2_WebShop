using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_DataAccess.Context;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public class UserManager : IUserManager
    {
        private readonly WebShopDbContext _context;

        public UserManager(WebShopDbContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();          
        }

        public User? GetUserFromDb(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(username));
            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (isValid) return user;
            else return null;

        }

        public bool IsUsernameValid(string username)
        {
            bool isValid;
            var user = _context.Users.FirstOrDefault(n => n.Username.Equals(username));
            isValid = user == null;

            return isValid;
        }

        public bool IsEmailValid(string email)
        {
            bool isValid;
            var user = _context.Users.FirstOrDefault(n => n.Email.Equals(email));
            isValid = user == null;

            return isValid;

        }
    }
}
