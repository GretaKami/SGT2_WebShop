using Microsoft.EntityFrameworkCore;
using WebShop_DataAccess.Context;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly WebShopDbContext _context;
        public CategoryManager(WebShopDbContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void AddSubcategory(Subcategory subcategory, int categoryId)
        {
            subcategory.Category = _context.Categories.First(c => c.Id.Equals(categoryId));

            _context.Subcategories.Add(subcategory);
            _context.SaveChanges();
        }

        public List<Category> GetCategoriesFromDb()
        {
            List<Category> categories = _context.Categories
                .Include(c => c.Subcategories).ToList();

            return categories;

        }

        public List<Subcategory> GetSubcategoriesFromDb()
        {
            List<Subcategory> subcategories = _context.Subcategories.Include(c => c.Products)
                .Include(c=>c.Category).ToList();

            return subcategories;
        }
    }
}
