using WebShop_DataAccess.Context.Entities;
using WebShop_Services.Repositories;

namespace WebShop_Services.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(User user)
        {
            if(user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                _userRepository.AddUser(user);
            }
            else
            {
                throw new Exception("user is null");
            }
                     
        }

        public User? GetUserFromDb(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);

            if(user != null)
            {
                bool isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (isValid) return user;
            }

            return null;     
                       
        }

        public bool IsUsernameValid(string username)
        {
            if (username != null)
            {
                bool isValid;
                var user = _userRepository.GetUserByUsername(username);
                isValid = user == null;

                return isValid;
            }
            else throw new Exception("username is null");
            
        }

        public bool IsEmailValid(string email)
        {
            if(email != null)
            {
                bool isValid;
                var user = _userRepository.GetUserByEmail(email);
                isValid = user == null;

                return isValid;
            }
            else throw new Exception("email is null");            

        }
    }
}
