using Microsoft.AspNetCore.Mvc;
using SGT2_WebShop.Extensions;
using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;
using WebShop_Services.Managers;

namespace SGT2_WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        private readonly ICartItemManager _cartItemManager;

        public HomeController(ICategoryManager categoryManager, ICartItemManager cartItemManager)
        {
            _categoryManager = categoryManager;
            _cartItemManager = cartItemManager;
        }

        [HttpGet]
        public IActionResult Index(int? subcategoryId)
        {
            var homeModel = new HomeModel();

            homeModel.Categories = _categoryManager.GetCategoriesFromDb()
                                                   .Select(c => c.ToModel())
                                                   .ToList();

            if(subcategoryId != null)
            {
                homeModel.SelectedSubcategory = _categoryManager.GetSubcategoriesFromDb()
                                                                .First(s=> s.Id.Equals(subcategoryId))
                                                                .ToModel();
            }
          

            return View(homeModel);
        }

        [HttpPost]
        public IActionResult Index(int productId)
        {
            if (HttpContext.Session.GetUserId() == null)
            {
                return RedirectToAction("SignIn", "User");
            }
            else
            {
                int userId = (int)HttpContext.Session.GetUserId();

                _cartItemManager.AddNewCartItem(productId, userId);

                return RedirectToAction("Index", "Cart");
            }

        }
            

    }
}