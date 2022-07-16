using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);

        public User? GetUserByUsername(string username);

        public User? GetUserByEmail(string email);




    }
}
