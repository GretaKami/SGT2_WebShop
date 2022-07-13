using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Extensions
{
    public static class CategoryExtension
    {
        public static CategoryModel ToModel(this Category category)
        {
            CategoryModel categoryModel = new CategoryModel
            {
                ID = category.Id,
                Title = category.Title,
                Subcategories = category.Subcategories.Select(s=> s.ToModel()).ToList()                            

            };
        

            return categoryModel;
        }

        public static CategoryModel ToModelForSubcategory(this Category category)
        {
            CategoryModel categoryModel = new CategoryModel
            {
                ID = category.Id,
                Title = category.Title               
                
            };

            return categoryModel;
        }
    }
}
