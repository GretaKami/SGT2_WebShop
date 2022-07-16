using WebShop_DataAccess.Context;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WebShopDbContext _context;
        public UserRepository(WebShopDbContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(n => n.Email.Equals(email));

            return user;
        }

        public User? GetUserByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(username));

            return user;
        }

    }
}
