using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Extensions
{
    public static class CartItemExtensions
    {
        public static CartItemModel ToModel(this CartItem cartItem)
        {
            float totalPrice = cartItem.Quantity * cartItem.Product.Price;

            var cartItemModel = new CartItemModel
            {
                Id = cartItem.Id,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
                Product = cartItem.Product.ToModelForCartItem(),
                Quantity = cartItem.Quantity,
                TotalPrice = totalPrice
            };

            return cartItemModel;
        }
    }
}
