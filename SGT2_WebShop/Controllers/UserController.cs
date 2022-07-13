using Microsoft.AspNetCore.Mvc;
using SGT2_WebShop.Extensions;
using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;
using WebShop_Services.Managers;

namespace SGT2_WebShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var user = new UserSignInModel();
            return View(user);
        }

        [HttpPost]
        public IActionResult SignIn(UserSignInModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetUserFromDb(userModel.Username, userModel.Password);
                if ( user != null)
                {
                    HttpContext.Session.SetSession(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Incorrect log in details");
                    return View(userModel);
                }
            }
            
            return View(userModel);
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            UserSignUpModel user = new UserSignUpModel();
            return View(user);
        }

        [HttpPost]
        public IActionResult SignUp(UserSignUpModel user)
        {
            if(user.Password != user.RepeatPassword)
                ModelState.AddModelError("RepeatPassword", "Repeated password doesn't match");
            
            if(!_userManager.IsUsernameValid(user.Username))
                ModelState.AddModelError("Username", "Username is taken");

            if (!_userManager.IsEmailValid(user.Email))
                ModelState.AddModelError("Email", "Email is taken");


            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email
                };

                _userManager.AddUser(newUser);

                return RedirectToAction("SignIn");

            }
            return View(user);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}
