using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Extensions
{
    public static class CartModelExtensions
    {
        public static Cart ToCart(this CartModel cartModel)
        {
            var cart = new Cart
            {
                Id = cartModel.Id,
                UserId = cartModel.UserId,
                Items = cartModel.Items.Select(i => i.ToCartItem()).ToList()
            };

            return cart;
        }
    }
}
