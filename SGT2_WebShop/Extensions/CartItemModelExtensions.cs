using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Extensions
{
    public static class CartItemModelExtensions
    {
        public static CartItem ToCartItem(this CartItemModel cartItemModel)
        {
            var cartItem = new CartItem
            {
                Id = cartItemModel.Id,
                ProductId = cartItemModel.ProductId,
                Product = new Product { 
                    Id = cartItemModel.ProductId,
                    Price = cartItemModel.Product.Price
                },
                Quantity = cartItemModel.Quantity,
                CartId = cartItemModel.CartId
            };

            return cartItem;
        }
    }
}
