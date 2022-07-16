using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Extensions
{
    public static class CartExtensions
    {
        public static CartModel ToModel(this Cart cart)
        {           
            var cartModel = new CartModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items.Select(x => x.ToModel()).ToList(),
            };

            float totalSum = 0;

            foreach(var item in cartModel.Items)
            {
                totalSum += item.TotalPrice;
            }

            cartModel.TotalSum = totalSum;

            return cartModel;
        }
    }
}
