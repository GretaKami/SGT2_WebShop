using Microsoft.AspNetCore.Mvc;
using SGT2_WebShop.Extensions;
using SGT2_WebShop.Models;
using System.Diagnostics;
using WebShop_Services.Managers;

namespace SGT2_WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public HomeController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Index(int? subcategoryId)
        {
            var homeModel = new HomeModel();

            homeModel.Categories = _categoryManager.GetCategoriesFromDb()
                .Select(c => c.ToModel()).ToList();

            if(subcategoryId != null)
            {
                homeModel.SelectedSubcategory = _categoryManager.GetSubcategoriesFromDb()
                    .First(s=> s.Id.Equals(subcategoryId)).ToModel();
            }
          

            return View(homeModel);
        }

        
    }
}