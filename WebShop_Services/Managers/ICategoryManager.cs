using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public interface ICategoryManager
    {
        public List<Category> GetCategoriesFromDb();

        public List<Subcategory> GetSubcategoriesFromDb();

        public void AddCategory(Category category);

        public void AddSubcategory(Subcategory subcategory, int categoryId);
    }
}
