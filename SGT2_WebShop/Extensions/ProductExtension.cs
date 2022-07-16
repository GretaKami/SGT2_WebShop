using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Extensions
{
    public static class ProductExtension
    {
        public static ProductModel ToModel(this Product product)
        {
            ProductModel productModel = new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Subcategory = product.Subcategory.ToModelForProduct(),
                ImageName = product.ImageName


            };

            return productModel;
        }
    }
}
