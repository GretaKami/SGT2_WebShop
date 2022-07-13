using Microsoft.AspNetCore.Mvc;
using SGT2_WebShop.Extensions;
using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;
using WebShop_Services.Managers;

namespace SGT2_WebShop.Controllers
{
    public class CategoryController : Controller
    {
        public List<CategoryModel> categoryList;
        public List<ProductModel> productList;

        private readonly ICategoryManager _categoryManager;
        private readonly IProductManager _productManager;
       
        public CategoryController(ICategoryManager categoryManager, IProductManager productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;

            categoryList = _categoryManager.GetCategoriesFromDb().Select(c => c.ToModel()).ToList();

            productList = _productManager.GetProductsFromDb().Select(p => p.ToModel()).ToList();

        }
        public IActionResult Index()
        {
            return View(categoryList);
        }

        public IActionResult View(int id)
        {
            var subcategories = categoryList.FirstOrDefault(c => c.ID.Equals(id)).Subcategories.ToList();


            return View(subcategories);
        }

        [HttpGet]
        public IActionResult NewCategory()
        {
            CategoryModel category = new CategoryModel();

            return View(category);
        }

        [HttpPost]
        public IActionResult NewCategory(CategoryModel category)
        {
            ModelState.Remove(nameof(category.ID));
            ModelState.Remove(nameof(category.Subcategories));

            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    Title = category.Title
                };

                _categoryManager.AddCategory(newCategory);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult NewSubcategory()
        {
            NewSubcategoryModel subcategory = new NewSubcategoryModel();
            subcategory.Categories = categoryList;

            return View(subcategory);
        }

        [HttpPost]
        public IActionResult NewSubcategory(NewSubcategoryModel subcategory)
        {
            ModelState.Remove(nameof(subcategory.Categories));

            if (ModelState.IsValid)
            {                
                Subcategory newSubcategory = new Subcategory
                {
                    Title = subcategory.Title                    
                };

                _categoryManager.AddSubcategory(newSubcategory, subcategory.SelectedCategoryId);
                return RedirectToAction("Index");
            }
            return View(subcategory);
        }
    }
}
