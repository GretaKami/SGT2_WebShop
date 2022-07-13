using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Extensions
{
    public static class SubcategoryExtension
    {
        public static SubcategoryModel ToModel(this Subcategory subcategory)
        {
            SubcategoryModel subcategoryModel = new SubcategoryModel
            {
                Id = subcategory.Id,
                Title = subcategory.Title,
                Category = subcategory.Category.ToModelForSubcategory(),
                Products = new List<ProductModel>()               
            };

            if(subcategory.Products != null)
            {
                subcategoryModel.Products = subcategory.Products.Select(p => p.ToModel()).ToList();
            }

            return subcategoryModel;
        }

        public static SubcategoryModel ToModelForProduct(this Subcategory subcategory)
        {
            SubcategoryModel subcategoryModel = new SubcategoryModel
            {
                Id = subcategory.Id,
                Title = subcategory.Title,
                Category = subcategory.Category.ToModelForSubcategory()
            };

            return subcategoryModel;
        }
    }
}
